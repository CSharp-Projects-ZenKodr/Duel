using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Applied to GameController object. 
//Controlls Quiting, and will control pausing.

public class Controller : MonoBehaviour
{
    //Attributes
    public GameObject Rules;
    public GameObject RulesPart2;
    public GameObject RulesPart2Sub1;
    public GameObject RulesPart2Sub2;
    public GameObject RulesPart2Sub3;
    public GameObject RulesPart2Sub4;
    public GameObject quitDialogue;
    public GameObject PauseMenu;
    public GameObject Options;
    public static bool paused;
    private AudioSource audiosrc;

    //Functions
    private void Awake()
    {
        Time.timeScale = 1f; //default timescale = 1x 
    }
    void Start()
    {
        quitDialogue.SetActive(false);
        PauseMenu.SetActive(false);
        Options.SetActive(false);
        Rules.SetActive(false);
        RulesPart2.SetActive(false);
        RulesPart2Sub1.SetActive(false);
        RulesPart2Sub2.SetActive(false);
        RulesPart2Sub3.SetActive(false);
        RulesPart2Sub4.SetActive(false);
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

    //Guide Needs to be fixed. Not working properly. 
    public void PauseMenuGuide()
    {
        roll();
    }

    public void roll()
    {  //Toggle the 'Guide' scroll
        PauseMenu.SetActive(!PauseMenu.activeSelf);
        Rules.SetActive(!Rules.activeSelf);
    }

    public void rolldown()
    {
        //It will take you scroll screen 2
        Rules.SetActive(!Rules.activeSelf);
        RulesPart2.SetActive(!RulesPart2.activeSelf);
    }

    public void fireOptionClicked()
    {
        RulesPart2.SetActive(!RulesPart2.activeSelf);
        RulesPart2Sub1.SetActive(!RulesPart2Sub1.activeSelf);
    }

    public void boltOptionClicked()
    {
        RulesPart2.SetActive(!RulesPart2.activeSelf);
        RulesPart2Sub2.SetActive(!RulesPart2Sub2.activeSelf);
    }

    public void waterOptionClicked()
    {
        RulesPart2.SetActive(!RulesPart2.activeSelf);
        RulesPart2Sub3.SetActive(!RulesPart2Sub3.activeSelf);
    }

    public void earthOptionClicked()
    {
        RulesPart2.SetActive(!RulesPart2.activeSelf);
        RulesPart2Sub4.SetActive(!RulesPart2Sub4.activeSelf);
    }

    public void backToSub()
    {
        if (RulesPart2Sub1.activeSelf == true)
        {
            RulesPart2Sub1.SetActive(false);
        }
        else if (RulesPart2Sub2.activeSelf == true)
        {
            RulesPart2Sub2.SetActive(false);
        }
        else if (RulesPart2Sub3.activeSelf == true)
        {
            RulesPart2Sub3.SetActive(false);
        }
        else if (RulesPart2Sub4.activeSelf == true)
        {
            RulesPart2Sub4.SetActive(false);
        }
        RulesPart2.SetActive(!RulesPart2.activeSelf);

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
