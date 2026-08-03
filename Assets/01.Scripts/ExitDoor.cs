using UnityEngine;

public class ExitDoor : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GameManager.instance.EndScene();
        }
    }
}
