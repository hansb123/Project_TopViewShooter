using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform granadePos;

    private Vector2 dir;
    private Rigidbody2D rb;
    private float movespeed;
    private float sprintSpeed;
    private float currentSpeed;

    private PlayerInfo playerInfo;

    private Iinventory inventory;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movespeed = 8;
        sprintSpeed = 12;
        playerInfo = GetComponent<PlayerInfo>();
        inventory = GetComponentInParent<Iinventory>();
    }


    private void Update()
    {
        PlayerMove();
        PlayerWeaponSwap();
        PlayerUse();
        Playersprint();
      
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

    private void Playersprint()
    {
        if (Keyboard.current.shiftKey.isPressed )
        {
            currentSpeed = playerInfo.TryUseStamina() ? sprintSpeed : movespeed; //shift를 누루고있는동안에는 스테미너 회복 호출x 
        }
        else
        {

            currentSpeed = movespeed;
            playerInfo.RecoverStamina();
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

    private void PlayerUse()
    {
        if(Keyboard.current.qKey.wasPressedThisFrame)
        {
            inventory.UsePotion();
        }

        if (Keyboard.current.zKey.wasPressedThisFrame)
        {
            inventory.UseStaminaPotion(); //폭탄 => use의 개념? => player가 직접 던지는 것이므로, player에서 나가는게 맞나? 
        }
    }




    private void FixedUpdate()
    {

        
        rb.linearVelocity = dir.normalized * currentSpeed;
    }
}
