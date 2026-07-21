
public class MonsterStateMachine : StateMachine
{

    public MonsterPatrolState patrolState;
    public MonsterAttackState attackState;
    public MonsterTraceState traceState;


    public MonsterStateMachine(Monster monster)
    {
        traceState = new MonsterTraceState(monster,this);
        patrolState = new MonsterPatrolState(monster,this);
        attackState = new MonsterAttackState(monster, this);


        currentState = patrolState; //초기상태
        currentState.Enter();



    }



}
