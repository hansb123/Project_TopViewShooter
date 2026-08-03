using UnityEngine;
using UnityEngine.InputSystem;


public class WeaponLaser : MonoBehaviour 
{
    [SerializeField] private Transform laserPos;
    [SerializeField] private LayerMask laserHitLayer; //충돌할 레이어 
    private LineRenderer line;
    

    void Start()
    {
        //점의 개수 
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
        line.enabled = false;
        line.startWidth = 0.0f;
        line.endWidth = 0.05f;
    }

    //Raycast => 선 충돌감지 / 선이 충돌 시 그 이후 선을 x (장애물에 닿으면 선을 제거해야하므로) 
    //LineRenderer => 선을 그리기.
    //https://hsh12345.tistory.com/298 해당 블로그 참고하였음 
    public void DrawAim(float rng) 
    {

        RaycastHit2D crosshair;  //조준선 장애물 / 적에게 닿는지 검사할 Ray
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = -Camera.main.transform.position.z; 
        mousePos = Camera.main.ScreenToWorldPoint(mousePos); //마우스방향 


        Vector2 rayDirection = (mousePos - laserPos.position).normalized; //플레이어 위치 기준 마우스 방향 구하기 .

        crosshair = Physics2D.Raycast(laserPos.position, rayDirection, rng,laserHitLayer); 

        //Debug.DrawRay(laserPos.position, rayDirection *5f);


        //실제 유저에게 보여줄 레이저 조준선 
        line.enabled = true;
        line.SetPosition(0, laserPos.position);

        if(crosshair.collider != null)
        {
            line.SetPosition(1, crosshair.point );

        }
        else
        {
            line.SetPosition(1, (Vector2)laserPos.position + rayDirection * rng); 
        }
   

    }

    public void HideAim()
    {
        line.enabled = false;
    }

}
