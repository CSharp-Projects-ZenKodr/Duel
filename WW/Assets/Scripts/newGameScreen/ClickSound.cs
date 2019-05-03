using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

//[RequireComponent(typeof(Button))]

public class ClickSound : MonoBehaviour
{
    public AudioClip sound;
    public AudioSource source;
    public void PlaySound()
    {
        source.PlayOneShot(sound);
    }
}
