using UnityEngine;

public class PlayerHandGun : PlayerWeapon
{
    //TODO : 가지고 있어야할 값들 => 탄약(재장전 필요), 공격주기(활과 달리, 조준 시 바로 공격이 가능해야함.)
    void Start()
    {
        camera = Camera.main;
    }


    protected override void Update()
    {
        base.Update();
    }

    protected override void Attack()
    {
        Bullet bullet = ObjectPoolManager.instance.GetObject<Bullet>("Bullet");
        bullet.transform.position = firePos.position;
        bullet.transform.rotation = transform.rotation;


        bullet.Init
            (
            weaponData.damage,
            weaponData.attackSpeed,
            weaponData.range
            );

       
    }
}
