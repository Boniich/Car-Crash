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


    /// <summary>
    /// Open exit pop in start UI
    /// </summary>
    public void OpenStartExitPopup()
    {
        startExitPopup.GetComponent<Canvas>().enabled = true;
    }

    /// <summary>
    /// Close exit pop in start UI
    /// </summary>

    public void CloseStartExitPopup()
    {
        startExitPopup.GetComponent<Canvas>().enabled = false;
    }

    /// <summary>
    /// Open exit pop in win player UI
    /// </summary>

    public void OpenWinExitPopup()
    {
        winPlayerExitPopup.GetComponent<Canvas>().enabled = true;
    }

    /// <summary>
    /// Close exit pop in win player UI
    /// </summary>

    public void CloseWinExitPopup()
    {
        winPlayerExitPopup.GetComponent<Canvas>().enabled = false;
    }

    /// <summary>
    /// Open exit pop in Pause UI
    /// </summary>

    public void OpenPauseExitPopup()
    {
        pauseExitPopup.GetComponent<Canvas>().enabled = true;
    }

    /// <summary>
    /// Close exit pop in Pause UI
    /// </summary>

    public void ClosePauseExitPopup()
    {
        pauseExitPopup.GetComponent<Canvas>().enabled = false;
    }

    /// <summary>
    /// Return state of popup to be able to escape with ESC button
    /// </summary>

    public bool ReturnPauseExitPopupState()
    {
        return pauseExitPopup.GetComponent<Canvas>().enabled;
    }

    /// <summary>
    /// Open exit pop in game over UI
    /// </summary>


    public void OpenGameOverExitPopup()
    {
        gameOverPopup.GetComponent<Canvas>().enabled = true;
    }

    /// <summary>
    /// Close exit pop in game over UI
    /// </summary>

    public void CloseGameOverExitPopup()
    {
        gameOverPopup.GetComponent<Canvas>().enabled = false;
    }
}
