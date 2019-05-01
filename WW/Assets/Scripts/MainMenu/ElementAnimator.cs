using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementAnimator : MonoBehaviour
{
    //Applied on Each subguide

    public Image Tile;
    public Sprite baseImage;
    public Sprite highlightedSymbol;
    public Sprite highlightedTile;
    bool flickered;

    void Start()
    {
        flickered = false;
        
    }

    void FixedUpdate()
    {
        if (!flickered)
        {
            StartCoroutine(Flicker());
        }
    }

    IEnumerator Flicker()
    {
        flickered = true;
        yield return new WaitForSeconds(0.3f);
        Tile.sprite = highlightedSymbol;
        yield return new WaitForSeconds(0.1f);
        Tile.sprite = baseImage;
        yield return new WaitForSeconds(0.2f);
        Tile.sprite = highlightedSymbol;
        yield return new WaitForSeconds(0.1f);
        Tile.sprite = baseImage;
        yield return new WaitForSeconds(0.2f);
        Tile.sprite = highlightedSymbol;
        yield return new WaitForSeconds(0.3f);
        Tile.sprite = highlightedTile;
    }

    public void ResetImage()
    {
        Tile.sprite = baseImage;
        flickered = false;
    }

}
