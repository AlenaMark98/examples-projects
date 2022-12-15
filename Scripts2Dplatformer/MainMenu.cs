using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void menuStart()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowPanelHelp(GameObject panelcross)
    {
        panelcross.SetActive(true);
        //Time.timeScale = 0f;
    }
    
    public void Cross(GameObject panelcross)
    {
        panelcross.SetActive(false);
        Time.timeScale = 1f;
    }

    public void menuExit()
    {
        Application.Quit();
    }

    //public void SetPlayer(int index)
    //{
    //    PlayerPrefs.SetInt("customPlayer", index);
    //    PlayerPrefs.Save();
    //}

}
