using UnityEngine;

public class BossMonster : Monster
{
    [SerializeField] Transform[] spawn; //배열로 소환할 위치 미리 정하기 
    [SerializeField] BossMonsterWeapon bossMonsterWeapon;
    [SerializeField] GameObject exitDoor;
  
   
    public override void Attack()
    {
        base.Attack();
        StartAttackCooldown();

        bossMonsterWeapon.Fire(target);
     
    }


    private void OnDestroy()
    {
        Destroy(exitDoor);
    }


    //Ondestroy= > 보장되지않는다? 






}
