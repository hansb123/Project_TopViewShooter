

public class MonsterAttackState : MonsterBaseState
{
    public MonsterAttackState(Monster _monster, MonsterStateMachine _stateMachine) : base(_monster, _stateMachine) { }


    public override void FixedUpdate()
    {
        monster.Attack();
    }
}
