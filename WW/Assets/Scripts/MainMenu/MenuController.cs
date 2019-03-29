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
    {//Toggle the 'Guide' scroll
        MainMenu.SetActive(!MainMenu.activeSelf);
        Rules.SetActive(!Rules.activeSelf);
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
