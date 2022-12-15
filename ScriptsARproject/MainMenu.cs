using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject panelMainMenu;
    public GameObject panelImage;
    public GameObject panelVideo;
    public GameObject panelObject;

    [SerializeField] private GameObject videoPlayer;
    [SerializeField] private GameObject image;

    public void PanelMainMenu()
    {
        panelMainMenu.SetActive(true); 
    }

    public void PanelImage()
    {
        panelMainMenu.SetActive(false);
        panelImage.SetActive(true);

        image.SetActive(true);
    }

    public void PanelVideo()
    {
        panelMainMenu.SetActive(false);
        panelVideo.SetActive(true);

        videoPlayer.SetActive(true);
    }

    public void PanelObject()
    {
        panelMainMenu.SetActive(false);
        panelObject.SetActive(true);
    }

    public void Back()
    {
        panelImage.SetActive(false);
        panelVideo.SetActive(false);
        panelObject.SetActive(false);

        image.SetActive(false);
        videoPlayer.SetActive(false);

        panelMainMenu.SetActive(true);
    }
}
