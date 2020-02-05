using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ClickSound : MonoBehaviour
{
    public AudioClip sound;
    public AudioSource source;
    public void PlaySound()
    {
        source.PlayOneShot(sound);
    }
}
