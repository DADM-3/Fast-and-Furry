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
    public Text countdownText;
    public Image darkBackground;
    [Header("Pop Up Screens")]
    public GameObject wannaLeaveMessage;
    public GameObject winMessage;
    public GameObject loseMessage;
    [Header("Buttons")]
    public Button[] buttons;

    //Start countdown
    [HideInInspector]
    public bool countdownActive = true;
    private float countdown = 4;
    private bool countdownSoundPlaying;

    //Management 
    [HideInInspector]
    public bool paused;
    [HideInInspector]
    public bool gameOver;
    #endregion

    #region Unity Callbacks
    void Awake()
    {
        if (sharedInstance == null)
            sharedInstance = this;
    }

    private void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
            buttons[i].onClick.AddListener(() => SoundManager.sharedInstance.PlayButtonSnd());
    }
    private void Update()
    {
        if (paused) return;
        if ((int)countdown > 0)
        {
            countdownText.text = ((int)countdown).ToString();
            countdown -= Time.deltaTime;
            if (!countdownSoundPlaying)
                StartCoroutine(PlayCountdown());
        }
        else
        {
            countdownText.text = "GO!";
            countdownActive = false;
            StartCoroutine(HideCountdown());
        }
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

    #region Coroutines
    private IEnumerator HideCountdown()
    {
        yield return new WaitForSeconds(1f);
        countdownText.gameObject.SetActive(false);
    }

    private IEnumerator PlayCountdown()
    {
        countdownSoundPlaying = true;
        SoundManager.sharedInstance.PlayCountdownSnd();
        yield return new WaitForSeconds(.9f);
        countdownSoundPlaying = false;
    }
    #endregion
}
