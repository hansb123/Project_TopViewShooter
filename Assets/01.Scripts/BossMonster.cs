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

    









    //보스몬스터에 들어갈것(자체 스킬)=> 몬스터 소환, 체력 회복
    //첫번째 소환 => RareMelle몬스터 (드랍) => Instantiate (gameObjcet) 하면되고 (소환 위치 )
    //두번쨰 소환 => RareRange몬스터 (드랍) => 마찬가지 
    //세번쨰 소환 => ㄴ 2마리씩 x2번 소환 
    //네번쨰 소환 => Epic 몬스터
    //다섯번째 소환 => ㄴ x2
    //이후 종료 

    //보스몬스터 자체 공격 => BossMonsterWeapon
    //일반적인 Epic몬스터의 공격 + 플레이어 위치 기준, 점점 커지는 장판(Overlap사용) => 꽉 차면 해당 위치에 데미지. 




}
