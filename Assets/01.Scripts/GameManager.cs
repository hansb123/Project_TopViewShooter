using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] GameObject optionPanel;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
           
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            OptionPanel();
        }
    }


    public void StartGame()
    {
        //게임시작 
        SoundManager.instance.ChangeBgm(BgmType.GameBgm);
        SceneManager.LoadScene("MainScene");
    }

    public void OptionPanel()
    {
        if(SceneManager.GetActiveScene().name == "StartScene")
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }

            optionPanel.SetActive(true);
    }

    public void CloseOption()
    {
        Time.timeScale = 1f;
        optionPanel.SetActive(false);
    }

    public void ReturnTitle()
    {
        if (SceneManager.GetActiveScene().name == "StartScene")
            return;

        SceneManager.LoadScene("StartScene");
    }

    public void ExitGame()
    {
       
        Application.Quit();
    }




}
