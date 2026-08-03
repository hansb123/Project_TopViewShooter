
public class MonsterPatrolState : MonsterBaseState
{
    public MonsterPatrolState(Monster _monster, MonsterStateMachine _stateMachine) : base(_monster, _stateMachine) { }

    //base의 사용이유? => 몬스터 베이스스테이트에서 공통으로 사용하는 몬스터랑 스테이트머신을 초기화하기위해 부모 생성자를 호출함.
    //자식 클래스는 베이스를 작성하면 중복코드를 작성하지 않아도 됨.

    public override void Update()
    {
 

        if (monster.CanSeePlayer()) //몬스터가 유저를 발견한다면 
        {
          
            stateMachine.ChangeState(stateMachine.traceState); //추적 상태로 전환 
            return;
        }

    }

    public override void FixedUpdate() //움직임은 물리
    {
        monster.Patrol(); //몬스터를 Patrol상태로 전환 
    }
}
