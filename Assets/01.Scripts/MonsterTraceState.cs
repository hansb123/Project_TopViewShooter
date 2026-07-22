using UnityEngine;
public class MonsterTraceState : MonsterBaseState
{
    public MonsterTraceState(Monster _monster, MonsterStateMachine _stateMachine) : base(_monster, _stateMachine) { }


    public override void Enter() 
    {
       // monster.SpeedReset();
    }


    public override void Update()
    {
        if(monster.CanSeePlayer())
        {
            monster.RestSightTimer(); //시간 초기화 

            if(monster.IsAttackRange())//공격사거리가 된다면 
            {
                stateMachine.ChangeState(stateMachine.attackState);
            }

            return;
            
        }


        if(monster.IsSightTimeOver()) //시야를 놓쳤을때, 
        {
            stateMachine.ChangeState(stateMachine.returnState);
        }

   
    }

    public override void FixedUpdate()
    {
        monster.Trace();
    }

}
