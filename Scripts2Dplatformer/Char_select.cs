using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Char_select : MonoBehaviour
{
    //public GameObject hero;
    //public GameObject babaYaga;

    public Image hero;
    public Sprite karou;
    public Sprite babaYaga;

    private int charactInt = 1;

    //private readonly string charSelected = "charSelected";

    private void Awake() 
    {
    }

    public void Next() 
    {
        switch (charactInt)
        {
            case 1:
                //PlayerPrefs.SetInt()
                hero.sprite = babaYaga;
                charactInt++;
                break;
            case 2:
                hero.sprite = karou;
                charactInt++;
                Loop();
                break;
            default:
                Loop();
                break;
        }
    }

    public void Previous()
    {
        switch (charactInt)
        {
            case 1:
                hero.sprite = babaYaga;
                charactInt--;
                break;
                Loop();
            case 2:
                hero.sprite = karou;
                charactInt--;
                break;
            default:
                Loop();
                break;
        }
    }

    private void Loop() 
    {
        if (charactInt >= 2)
        {
            charactInt = 1;
        }
        else 
        {
            charactInt = 2;
        }
    }

}
