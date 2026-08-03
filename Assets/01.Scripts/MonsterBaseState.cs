using UnityEngine;

public class MonsterBaseState : IState
{
    protected Monster monster;
    protected MonsterStateMachine stateMachine;

    // 모든 상태 => 몬스터객체, 상태 머신을 공통적으로 사용하는데, 부모클래스인 몬스터베이스스테이트의 생성자에서 이 두객체를 한번 전달받아 저장하도록 구현.  즉 
    //몬스터와 StateMachine.을 사용하기 위함 
    public MonsterBaseState(Monster _monster, MonsterStateMachine _stateMachine)

    {
        monster = _monster;
        stateMachine = _stateMachine;

    }

    public virtual void Enter()
    {
     

    }

    public virtual void Update()
    {


    }

    public virtual void FixedUpdate()
    {

    }


    public virtual void Exit()
    {


    }

  


}
