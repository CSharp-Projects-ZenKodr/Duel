using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject Rules;
    public GameObject MainMenu;
    public GameObject confirmQuit; //Quit confirmation scroll
    public GameObject Options;
    public GameObject RulesPart2;
    public GameObject RulesPart2Sub1;
    public GameObject RulesPart2Sub2;
    public GameObject RulesPart2Sub3;
    public GameObject RulesPart2Sub4;

    private void Start()
    {
        MainMenu.SetActive(true);   
    }

    private void Update()
    {
        if (MainMenu.activeSelf)
        {
            Rules.SetActive(false);
            confirmQuit.SetActive(false);
            Options.SetActive(false);
            RulesPart2.SetActive(false);
            RulesPart2Sub1.SetActive(false);
            RulesPart2Sub2.SetActive(false);
            RulesPart2Sub3.SetActive(false);
            RulesPart2Sub4.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        { //Exit dialogue on back button press.
            if (MainMenu.activeSelf)
            {
                youSureBro();
            }
            else
            {
                MainMenu.SetActive(true);
            }
        }
    }

    //Play
    public void play()
    {
        SceneManager.LoadScene(2);
    }

    //Guide
    public void roll()
    {  //Toggle the 'Guide' scroll
        MainMenu.SetActive(!MainMenu.activeSelf);
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
        if ( RulesPart2Sub1.activeSelf == true )
        {
            RulesPart2Sub1.SetActive(false);
        }
        else if ( RulesPart2Sub2.activeSelf == true)
        {
            RulesPart2Sub2.SetActive(false);
        }
        else if ( RulesPart2Sub3.activeSelf == true)
        {
            RulesPart2Sub3.SetActive(false);
        }
        else if ( RulesPart2Sub4.activeSelf == true)
        {
            RulesPart2Sub4.SetActive(false);
        }
        RulesPart2.SetActive(!RulesPart2.activeSelf);

    }


    //Options menu
    public void optionsMenu()
    {
        MainMenu.SetActive(!MainMenu.activeSelf);
        Options.SetActive(!Options.activeSelf);
    }

    //Quit game: 
    public void youSureBro()
    { //You sure you wanna quit, bro? Confirmation dialogue
        MainMenu.SetActive(false);
        confirmQuit.SetActive(true);
    }
    public void quitTheGame()
    {
        Application.Quit();
    }
    public void cancelQuit()
    {
        confirmQuit.SetActive(false);
        MainMenu.SetActive(true);
    }

}   
