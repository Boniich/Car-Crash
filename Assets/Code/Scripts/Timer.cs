using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float timerTime;
    private float initialTimerTime;
    public int minutes, seconds;
    private bool endTimer;
    private bool startTimer = true;
    private Color lastTeenSecondsColor = new Color(0.9333333f, 0.1176471f, 0.1176471f, 1f); //HEX: EE1E1E


    void Start()
    {
        initialTimerTime = timerTime;
    }

    /// <summary>
    /// return the state of endTimer that can deteriminate a game over
    /// </summary>
    /// <returns></returns>

    public bool GetEndTimer()
    {
        return endTimer;
    }

    /// <summary>
    /// Change the end of timer that can determinate a game over
    /// </summary>
    /// <param name="timerState"></param>

    private void SetEndTimer(bool timerState = false)
    {
        endTimer = timerState;
    }

    /// <summary>
    /// Restart the timer to play again
    /// </summary>

    public void RestartTimer()
    {
        SetEndTimer();
        timerTime = initialTimerTime;
        timerText.color = Color.white;
    }


    /// <summary>
    /// Start the corrutine of timer
    /// </summary>

    public void StartTimer()
    {
        startTimer = true;
        StartCoroutine(HandleTimer());
    }

    /// <summary>
    /// Pause timer when the state of game changes, states like pause or gameover
    /// </summary>
    public void PauseTimer()
    {
        startTimer = false;
        StopCoroutine(HandleTimer());
        
    }

    /// <summary>
    /// Handle the timer
    /// </summary>
    /// <returns></returns>
    private IEnumerator HandleTimer()
    {
        while (startTimer)
        {
            if (timerTime < 0) timerTime = 0;

            timerTime -= Time.deltaTime;
            minutes = (int)(timerTime / 60f);
            seconds = (int)(timerTime - minutes * 60f);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            if(timerTime >= 0 && timerTime <= 11)
            {

                timerText.color = lastTeenSecondsColor;

            }
            else if (timerTime <= 0)
            {
                startTimer = false;
                SetEndTimer(true);
            }

            yield return null;
        }
       
    }
}
