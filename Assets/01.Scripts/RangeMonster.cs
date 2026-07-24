using UnityEngine;

public class RangeMonster : Monster
{
    [SerializeField] MonsterWeapon monsterWeapon;



    public override void Attack()
    {
        base.Attack();
        StartAttackCooldown();
        monsterWeapon.Fire(target);
    }




}
