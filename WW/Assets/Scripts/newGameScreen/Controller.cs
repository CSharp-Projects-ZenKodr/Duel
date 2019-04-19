using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Applied to GameController object. 
//Controlls Quiting, and will control pausing.

public class Controller : MonoBehaviour
{
    public GameObject quitDialogue;
    
    void Start()
    {
        quitDialogue.SetActive(false);
        
        //disabling rotation
        Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = Screen.autorotateToPortraitUpsideDown = false; 
    }

    void Update()
    {// Update is called once per frame
        if (Input.GetKeyDown(KeyCode.Escape))
        { //Exit dialogue on back button press.
            quitDialogue.SetActive(!quitDialogue.activeSelf);
        }
    }

    public void CancelQuit()
    {
        quitDialogue.SetActive(false);
    }

    public void quit()
    {
        SceneManager.LoadScene(1);
    }
}
