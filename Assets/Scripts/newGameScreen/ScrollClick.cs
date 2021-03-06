﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollClick : MonoBehaviour
{
    //Attributes
    public bool Selected;
    private Vector3 defaultScale;
    private Vector3 EnlargedScale;
    public static string selectedScroll; //name of the scroll (out of all the scrolls) that is selected.
    private SpriteRenderer scrollRenderer;
    private AudioSource clickSound;


    //Functions
    void Start()
    {
        Selected = false;
        selectedScroll = "none";
        transform.localScale = defaultScale;
        EnlargedScale = new Vector3(0.4F, 0.4F);
        defaultScale = new Vector3(0.18280F, 0.18280F);
        scrollRenderer = GetComponent<SpriteRenderer>();
        clickSound = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (selectedScroll != name)
        {
            transform.localScale = defaultScale;
            scrollRenderer.sortingOrder = 0;
            Selected = false;
        }
    }
    void FixedUpdate()
    {
        if (Selected)
        {
            selectedScroll = name;
        }
    }

    public void OnMouseDown()
    {
        if (!Controller.GamePaused && !Controller.TurnChanging && !Controller.GameOver && !GameState.tileAdded)
        {
            clickSound.Play();
            Selected = !Selected;
            if (Selected)
            {
                transform.localScale = EnlargedScale;
                scrollRenderer.sortingOrder = 2;
                selectedScroll = name;
            }
            else
            {
                transform.localScale = defaultScale;
                scrollRenderer.sortingOrder = 0;
                selectedScroll = "none";
            }
        }
        
    }
}
