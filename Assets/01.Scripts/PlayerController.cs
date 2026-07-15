using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{

    private Vector2 dir;
    private Rigidbody2D rb;


   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    
    void Update()
    {
        PlayerMove();
        PlayerWeaponSwap();
    }


    private void PlayerMove()
    {
        dir = Vector2.zero;
        if (Keyboard.current.wKey.isPressed)
        {
            dir += Vector2.up;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            dir += Vector2.left;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            dir += Vector2.down;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            dir += Vector2.right;
        }
    }

    private void PlayerWeaponSwap()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
            ChangeWeapon(0);

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
            ChangeWeapon(1);

        if (Keyboard.current.digit3Key.wasPressedThisFrame)
            ChangeWeapon(2);
    }


    private void ChangeWeapon(int index)
    {
        for (int i= 0; i< transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == index);
        }

    }




    private void FixedUpdate()
    {

        // TODO : 나중에 Speed 값 정하기 
        rb.linearVelocity = dir * 5;
    }
}
