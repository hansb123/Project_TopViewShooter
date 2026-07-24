using UnityEngine;

public class BossMonster : Monster
{
    [SerializeField] Transform[] spawn; //배열로 소환할 위치 미리 정하기 
    [SerializeField] BossMonsterWeapon bossMonsterWeapon;

   
    public override void Attack()
    {

        StartAttackCooldown();

        bossMonsterWeapon.Fire(target);
     
    }

    




}
