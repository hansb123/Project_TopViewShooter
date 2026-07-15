using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHandGun : PlayerWeapon
{
    //TODO : 가지고 있어야할 값들 => 탄약(재장전 필요)

    private IReloadAmmo reloadAmmo;

    protected override void Start()
    {
        base.Start();
        reloadAmmo = GetComponentInParent<IReloadAmmo>();
        camera = Camera.main;
      
    }

    private void OnEnable()
    {
        
    }


    protected override void Update()
    {
        base.Update();
        IsFire();
        IReloadAmmo();
    }

    void IReloadAmmo()
    {
        if(Keyboard.current.rKey.wasPressedThisFrame)
        {
            //TODO:장전 로직 
        }
    }

    void IsFire() //Handgun의 경우도 마찬가지로 단발성 공격이므로,해당 코드를 부모에 두지 않았다. (WasPressedThisFrame이므로)
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

        if (isFire && Mouse.current.leftButton.wasPressedThisFrame)
        {
            if(TryUseAmmo())
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

    public void SetAmmo(IReloadAmmo ammo)
    {
        reloadAmmo = ammo;
    }

    private bool TryUseAmmo()
    {
        return reloadAmmo.UseAmmo(1);
    }
}
