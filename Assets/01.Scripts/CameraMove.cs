using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 vel = Vector3.zero;

    private void Start()
    {
        
    }


    private void LateUpdate()
    {
        Vector3 targetPos = new Vector3(player.position.x, player.position.y, transform.position.z);


        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref vel, 0.15f);

    }
}
