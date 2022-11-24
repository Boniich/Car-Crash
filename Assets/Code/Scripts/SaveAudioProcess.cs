using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAudioProcess 
{
    private const string SCROLL_BACKGROUND_MUSIC = "scrollBackgroundMusic";
    
    /// <summary>
    /// Save the actual state of music
    /// </summary>
    /// <param name="backgroundMusicValue">a new value to save the new state</param>
    public void SaveScrollBackgroundMusic(float backgroundMusicValue)
    {
        PlayerPrefs.SetFloat(SCROLL_BACKGROUND_MUSIC, backgroundMusicValue);
    }

    /// <summary>
    /// Return the current state of music saved in the PlayerPref
    /// </summary>
    /// <returns></returns>

    public float LoadScrollBackgroundMusic()
    {
        return PlayerPrefs.GetFloat(SCROLL_BACKGROUND_MUSIC);
    }
}
