using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollClick : MonoBehaviour
{
    public GameObject enlargedPosition;
    private Vector3 defaultPosition;
    private SpriteRenderer scrollRenderer;
    private Vector3 defaultScale;
    private Vector3 EnlargedScale;


    private static string selectedScroll; //name of the scroll that is currently selected. representing which scroll of the 3 is selected.



    public bool Selected; //represents if the scroll has been selected and is enlarged

    void Start()
    {
        defaultScale = new Vector3(0.18280F, 0.18280F);
        EnlargedScale = new Vector3(0.4F, 0.4F);
        defaultPosition = gameObject.transform.position;
        Selected = false;
        scrollRenderer = GetComponent<SpriteRenderer>();
        selectedScroll = "None";
    }

    private void Update()
    {
        if (Selected && selectedScroll != name)
        {
            OnMouseDown();
        }
    }

    private void OnMouseDown()
    {
        if (!Selected)
        {
            transform.position = enlargedPosition.transform.position;
            transform.localScale = EnlargedScale;
            scrollRenderer.sortingOrder = 2;
            selectedScroll = name;
        }
        else
        {
            transform.position = defaultPosition;
            transform.localScale = defaultScale;
            scrollRenderer.sortingOrder = 0;
        }
        Selected = !Selected;
    }
}
