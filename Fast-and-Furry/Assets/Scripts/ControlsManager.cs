using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ControlsManager : MonoBehaviour
{
    #region Variables
    public Button button;
    #endregion

    #region Unity callbacks
    private void Start()
    {
        button.onClick.AddListener(() => SoundManager.sharedInstance.PlayButtonSnd());
    }
    #endregion
}
