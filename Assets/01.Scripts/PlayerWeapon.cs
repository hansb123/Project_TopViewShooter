using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerWeapon : MonoBehaviour
{
    [SerializeField] Transform firePos;

    [SerializeField] protected WeaponLaser laser;
  
    void Update()
    {
        //조준선 생성 
        CrossHairLaser();
        Equip();


    }

    //player 조준선
    protected void CrossHairLaser()
    {

        if (Mouse.current.rightButton.isPressed)
        {
            laser.DrawAim();
            if(Mouse.current.leftButton.wasPressedThisFrame)
            {
                Attack();
            }
        }
        else
        {
            laser.HideAim();
        }
    }

   

     protected abstract void Attack();
 



   
}
