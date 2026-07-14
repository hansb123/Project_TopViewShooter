using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerBow : PlayerWeapon
{
    float charge;
    float currentcharge;
    bool isCharge;
    void Start()
    {
        //차지속도 => 총 쏘는 사이의 간격으로 설정함 
        //TODO : HUD 제작. => 활시위 등을 사용해야하므로  
        charge = weaponData.fireRate;
        camera = Camera.main;
        isCharge = false;
    }

    protected override void Update()
    {
        base.Update();
        IsCharged(); //활시위
        UiManager.instance.FireUpdate(charge);
    }

    void IsCharged() 
    {
        
        if (Mouse.current.rightButton.isPressed)
        {
            currentcharge += Time.deltaTime;
           

            if (currentcharge >= charge)
            {
              
                isCharge = true;
            }

        }
        else
        {
            currentcharge = 0f;
            isCharge = false;
        }

        if(isCharge && Mouse.current.leftButton.wasPressedThisFrame)
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

        currentcharge = 0f;
        isCharge = false;
    }
}
