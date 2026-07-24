using UnityEngine;
public class MonsterWeapon : MonoBehaviour //원거리 전용 클래스
{
    [SerializeField] MonsterProjectile monsterProjectile;
    [SerializeField] MonsterWeaponData monsterWeaponData; 
    [SerializeField] LayerMask targetLayer;
    [SerializeField] Transform firePos;


   
    public void Fire(Transform target)
    {
        Vector2 dir = (target.position - firePos.position).normalized;

        RaycastHit2D hit = Physics2D.Raycast(firePos.position, dir, monsterWeaponData.range, targetLayer);

        if (hit.collider == null || !hit.collider.CompareTag("Player"))
        {

            return;
        }



        MonsterProjectile projectile = ObjectPoolManager.instance.GetObject<MonsterProjectile>("MonsterBullet");

        projectile.transform.position = firePos.position;
        projectile.transform.right = dir;


        projectile.Init
           (
           monsterWeaponData.damage,
           monsterWeaponData.speed,
           monsterWeaponData.range
       
           );



    }



}
