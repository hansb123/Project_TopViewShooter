using UnityEngine;

public class MonsterBaseState : IState
{
    protected Monster monster;
    protected MonsterStateMachine stateMachine;

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
