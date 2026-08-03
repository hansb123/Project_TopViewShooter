using UnityEngine;
using UnityEngine.InputSystem;

public class EndScene : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        if (Keyboard.current.anyKey.wasPressedThisFrame)
            GameManager.instance.ReturnTitle();
    }
}
