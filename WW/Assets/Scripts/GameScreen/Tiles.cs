using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    public bool selected;
    public int player; 
    public Sprite SpriteSelected;
    public Sprite SpriteUnselected;
    public Sprite SpriteHiddden; //ADD THIS SPRITE ON ALL PREFABS! USE THE FLIPPEDTILE SPRITE 
    public string TileName;

    // Start is called before the first frame update
    void Start()
    {
        selected = false;
        //TileName = this.gameObject.name; //For Later 
    }

    public void OnMouseDown()
    {
        //to ensure enemy sprite is not clickable.
        if (GetComponent<SpriteRenderer>().sprite != SpriteHiddden)
        {
            Select();
        }
    }

    public void HideSymbol()
    { //Hide the tile symbol
        GetComponent<SpriteRenderer>().sprite = SpriteHiddden; 
    }

    public void ShowSymbol()
    {
        GetComponent<SpriteRenderer>().sprite = SpriteUnselected;
    }

    public void Select()
    {
        selected = !selected;
        if (selected == true)
        {
            GetComponent<SpriteRenderer>().sprite = SpriteSelected;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = SpriteUnselected;
        }
    }
}
