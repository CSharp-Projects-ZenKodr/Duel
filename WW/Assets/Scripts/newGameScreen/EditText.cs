using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditText : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Text countText;
    [SerializeField] private float mainTimer;

    private float timer;
    private bool canCount = true;
    private bool doOnce = false;


    // Update is called once per frame
    void Start()
    {
        timer = 3.00f;
    }
    void Update()
    {
        if ( timer >= 0.0f && canCount )
        {
            timer -= Time.deltaTime;
            countText.text = timer.ToString("F");
        }
        else if (timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            countText.text = "0.00";
            //timer = 3.0f;
        }

    }
}
