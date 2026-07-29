using UnityEngine;
using UnityEngine.InputSystem;
public class PauseUI : MonoBehaviour
{
   //TODO : 게임정지 만들기 
    private void Update()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            GameManager.instance.OptionPanel();
        }
    }
}
