using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerBow : PlayerWeapon
{
    

    protected override void Start()
    {
        //차지속도 => 총 쏘는 사이의 간격으로 설정
        base.Start();
        camera = Camera.main;
      
    }

    protected override void Update()
    {
        base.Update();
        IsCharged(); //활시위
       
           //HUD에 활시위 전달 
    }

    void IsCharged() 
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

        if(isFire && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Attack();
            
        }
    }

  

    //차지, 공격
    protected override void Attack()
    {
        Arrow arrow = ObjectPoolManager.instance.GetObject<Arrow>("Arrow");
        arrow.transform.position = firePos.position;
        arrow.transform.rotation = transform.rotation;


        arrow.Init
            (
            weaponData.damage,
            weaponData.attackSpeed,
            weaponData.range
            );

        currentFire = 0f;
        isFire = false;
    }
}
