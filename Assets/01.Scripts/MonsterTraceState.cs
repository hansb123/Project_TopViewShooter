public class MonsterTraceState : MonsterBaseState
{
    public MonsterTraceState(Monster _monster, MonsterStateMachine _stateMachine) : base(_monster, _stateMachine) { }


 

    public override void Update()
    {
        if(monster.CanSeePlayer()) //플레이어를 볼 수 있다면(몬스터 시야) 
        {
            monster.RestSightTimer(); //시간 초기화 (추적시간)

            if(monster.IsAttackRange())//공격사거리가 된다면 
            {
                stateMachine.ChangeState(stateMachine.attackState); //공격 스테이트로 전환
            }

            return;
            
        }

        if(monster.IsSightTimeOver()) //시야를 놓쳤을때, (시야를 놓치고 나서 일정 시간 지난다면)
        {
            stateMachine.ChangeState(stateMachine.returnState); 
        }
   
    }

    public override void FixedUpdate()
    {
        monster.Trace(); //추적
    }

}
