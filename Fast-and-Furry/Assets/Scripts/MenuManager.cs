using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    #region Variables
    public GameObject soundManagerPrefab;
    public Button[] buttons;
    #endregion

    #region Unity callbacks
    private void Awake()
    {
        if (GameObject.Find("SoundManager(Clone)") == null)
            Instantiate(soundManagerPrefab);
    }
    private void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
            buttons[i].onClick.AddListener(() => SoundManager.sharedInstance.PlayButtonSnd());
    }
    #endregion
}
