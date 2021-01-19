using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreensManager : MonoBehaviour
{
    #region Change scene functions
    public void GoToMainMenu()
    {
        SoundManager.sharedInstance.PlayMenuTheme();
        SceneManager.LoadScene("MainMenu_Scene");
    }

    public void GoToPlay()
    {
        SoundManager.sharedInstance.PlayGameTheme();
        SceneManager.LoadScene("Game_Scene");
    }

    public void GoToControls()
    {
        SceneManager.LoadScene("Controls_Scene");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void GoToURL(string url)
    {
        Application.OpenURL(url);
    }
    #endregion
}
