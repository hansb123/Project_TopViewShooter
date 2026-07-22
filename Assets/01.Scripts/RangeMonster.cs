using UnityEngine;

public class RangeMonster : Monster
{
    [SerializeField] MonsterWeapon monsterWeapon;



    public override void Attack()
    {
        
        StartAttackCooldown();
        monsterWeapon.Fire(target);
    }




}
