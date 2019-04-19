using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePouchFunctions : MonoBehaviour
{

    private Sprite unSelectedPouch;
    public Sprite selectedPouch;

    private SpriteRenderer renderer;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        unSelectedPouch = renderer.sprite;
    }


    private void OnMouseDown()
    {
        renderer.sprite = selectedPouch;
    }
    private void OnMouseUp()
    {
        renderer.sprite = unSelectedPouch;
    }
}
