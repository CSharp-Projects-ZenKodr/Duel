using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileSpriteChanger : MonoBehaviour
{
    public Sprite tileNormal;
    public Sprite tileSelected;
    public Sprite tileHideSymbol;

    private SpriteRenderer renderer; //Look at Start function
    private bool isHidden;
    public bool IsSelected { get; set; }

    public static string selectedTile;

    // Start is called before the first frame update
    void Start()
    {
        IsSelected = isHidden = false;
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = tileNormal;
        selectedTile = "None";
    }

    // Update is called once per frame
    void Update()
    {
        if (IsSelected && selectedTile != name)
        {
            OnMouseDown();
        }

    }

    private void OnMouseDown()
    {
        if (!isHidden)
        {
            if (!IsSelected)
            {
                IsSelected = true;
                selectedTile = name;
                transform.GetChild(0).gameObject.SetActive(true);
                Select();
            }
            else
            {
                IsSelected = false;
                transform.GetChild(0).gameObject.SetActive(false);
                DeSelect();
            }
        }
    }


    public void HideFace()
    {
        renderer.sprite = tileHideSymbol;
        isHidden = true;
        IsSelected = false;
    }
    public void Select()
    {
        renderer.sprite = tileSelected;
        IsSelected = true;
    }
    public void DeSelect()
    {
        renderer.sprite = tileNormal;
        IsSelected = false;
    }

}
