using UnityEngine;
using UnityEngine.SceneManagement;

public class In_Menu_Game : MonoBehaviour
{
    public void ShowMenu(GameObject menu)
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Next(GameObject next)
    {
        next.SetActive(false);
        Time.timeScale = 1f;
    }

    public void mainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void GameOver(GameObject gameOver)
    {
        gameOver.SetActive(true);
        Time.timeScale = 0f;
    }

    public void StartNew()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }

    public void StartNewLvl2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(3);
    }

    public void Cross(GameObject panelcross)
    {
        panelcross.SetActive(false);
        Time.timeScale = 1f;
    }
}
