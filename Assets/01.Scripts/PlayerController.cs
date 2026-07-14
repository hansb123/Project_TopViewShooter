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

 

    private void FixedUpdate()
    {

        // TODO : 나중에 Speed 값 정하기 
        rb.linearVelocity = dir * 5;
    }
}
