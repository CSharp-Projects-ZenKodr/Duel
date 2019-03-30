using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    public bool selected;
    public Sprite SpriteSelected;
    public Sprite SpriteUnselected;

    // Start is called before the first frame update
    void Start()
    {
        selected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        Select();
    }

    public void Select()
    {
        Debug.Log("Select Called");
        selected = !selected;
        if (selected == true)
        {
            Debug.Log("Tile Selected");
            GetComponent<SpriteRenderer>().sprite = SpriteSelected;
        }
        else
        {
            Debug.Log("Tile DeSelected");
            GetComponent<SpriteRenderer>().sprite = SpriteUnselected;

        }
    }
}
