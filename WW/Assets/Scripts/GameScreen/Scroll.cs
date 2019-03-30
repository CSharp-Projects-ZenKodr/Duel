using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    //THIS IS FOR THE CREATING SPELLS BEHAVIOR  

    List<GameObject> TilesAdded; //List of all the tiles present in (active/placed on) the scroll. //For Later 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ShowSymbol(string spellName)
    {//Activates the preset symbols on the scroll so they are visible.
        switch (spellName.ToLower())
        {
            case "ackh":
                this.transform.GetChild(0).gameObject.SetActive(true);
                break;
            case "di":
                this.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case "dir":
                this.transform.GetChild(2).gameObject.SetActive(true);
                break;
            case "floo":
                this.transform.GetChild(3).gameObject.SetActive(true);
                break;
            case "ri":
                this.transform.GetChild(4).gameObject.SetActive(true);
                break;
            case "rid":
                this.transform.GetChild(5).gameObject.SetActive(true);
                break;
            case "spa":
                this.transform.GetChild(6).gameObject.SetActive(true);
                break;
            case "waqu":
                this.transform.GetChild(7).gameObject.SetActive(true);
                break;
            default:
                Debug.Log("Spell::ShowSymbol(spellName) called with invalid argument");
                break;
        }
    }
}
