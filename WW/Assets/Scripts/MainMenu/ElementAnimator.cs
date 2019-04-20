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
        StartCoroutine(Flicker());
    }

    void FixedUpdate()
    {
        
    }

    IEnumerator Flicker()
    {
        if (!flickered)
        {
            yield return new WaitForSeconds(0.3f);
            Tile.sprite = highlightedSymbol;
            yield return new WaitForSeconds(0.1f);
            Tile.sprite = baseImage;
            yield return new WaitForSeconds(0.5f);
            Tile.sprite = highlightedSymbol;
            yield return new WaitForSeconds(0.1f);
            Tile.sprite = baseImage;
            yield return new WaitForSeconds(0.5f);
            Tile.sprite = highlightedSymbol;
            yield return new WaitForSeconds(0.4f);
            Tile.sprite = highlightedTile;
            flickered = true;
        }
           
    }
}
