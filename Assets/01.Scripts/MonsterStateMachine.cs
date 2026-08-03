
public class MonsterStateMachine : StateMachine //몬스터가 사용할 상태들을 미리 생성, 보관하는 역할 
{

    public MonsterPatrolState patrolState;
    public MonsterAttackState attackState;
    public MonsterReturnState returnState;
    public MonsterTraceState traceState;


    public MonsterStateMachine(Monster monster)
    {
        traceState = new MonsterTraceState(monster,this);
        patrolState = new MonsterPatrolState(monster,this);
        returnState = new MonsterReturnState(monster, this);
        attackState = new MonsterAttackState(monster, this);


        currentState = patrolState; //초기상태
        currentState.Enter();



    }



}
