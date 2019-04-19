using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeValueChanged : MonoBehaviour
{
    //Reffernce to audio
    private AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    { 
    }

    public void SetVolume(float vol)
    {
        audioSrc.volume = vol;
    }
}
