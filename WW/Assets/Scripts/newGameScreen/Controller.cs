using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Applied to GameController object. 
//Controlls Quiting, and will control pausing.

public class Controller : MonoBehaviour
{
    public GameObject quitDialogue;
    public GameObject PauseMenu;
    public GameObject Options;
    public static bool paused;
    private AudioSource audiosrc;

    private void Awake()
    {
        Time.timeScale = 1f; //default timescale = 1x 
    }

    void Start()
    {
        quitDialogue.SetActive(false);
        PauseMenu.SetActive(false);
        Options.SetActive(false);
        paused = false;
        audiosrc = GetComponent<AudioSource>();

        //disabling rotation
        Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = Screen.autorotateToPortraitUpsideDown = false; 
    }

    void Update()
    {// Update is called once per frame
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                if (quitDialogue.activeSelf)
                {
                    CancelQuit();
                }
                else if (Options.activeSelf)
                {
                    Options.SetActive(false);
                    PauseMenu.SetActive(true);
                }

                else
                {
                    Resume();
                }
            }
            else { Pause(); }
        }
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f; //stop time
        paused = true;
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f; //Back to 1x timescale
        paused = false;
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

    public void PauseMenuGuide()
    {
        //Create Tutorial
        Debug.Log("PauseMenuGuide called by pressing Guide button. ");
    }

    public void PauseMenuQuit()
    {
        PauseMenu.SetActive(false);
        quitDialogue.SetActive(true);
    }

    public void CancelQuit()
    {
        quitDialogue.SetActive(false);
        PauseMenu.SetActive(true);
    }

    public void quit()
    {
        audiosrc.Stop();
        SceneManager.LoadScene(1);
    }
    
}
