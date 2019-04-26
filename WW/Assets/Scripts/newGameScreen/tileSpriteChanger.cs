using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Applied to Tiles

public class tileSpriteChanger : MonoBehaviour
{
    //Attributes
    public Sprite tileNormal;
    public Sprite tileSelected;
    private SpriteRenderer renderer;
    public static string selectedTile;

    //Properties
    public bool IsSelected { get; set; }

    //Functions
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = tileNormal;
        selectedTile = "none";
        IsSelected = false;
    }
    void Update()
    {
        if (IsSelected && selectedTile != name) { OnMouseDown(); }
        if (GetComponent<BoxCollider2D>().enabled == false)
        {
            renderer.sprite = tileSelected;
            GetComponent<tileSpriteChanger>().enabled = false; //Once object is inside the scroll, disable this script. 
        }
    }
    void FixedUpdate()
    {
        if (IsSelected && selectedTile != name)
        {
            selectedTile = name;
        }
    }
    
    private void Select()
    {
        renderer.sprite = tileSelected;
        selectedTile = name;
        IsSelected = true;
        if (ScrollClick.selectedScroll != "none" && GameState.tileTaken)
        {

            GameState.addToScroll(this.gameObject); //Static Function in the GameState script
        }
    }
    private void DeSelect()
    {
        renderer.sprite = tileNormal;
        selectedTile = "none";
        IsSelected = false;
    }
    
    private void OnMouseUp()
    {
        if (!Controller.paused)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            DeSelect();
        }
        
    }
    private void OnMouseDown()
    {
        if (!Controller.paused)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            Select();
        }
        
    }
}
