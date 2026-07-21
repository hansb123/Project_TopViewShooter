using UnityEngine;
// Player를 감지한다면 
// 감지한 몬스터 +  주변 몬스터 또한 N초간 Player 추적)
// N초 추적이 끝나고 제자리로 돌아가면 Hp 풀로 회복 + 다시 Patrol 상태 
// 각 상태의 역할이 명확하므로 FSM을 사용함 

// Patrol() , Return() ,  Attack() ,  Trace() 등 


public class Monster : MonoBehaviour 
{
    [SerializeField] MonsterData monsterData;
    [SerializeField] LayerMask obstacleLayer;

    Rigidbody2D rb;


    [SerializeField] Transform player;
    Transform target;

    MonsterStateMachine stateMachine;


    Vector2 startPosition;
    bool isForward = true;

    private float viewDistance = 10f; // 이후 값 수정 
    private float viewAngle = 90f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        stateMachine = new MonsterStateMachine(this);

       
     
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }



    public void Patrol() //정찰 
    {
        Vector2 target = GetPatrolTarget();


        transform.position = Vector2.MoveTowards(transform.position, target, monsterData.patrolSpeed * Time.deltaTime);

        if(Vector2.Distance(transform.position, target) < 0.1f)
        {
            isForward = !isForward;
        }

    }
    private Vector2 GetPatrolTarget() //정찰 목적지 계산 
    {
        if (monsterData.horizontalPatrol)
        {
            if (isForward)
            {
                return startPosition + Vector2.right * monsterData.patrolDistance;
            }
            else
            {
                return startPosition - Vector2.right * monsterData.patrolDistance;
            }
        }
        else
        {
            if (isForward)
            {
                return startPosition + Vector2.up * monsterData.patrolDistance;
            }
            else
            {
                return startPosition - Vector2.up * monsterData.patrolDistance;
            }
        }
    }

    public void Trace()
    {
        //CanseePlayer() => 시야에 유저가 있다면 추적시간 계속해서 갱신
        //
    }





    public virtual void Attack()
    {

    }



    public bool CanSeePlayer()
    {
        // 거리 검사 
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance > viewDistance)
            return false;

        Vector2 dir = (player.transform.position - transform.position).normalized;

        //시야각 
        float angle = Vector2.Angle(transform.right, dir);

        if (angle > viewAngle * 0.5f)
            return false;

        //벽 검사 
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, viewDistance, obstacleLayer); 

        //Raycast가 만약 벽에(먼저) 맞았다면, 플레이어를 볼 수없다. 
        if (hit.collider != null)
            return false;

        target = player;


        Debug.Log("플레이어 감지함");
        return true;
    }

    public void AlertNearbyMonster()
    {

    }

    public void Alert(Transform player)
    {

    }











    //TODO : 빌드전 삭제 
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        Vector3 origin = transform.position;

        float halfAngle = viewAngle * 0.5f;
        int segment = 30;

        Vector3 prevPoint = origin + Quaternion.Euler(0, 0, -halfAngle) * transform.right * viewDistance;


        for (int i = 1; i <= segment; i++)
        {
            float angle = Mathf.Lerp(-halfAngle, halfAngle, i / (float)segment);

            Vector3 nextPoint = origin +
                Quaternion.Euler(0, 0, angle) * transform.right * viewDistance;

            Gizmos.DrawLine(prevPoint, nextPoint);

            prevPoint = nextPoint;
        }

        // 양쪽 선
        Gizmos.DrawLine(origin,
            origin + Quaternion.Euler(0, 0, -halfAngle) * transform.right * viewDistance);

        Gizmos.DrawLine(origin,
            origin + Quaternion.Euler(0, 0, halfAngle) * transform.right * viewDistance);
    }


}
