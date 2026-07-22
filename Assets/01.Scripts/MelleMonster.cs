using UnityEngine;
using DG.Tweening;
public class MelleMonster : Monster
{
    bool isAttack; //근거리의공격 => 대쉬&공격

   

    public override void Attack()
    {
        if (isAttack)
            return;

        isAttack = true;

        StartAttackCooldown();


        Vector2 dir = (target.position - transform.position).normalized;
        Vector2 endPos = (Vector2)transform.position + dir * monsterWeaponData.range;
        transform.right = dir;


        rb.DOMove(endPos, monsterWeaponData.range / monsterWeaponData.speed)
            .SetEase(Ease.Linear)
            .OnComplete(() => {
                isAttack = false;
            });

    }

    private void OnCollisionEnter(Collision collision)
    {
      
    }

    public override bool IsAttackEnd()
    {
        return !isAttack;
    }


}
