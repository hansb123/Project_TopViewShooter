using UnityEngine;

public class SceneEvent : MonoBehaviour
{
    //각 씬마다 씬을 관리하는 매니저를 두는건 비효율적(이미 게임매니저가 씬 이동로직은 가지고있지만,씬 이동의 트리거는 가지고있지않다.)
    //델리게이트 => 이벤트 발생 => 씬매니저에게 전달 하는 방식
    //특정 몬스터가 사망 => 이벤트발생 => 씬이동 하는 방식
    //마찬가지로 메인메뉴이동도 똑같이.
    //클릭 이벤트발생 => 전달 => 씬이동
    
    //그러면, 싱글톤?
    //씬이벤트를 게임매니저의 자식으로 ? 
    //멘토링 


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
