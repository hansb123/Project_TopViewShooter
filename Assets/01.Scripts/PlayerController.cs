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
    private bool[] myWeapon;


    private Iinventory inventory;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movespeed = 8;
        sprintSpeed = 12;
        playerInfo = GetComponent<PlayerInfo>();
        inventory = GetComponentInParent<Iinventory>();

        myWeapon = new bool[3];

        myWeapon[0] = true;

     

        UiManager.instance.WeaponUpgrade(transform.GetChild(0).name);
    }


    private void Update()
    {
        PlayerMove();
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



    public void UpgradeWeapon()
    {
        if (!myWeapon[1])
        {
            myWeapon[1] = true;

            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);

            UiManager.instance.WeaponUpgrade(transform.GetChild(1).name);

        }
        else if (!myWeapon[2])
        {
            myWeapon[2] = true;

            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);

            UiManager.instance.WeaponUpgrade(transform.GetChild(2).name);
        }

    }

    private void PlayerUse()
    {
        if(Keyboard.current.qKey.wasPressedThisFrame)
        {
            inventory.UsePotion(); //Q => 포션사용
        }

        if (Keyboard.current.zKey.wasPressedThisFrame)
        {
            inventory.UseStaminaPotion(); //Z => 스태미너 포션 사용 
        }
    }

   




    private void FixedUpdate()
    {

        
        rb.linearVelocity = dir.normalized * currentSpeed;
    }
}
