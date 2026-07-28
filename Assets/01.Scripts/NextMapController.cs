using UnityEngine;

public class NextMapController : MonoBehaviour
{
    [SerializeField] GameObject wall;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Destroy(wall);
        }
    }
}
