using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreensManager : MonoBehaviour
{
    #region Change scene functions
    public void GoToPlay()
    {
        SceneManager.LoadScene("Game_Scene");
    }

    public void GoToSettings()
    {
        SceneManager.LoadScene("Screen_00_0_LogIn");
    }

    public void Exit()
    {
        SceneManager.LoadScene("Screen_00_0_LogIn");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu_Scene");
    }
    #endregion
}
