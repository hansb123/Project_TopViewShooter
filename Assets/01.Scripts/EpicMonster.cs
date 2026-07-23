using UnityEngine;

public class EpicMonster : Monster
{
    [SerializeField] EpicMonsterWeapon epicMonsterWeapon;
    public override void Attack()
    {

        StartAttackCooldown();
        epicMonsterWeapon.Fire(target);
    }
}
