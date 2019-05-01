using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePouchFunctions : MonoBehaviour
{

    private Sprite unSelectedPouch;
    public Sprite selectedPouch;
    public GameState stateObject;
    private SpriteRenderer renderer;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        unSelectedPouch = renderer.sprite;
    }

    private void OnMouseDown()
    {
        if (!Controller.GamePaused && !Controller.TurnChanging && !Controller.GameOver)
        {
            stateObject.addTile();
            renderer.sprite = selectedPouch;
        }
        
    }
    private void OnMouseUp()
    {
        if (!Controller.GamePaused && !Controller.TurnChanging && !Controller.GameOver)
        {
            renderer.sprite = unSelectedPouch;
        }
    }
}
