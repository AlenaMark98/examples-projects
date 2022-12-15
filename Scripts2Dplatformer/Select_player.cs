using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Select_player : MonoBehaviour
{
    public Image Znak;
    public Sprite Karou1;
    public Sprite Karou2;
    public Sprite BY3;
    public Sprite BY4;

    public Sprite karou; //= Resources.Load<Sprite>("Assets/Sprites/hero/hero_static1/Armature_animtion0_00.png");
    public Sprite karou2;
    public Sprite babaYaga;// = Resources.Load<Sprite>("Assets/Sprites/babaYaga/by_static/BY_static0_00 (1).png");
    public Sprite babaYaga2;

    public RuntimeAnimatorController karouC;
    public RuntimeAnimatorController karouC2;
    public RuntimeAnimatorController babaYagaC;
    public RuntimeAnimatorController babaYagaC2;

    private SpriteRenderer mainSprite;
    private Animator mainAnimator;

    private void Awake()
    {
        mainSprite = GetComponent<SpriteRenderer>();
        mainAnimator = GetComponent<Animator>();

    }

    private void Start()
    {
        int getChar;
        getChar = PlayerPrefs.GetInt("Player");

        switch (getChar)
        {
            case 0:
                Znak.sprite = Karou1;
                mainSprite.sprite = karou;
                mainAnimator.runtimeAnimatorController = karouC; //Resources.Load("Assets/Animation/Hero.controller") as RuntimeAnimatorController;
                break;
            case 1:
                Znak.sprite = Karou2;
                mainSprite.sprite = karou2;
                mainAnimator.runtimeAnimatorController = karouC2;
                break;
            case 2:
                Znak.sprite = BY3;
                mainSprite.sprite = babaYaga;
                mainAnimator.runtimeAnimatorController = babaYagaC; //Resources.Load("Assets/Animation/babaYaga.controller") as RuntimeAnimatorController;
                break;
            case 3:
                Znak.sprite = BY4;
                mainSprite.sprite = babaYaga2;
                mainAnimator.runtimeAnimatorController = babaYagaC2; //Resources.Load("Assets/Animation/babaYaga.controller") as RuntimeAnimatorController;
                break;

            default:
                mainSprite.sprite = karou;
                mainAnimator.runtimeAnimatorController = karouC; //Resources.Load("Assets/Animation/Hero.controller") as RuntimeAnimatorController;
                break;
        }
    }
}
