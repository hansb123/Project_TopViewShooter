using UnityEngine;

public class CameraMove : MonoBehaviour
{
    //시네머신 활용?
    [SerializeField] private Transform target;
    [SerializeField] private PolygonCollider2D mapBounds; //카메라가 움직이는 맵 범위 

    private Vector3 vel = Vector3.zero;

    private Camera cam;
    private Bounds bounds; //Bounds => 게임오브젝트, 콜라이더 렌더러를 감싸는 AABB(중심점, 크기, 최소/최대좌표)등등 

    private void Start()
    {
        cam = GetComponent<Camera>();
        bounds = mapBounds.bounds; // 폴리곤 콜라이더2D의 크기정보를 가져옴 

    }


    private void LateUpdate()
    {
        //따라다닐 타겟포지션  
        Vector3 targetPos = new Vector3(
           target.position.x,
           target.position.y,
           transform.position.z);

        Vector3 pos = Vector3.SmoothDamp(transform.position, targetPos, ref vel, 0.15f); //부드럽게 움직이게 

        //카메라 크기 계산 
        float camHeight = cam.orthographicSize; //카메라가 화면에 보여주는 세로길이의 절반값. 
        float camWidth = camHeight * cam.aspect; //카메라가 화면에 보여주는 가로길이의 절반값. 

        pos.x = Mathf.Clamp(pos.x,
            bounds.min.x + camWidth, //bounds.min.x => 맵 왼쪽 데드존 설정
            bounds.max.x - camWidth);//bounds.max.x => 맵 오른쪽 데드존 설정

        pos.y = Mathf.Clamp(pos.y,
            bounds.min.y + camHeight, //bounds.min.y = > 맵 위쪽 데드존 설정
            bounds.max.y - camHeight);//bounds.max.y = > 맵 아래쪽 데드존 설정 

        transform.position = pos; 

    }
}
