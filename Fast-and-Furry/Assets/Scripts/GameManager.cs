using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Variables
    //Singleton
    public static GameManager sharedInstance { get; private set; }

    //References to other game objects
    [Header("UI Elements")]
    public Image darkBackground;
    public GameObject wannaLeaveMessage;

    //Management 
    [HideInInspector]
    public bool paused;
    #endregion

    #region Unity Callbacks
    void Awake()
    {
        if (sharedInstance == null)
            sharedInstance = this;
    }
    #endregion

    #region Game management functions
    public void PauseGame(bool pause)
    {
        paused = pause;
        darkBackground.gameObject.SetActive(pause);
        wannaLeaveMessage.SetActive(pause);
    }
    #endregion
}
