using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public static PopupManager sharedInstance;
    private GameObject resetMaxScorePopup;
    private GameObject successMaxScoreResetPopup;

    private GameObject startExitPopup;
    private GameObject winPlayerExitPopup;
    private GameObject pauseExitPopup;
    private GameObject gameOverPopup;

    private void Awake()
    {
        sharedInstance = this;
    }


    void Start()
    {
        startExitPopup = GameObject.FindGameObjectWithTag("StartExitPopup");
        winPlayerExitPopup = GameObject.FindGameObjectWithTag("WinExitPopup");
        pauseExitPopup = GameObject.FindGameObjectWithTag("PauseExitPopup");
        gameOverPopup = GameObject.FindGameObjectWithTag("GameOverExitPopup");


        resetMaxScorePopup = GameObject.FindGameObjectWithTag("ResetMaxScorePopup");
        successMaxScoreResetPopup = GameObject.FindGameObjectWithTag("SuccessMaxScoreReset");
    }

    /// <summary>
    /// Enabled and disabled popup window to reset max score
    /// </summary>

    public void ToggleMaxScoreResetWindow(bool toggle)
    {

        resetMaxScorePopup.GetComponent<Canvas>().enabled = toggle;
    }

    /// <summary>
    /// Close the succefull popup window when max score is reseted
    /// </summary>

    public void ToggleSuccefullResetWindow(bool toggle)
    {
        successMaxScoreResetPopup.GetComponent<Canvas>().enabled = toggle;
    }

    public void OpenStartExitPopup()
    {
        startExitPopup.GetComponent<Canvas>().enabled = true;
    }

    public void CloseStartExitPopup()
    {
        startExitPopup.GetComponent<Canvas>().enabled = false;
    }


    public void OpenWinExitPopup()
    {
        winPlayerExitPopup.GetComponent<Canvas>().enabled = true;
    }

    public void CloseWinExitPopup()
    {
        winPlayerExitPopup.GetComponent<Canvas>().enabled = false;
    }


    public void OpenPauseExitPopup()
    {
        pauseExitPopup.GetComponent<Canvas>().enabled = true;
    }

    public void ClosePauseExitPopup()
    {
        pauseExitPopup.GetComponent<Canvas>().enabled = false;
    }

    public bool ReturnPauseExitPopupState()
    {
        return pauseExitPopup.GetComponent<Canvas>().enabled;
    }


    public void OpenGameOverExitPopup()
    {
        gameOverPopup.GetComponent<Canvas>().enabled = true;
    }

    public void CloseGameOverExitPopup()
    {
        gameOverPopup.GetComponent<Canvas>().enabled = false;
    }
}
