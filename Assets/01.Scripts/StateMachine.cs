using UnityEngine;
public interface IState //상태 
{
    public void Enter();
    public void Exit();
    public void Update();
    public void FixedUpdate();
}
public abstract class StateMachine //상태를 전환하고, 실행
{
    protected IState currentState;


    public void ChangeState(IState state)
    {
        currentState.Exit();   //현재 상태 종료, Exit 호출
        currentState = state;  //새 상태로 변경
        currentState.Enter();  // 새로운 상태 진입. Enter 호출 
    }

    public void Update() 
    {
        
        currentState?.Update();
    }  //현재상태의 Update 실행 

    public void FixedUpdate()
    {
        currentState?.FixedUpdate();
        //물리의 경우 FixedUpdate에서 해야하므로 
    }

    
}
