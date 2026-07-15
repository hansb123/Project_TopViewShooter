using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMiniGun : PlayerWeapon, IReloadAmmo
{




    protected override void Start()
    {
        base.Start();
        camera = Camera.main;
    }



    protected override void Update()
    {
        base.Update();
        IsFire();
    }

    void IsFire() 
    {

        if (Mouse.current.rightButton.isPressed)
        {
            currentFire += Time.deltaTime;


            if (currentFire >= fireRate)
            {
                //이곳에 현재 잔존탄약코드넣기 
                isFire = true;
            }

        }
        else
        {
            currentFire = 0f;
            isFire = false;
        }

        if (isFire && Mouse.current.leftButton.isPressed)
        {
            Attack();

        }
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

        currentFire = 0f;
        isFire = false;
    }
}
