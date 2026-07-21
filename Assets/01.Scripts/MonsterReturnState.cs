using UnityEngine;
public class MonsterReturnState : MonsterBaseState
{
    public MonsterReturnState(Monster _monster, MonsterStateMachine _stateMachine) : base(_monster, _stateMachine) { }


    public override void Update()
    {
        Debug.Log("ReturnState 실행되는중 ");
    }

    public override void FixedUpdate()
    {
        monster.Return();
    }

}
