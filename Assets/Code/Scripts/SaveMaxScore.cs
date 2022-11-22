using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMaxScore
{

    private const string PREF_NAME = "maxScore";

    /// <summary>
    /// Check if the new score point obtained by player is higher than the old max score point
    /// </summary>
    /// <param name="points"> It get the score point obteined in the gameplay by player</param>

    public void SetMaxScoreValue(int points)
    {

        if (PlayerPrefs.GetInt(PREF_NAME) < points)
        {
            PlayerPrefs.SetInt(PREF_NAME, points);
        }
    }

    /// <summary>
    /// Convert the MaxScore value at String and return it
    /// </summary>
    /// <returns></returns>

    public string GetMaxScoreString()
    {
        return PlayerPrefs.GetInt(PREF_NAME).ToString();
    }

    /// <summary>
    /// Reset the maxScore
    /// </summary>

    public void ResetMaxScore()
    {
        PlayerPrefs.SetInt(PREF_NAME, 0);
    }
}
