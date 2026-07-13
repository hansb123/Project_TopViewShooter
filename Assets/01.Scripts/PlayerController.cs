using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{

    private Vector2 dir;
    private Rigidbody2D rb;

    [SerializeField] WeaponLaser laser;
   

   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
     
    }

    
    void Update()
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

        if (Mouse.current.rightButton.isPressed)
        {
            laser.DrawAim();
        }
        else
        {
            laser.HideAim();
        }

    }

    private void FixedUpdate()
    {

        // TODO : 나중에 Speed 값 정하기 
        rb.linearVelocity = dir * 5;
    }
}
