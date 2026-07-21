using UnityEngine;
public interface IState
{
    public void Enter();
    public void Exit();
    public void Update();

}
public abstract class StateMachine
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

    
}
