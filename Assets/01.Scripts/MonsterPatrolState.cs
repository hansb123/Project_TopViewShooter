
public class MonsterPatrolState : MonsterBaseState
{
    public MonsterPatrolState(Monster _monster, MonsterStateMachine _stateMachine) : base(_monster, _stateMachine) { }
    
    //MonsterPatrolState를 만들 떄 ,Monster와 MonsterStateMachine을 넘긴다. (base를 사용하여 부모 생성자를 호출함.)

    public override void Update()
    {
 

        if (monster.CanSeePlayer())
        {
            //주위 몬스터에게 알림 => 플레이어 추적 명령 (만약상태가 바뀐다면, 상태가 trace로 바뀜)
            //monster.AlertNearbyMonster();
            stateMachine.ChangeState(stateMachine.traceState);
            return;
        }

    }

    public override void FixedUpdate()
    {
        monster.Patrol();
    }
}
