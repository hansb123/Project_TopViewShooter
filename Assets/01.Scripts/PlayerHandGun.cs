using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHandGun : PlayerWeapon
{
   

    private Iinventory reloadAmmo;

    protected override void Start()
    {
        base.Start();
        reloadAmmo = GetComponentInParent<Iinventory>();
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
            if(TryUseAmmo()) //=탄약을 사용할 수 있는지 
            Attack();

        }
    }




    protected override void Attack()
    {
        Bullet bullet = ObjectPoolManager.instance.GetObject<Bullet>("Bullet");
        bullet.transform.position = firePos.position;
        bullet.transform.rotation = transform.rotation;

        SoundManager.instance.PlaySFX(SFXType.BulletAttack);


        //데미지, 스피드, 사거리 값을 발사체에 전달 
        bullet.Init
            (
            weaponData.damage,
            weaponData.attackSpeed,
            weaponData.range
            );

        currentFire = 0f;
        isFire = false;

       
    }

    public void SetAmmo(Iinventory ammo)
    {
        reloadAmmo = ammo;
    }

    private bool TryUseAmmo()
    {
        return reloadAmmo.UseAmmo(1);//탄약 1발 사용 => 무기 추가 확장성 
    }
}
