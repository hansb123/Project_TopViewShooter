using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerWeapon : MonoBehaviour
{
    [SerializeField] protected Transform firePos;
    [SerializeField] protected WeaponData weaponData;
    [SerializeField] protected WeaponLaser laser;

    protected Camera camera;

    

    protected virtual void Update()
    {
        //조준선 생성 
        //조준선과 조준은 별개 
        CrossHairLaser();
        LookAtMouse();
    }

    //player 조준선
    protected void CrossHairLaser()
    {

        if (Mouse.current.rightButton.isPressed)
        {
            laser.DrawAim();
            
        }
        else
        {
            laser.HideAim();
        }
    }

    private void LookAtMouse()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();

        Vector3 worldPos = camera.ScreenToWorldPoint(mousePos);

        worldPos.z = 0f;

        Vector2 dir = worldPos - transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);

    }

   

     protected abstract void Attack();
 



   
}
