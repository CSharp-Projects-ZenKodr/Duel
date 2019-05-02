using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Applied to GameController object. 
//Controlls Quiting, and will control pausing.

public class Controller : MonoBehaviour
{
    //Attributes
    
    public GameObject PauseMenu;
    public GameObject Guide;
    public GameObject Options;
    public GameObject QuitDialog;
    public GameObject GameOverDialog;
    public GameObject TurnChangeDialog;
    public Text PlayerInfo;
    public static string Winner;
    public static bool GamePaused;
    public static bool TurnChanging;
    public static bool GameOver;
    private bool IronManIsAlive;
    private AudioSource audiosrc;

    //Functions
    private void Awake()
    {
        Time.timeScale = 1f; //default timescale = 1x 
        IronManIsAlive = true;
    }
    void Start()
    {
        TurnChangeDialog.SetActive(false);
        QuitDialog.SetActive(false);
        PauseMenu.SetActive(false);
        Options.SetActive(false);
        Guide.SetActive(false);
        GamePaused = false;
        TurnChanging = false;
        GameOver = false;
        Winner = "None";
        audiosrc = GetComponent<AudioSource>();

        //disabling rotation
        Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = Screen.autorotateToPortraitUpsideDown = false; 
    }
    void Update()
    {// Update is called once per frame
        if (TurnChanging)
        {
            PlayerInfoSet();
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !GameOver)
        {
            if (GamePaused)
            {
                if (QuitDialog.activeSelf)
                {
                    CancelQuit();
                }
                else if (Options.activeSelf)
                {
                    Options.SetActive(false);
                    PauseMenu.SetActive(true);
                }
                else if (Guide.activeSelf)
                {
                    GuideBackToPauseMenu();
                }
                else
                {
                    Resume();
                }
            }
            else { Pause(); }
        }
        if (GameOver && !GameOverDialog.activeSelf)
        {
            Endgame();
        }
    }

    void PlayerInfoSet()
    {
        string turn = GameState.getPlayerturn().ToString();
        PlayerInfo.text = "Player " + turn;
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        if (TurnChangeDialog.activeSelf)
        {
            TurnChangeDialog.SetActive(false);
        }
        Time.timeScale = 0f; //stop time
        GamePaused = true;
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        if (TurnChanging)
        {
            TurnChangeDialog.SetActive(true);
        }
        Time.timeScale = 1f; //Back to 1x timescale
        GamePaused = false;
    }

    public void PauseMenuOptions()
    {
        PauseMenu.SetActive(false);
        Options.SetActive(true);
    }

    public void SetVolume(float vol)
    {
        audiosrc.volume = vol;
    }

    public void TurnChangeTimer(int new_time)
    {
        TurnChangeDialog.GetComponent<EditText>().setTimer(new_time);
    }

    public void PauseMenuGuide()
    {
        Guide.SetActive(true);
        PauseMenu.SetActive(false);
    }

    public void GuideBackToPauseMenu()
    {
        Guide.GetComponent<GuideController>().ResetPage();
        Guide.SetActive(false);
        PauseMenu.SetActive(true);
    }

    public void PauseMenuQuit()
    {
        PauseMenu.SetActive(false);
        QuitDialog.SetActive(true);
    }

    public void CancelQuit()
    {
        QuitDialog.SetActive(false);
        PauseMenu.SetActive(true);
    }

    public void quit()
    {
        audiosrc.Stop();
        SceneManager.LoadScene(1);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("gameScreen");
    }

    public void Endgame()
    {
        GameOverDialog.SetActive(true);
        GameOverDialog.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = Winner + " won";

        TurnChangeDialog.SetActive(false);
        QuitDialog.SetActive(false);
        PauseMenu.SetActive(false);
        Options.SetActive(false);
        Guide.SetActive(false);
        GamePaused = false;
        TurnChanging = false;

        IronManIsAlive = false;
    }
}