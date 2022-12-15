using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameSetting : MonoBehaviour
{
    public Slider slider;
    public GameObject pause;

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Observing");
    }

    void Update()
    {
        AudioListener.volume = slider.value;
    }

    public void Mute()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
