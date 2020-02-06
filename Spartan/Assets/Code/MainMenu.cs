using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayFirstLevel()
    {
        SceneManager.LoadScene("Forest");
    }
    public void PlaySecondLevel()
    {
        SceneManager.LoadScene("Hades");
    }
    public void PlayThirdLevel()
    {
        SceneManager.LoadScene("Titan");
    }
    public void MainMenuOnPause()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
