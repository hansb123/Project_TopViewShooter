
public class MonsterAttackState : MonsterBaseState
{
    public MonsterAttackState(Monster _monster, MonsterStateMachine _stateMachine) : base(_monster, _stateMachine) { }



    public override void Enter()
    {
        monster.SpeedReset(); //속도 초기화 
     
       
    }

    public override void Update()
    {
        if (!monster.IsAttackEnd()) //공격이 끝나지 않았다면, 아무 행동 X 
            return;


        if(!monster.IsAttackRange()) //사거리 밖이라면 
        {
            stateMachine.ChangeState(stateMachine.traceState); //공격이 끝나고, 추적상태로 전환 
            return;

        }

        if(monster.CanAttack()) //내가 공격이 가능하다면
        {
            monster.Attack();  //공격 
        }



        //if(monster.IsAttackEnd())
        //{
           
        //}
    }
}
