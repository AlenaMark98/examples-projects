using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Custom_player : MonoBehaviour
{
    public Image CustomHero;
    public Sprite sprite1;
    public Sprite sprite2;

    private void Awake()
    {
    }

    public void Hair()
    {
        PlayerPrefs.SetInt("Player", 0);
        CustomHero.sprite = sprite1;
        PlayerPrefs.Save();
    }

    public void HairAfter()
    {
        PlayerPrefs.SetInt("Player", 1);
        CustomHero.sprite = sprite2;
        PlayerPrefs.Save();
    }

    public void Bant()
    {
        PlayerPrefs.SetInt("Player", 2);
        CustomHero.sprite = sprite1;
        PlayerPrefs.Save();
    }

    public void BantAfter()
    {
        PlayerPrefs.SetInt("Player", 3);
        CustomHero.sprite = sprite2;
        PlayerPrefs.Save();
    }
}
