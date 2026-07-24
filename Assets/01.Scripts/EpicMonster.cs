using UnityEngine;

public class EpicMonster : Monster
{
    [SerializeField] EpicMonsterWeapon epicMonsterWeapon;
    public override void Attack()
    {
        base.Attack();
        StartAttackCooldown();
        epicMonsterWeapon.Fire(target);
    }
}
