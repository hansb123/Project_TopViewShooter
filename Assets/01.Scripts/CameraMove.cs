using UnityEngine;

public class CameraMove : MonoBehaviour
{
    //시네머신 활용?
    [SerializeField] private Transform target;
    private Vector3 vel = Vector3.zero;

    private void Start()
    {
        
    }


    private void LateUpdate()
    {
        Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);


        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref vel, 0.15f);

    }
}
