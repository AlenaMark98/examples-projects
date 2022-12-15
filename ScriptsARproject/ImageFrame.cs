using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFrame : MonoBehaviour
{
    private Image img;
    [SerializeField] private List<Sprite> imageToPlace;

    void Start()
    {
        img = GetComponent<Image>();
    }

    public void ChangeImage(int indexBT)
    {
        img.sprite = imageToPlace[indexBT];
        img.color = new Color32(255, 255, 225, 255);

    }

}
