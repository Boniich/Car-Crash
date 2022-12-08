using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float timerTime;
    private float initialTimerTime;
    private int minutes, seconds;
    private bool endTimer;


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
        StartCoroutine(HandleTimer());
    }

    /// <summary>
    /// Handle the timer
    /// </summary>
    /// <returns></returns>
    private IEnumerator HandleTimer()
    {
        bool isTrue = true;
        while (isTrue)
        {
            if (timerTime < 0) timerTime = 0;

            timerTime -= Time.deltaTime;
            minutes = (int)(timerTime / 60f);
            seconds = (int)(timerTime - minutes * 60f);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            if(timerTime >= 0 && timerTime <= 11)
            {
                timerText.color = Color.red;

            }else if (timerTime <= 0)
            {
                isTrue = false;
                SetEndTimer(true);
            }

            yield return null;
        }
       
    }
}
