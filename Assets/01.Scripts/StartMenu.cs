using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        //게임시작 
        SoundManager.instance.ChangeBgm(BgmType.GameBgm);
        SceneManager.LoadScene("MainScene");
    }

    public void OpenOption()
    {
        GameManager.instance.OptionPanel();
    }


public void ExitGame()
    {

        Application.Quit();
    }


}