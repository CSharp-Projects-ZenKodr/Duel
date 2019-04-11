using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileSpriteChanger : MonoBehaviour
{
    public Sprite tileNormal;
    public Sprite tileSelected;
    public Sprite tileHideSymbol;
    public GameObject Information;

    private SpriteRenderer renderer; //Look at Start function
    private bool isHidden;
    public bool IsSelected { get; set; } 


    // Start is called before the first frame update
    void Start()
    {
        IsSelected = isHidden = false;
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = tileNormal;
        Information.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (!isHidden)
        {
            if (!IsSelected)
            {
                IsSelected = true;
                Information.SetActive(!Information.activeSelf);
                Select();
            }
            else
            {
                IsSelected = false;
                Information.SetActive(!Information.activeSelf);
                DeSelect();
            }
        }
    }

    /*public void TileClicked()
    {
        Information.SetActive(!Information.activeSelf);
    }*/

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
