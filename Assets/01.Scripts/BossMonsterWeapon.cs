using UnityEngine;

public class BossMonsterWeapon : MonoBehaviour
{

    [SerializeField] MonsterProjectile monsterProjectile;
    [SerializeField] MonsterWeaponData monsterWeaponData;
    [SerializeField] BossAreaAttack bossAreaAttack;

    [SerializeField] LayerMask targetLayer;
    [SerializeField] Transform firePos;

    private int attackCount;



    public void Fire(Transform target)
    {
        Vector2 dir = (target.position - firePos.position).normalized;

        RaycastHit2D hit = Physics2D.Raycast(firePos.position, dir, monsterWeaponData.range, targetLayer);

        if (hit.collider == null || !hit.collider.CompareTag("Player"))
        {

            return;
        }

        attackCount++;

        if (attackCount == 2)
        {
            FireSingle(dir);
            AreaAttack(target.position); //장판 공격=> 2번쨰 공격마다 실행 
        }

        if (attackCount < 4) //4번째발 => 광역공격 
        {
            FireSingle(dir);
        }
        else
        {
            FireLine(dir);
            attackCount = 0;
        }

    }


    public void AreaAttack(Vector2 pos) //BossAreaAttack => 장판 공격 
    {
        BossAreaAttack areaAttack = Instantiate(bossAreaAttack, pos, Quaternion.identity);

        areaAttack.Init(monsterWeaponData.damage);
    }


    private void FireSingle(Vector2 dir)
    {

        MonsterProjectile projectile =
       ObjectPoolManager.instance.GetObject<MonsterProjectile>("MonsterBullet");

        projectile.transform.position = firePos.position;
        projectile.transform.right = dir;

        projectile.Init(
            monsterWeaponData.damage,
            monsterWeaponData.speed,
            monsterWeaponData.range
        );

    }

    private void FireLine(Vector2 dir)
    {

        for (int i = -2; i <= 2; i++)
        {
            MonsterProjectile projectile = ObjectPoolManager.instance.GetObject<MonsterProjectile>("MonsterBullet");

            Vector2 per = new Vector2(-dir.y, dir.x);

            float padding = 0.5f;

            projectile.transform.position = (Vector2)firePos.position + per * i * padding;
            projectile.transform.right = dir;


            projectile.Init
               (
               monsterWeaponData.damage,
               monsterWeaponData.speed,
               monsterWeaponData.range

               );

        }
    }



}
