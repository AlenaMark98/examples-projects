using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeAudio : MonoBehaviour
{
    GameObject[] pause;

    // Reference to Audio Source component
    private AudioSource audioSrc;

    // Music volume variable that will be modified
    // by dragging slider knob
    private float musicVolume = 1f;

    void Start()
    {
        // Assign Audio Source component to control it
        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Setting volume option of Audio Source to be equal to musicVolume
        audioSrc.volume = musicVolume;
    }

    // Method that is called by slider game object
    // This method takes vol value passed by slider
    // and sets it as musicValue
    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }

    public void Mute()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
