using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region Variables
    //Singleton
    public static SoundManager sharedInstance { get; private set; }
    #endregion

    #region Audio sources
    //Themes
    public AudioSource menuTheme_MUSIC;
    public AudioSource gameTheme_MUSIC;

    //Sounds
    public AudioSource victory_SND;
    public AudioSource defeat_SND;
    public AudioSource button_SND;
    public AudioSource countdown_SND;
    public AudioSource nya_SND;
    #endregion

    #region Sound management functions
    //Play themes
    public void PlayMenuTheme()
    {
        gameTheme_MUSIC.Pause();
        menuTheme_MUSIC.Play();
    }
    public void PlayGameTheme()
    {
        menuTheme_MUSIC.Pause();
        gameTheme_MUSIC.Play();
    }

    //Play sounds
    public void PlayButtonSnd() => button_SND.Play();
    public void PlayVictorySnd() => victory_SND.Play();
    public void PlayDefeatSnd() => defeat_SND.Play();
    public void PlayCountdownSnd() => countdown_SND.Play();
    public void PlayNyaSnd() => nya_SND.Play();
    #endregion

    #region Unity callbacks
    private void Awake()
    {
        if (sharedInstance == null)
            sharedInstance = this;
        DontDestroyOnLoad(this);
    }
    #endregion
}
