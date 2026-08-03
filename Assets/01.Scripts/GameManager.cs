using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private GameObject optionPanel;

    public event Action StageClear;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
           
        }
        DontDestroyOnLoad(gameObject);


        optionPanel = transform.Find("Option_Canvas").gameObject;
        optionPanel.SetActive(false);
    }

  

    private void Update()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            OptionPanel();
        }
    }

    public void SetOptionpanel(GameObject panel)
    {
        optionPanel = panel;
    }



    public void OptionPanel()
    {
        if (optionPanel == null)
            return;

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
        Debug.Log(optionPanel);

        if (optionPanel == null)
        {
            Debug.Log("optionPanel == null");
            return;
        }

        Time.timeScale = 1f;
        optionPanel.SetActive(false);
    }

    public void ReturnTitle()
    {
        if (SceneManager.GetActiveScene().name == "StartScene")
            return;

 
        optionPanel.SetActive(false);
        Time.timeScale = 1f;
        SoundManager.instance.ChangeBgm(BgmType.StartBgm);
        SceneManager.LoadScene("StartScene");
    }

    public void ClearStage()
    {
        StageClear?.Invoke();
        EndScene();
    }


    public void EndScene()
    {

        SceneManager.LoadScene("EndScene");
    }

   

   




}
