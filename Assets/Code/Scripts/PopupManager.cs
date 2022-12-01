using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    private const string START_EXIT_POPUP = "START_EXIT_POPUP";
    private const string END_LEVEL_EXIT_POPUP = "END_LEVEL_EXIT_POPUP";
    private const string PAUSE_EXIT_POPUP = "PAUSE_EXIT_POPUP";
    private const string GAME_OVER_EXIT_POPUP = "GAME_OVER_EXIT_POPUP";

    public static PopupManager sharedInstance;
    private GameObject[] exitPopup;
    private GameObject resetMaxScorePopup;
    private GameObject successMaxScoreResetPopup;

    private void Awake()
    {
        sharedInstance = this;
    }


    void Start()
    {
        exitPopup = GameObject.FindGameObjectsWithTag("ExitPopup");
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
    /// Open exit popup to confir that player want to exit from game
    /// </summary>
    /// <param name="exitPopUpOrder">it is like id that is necessary to open the correct Exitpopup</param>

    public void OpenExitPopUp(string exitPopUpOrder)
    {
        HandleExitPopUp(exitPopUpOrder, true);
    }

    /// <summary>
    /// Close exit popup for when player decide not exit from game
    /// </summary>
    /// <param name="exitPopUpOrder">it is like id that is necessary to close the correct Exitpopup</param>

    public void CloseExitPopUp(string exitPopUpOrder)
    {
        HandleExitPopUp(exitPopUpOrder, false);
    }

    /// <summary>
    /// Handle which Exitpopup open with 'exitPopUpOrder' and in which state (open/close)
    /// </summary>
    /// <param name="exitPopUpOrder">it is like id that is necessary to close the correct Exitpopup</param>
    /// <param name="toggle">state that should be change the modal</param>

    private void HandleExitPopUp(string exitPopUpOrder, bool toggle)
    {

        if (exitPopUpOrder == START_EXIT_POPUP)
        {
            ChangeExitPopupState(0, toggle);
        }
        else if (exitPopUpOrder == END_LEVEL_EXIT_POPUP)
        {
            ChangeExitPopupState(2, toggle);
        }
        else if (exitPopUpOrder == PAUSE_EXIT_POPUP)
        {
            ChangeExitPopupState(3, toggle);
        }
        else if (exitPopUpOrder == GAME_OVER_EXIT_POPUP)
        {
            ChangeExitPopupState(4, toggle);
        }
    }

    /// <summary>
    /// Return the exit popup of pause menu to know if it is open when button is pressed
    /// </summary>
    /// <returns></returns>

    public bool ReturnPauseExitPopupState()
    {
        return exitPopup[3].GetComponent<Canvas>().enabled;
    }

    /// <summary>
    /// Change the state of each canvas of each gameObject that has the tag 'ExitPopup'
    /// </summary>
    /// <param name="arrayIndex">an index that correspond to an array that save the gameobject</param>
    /// <param name="toggle">state of current gameobject</param>

    private void ChangeExitPopupState(int arrayIndex, bool toggle)
    {
        exitPopup[arrayIndex].GetComponent<Canvas>().enabled = toggle;
    }

    /// <summary>
    /// Close the exit popup of pause menu
    /// </summary>

    public void ClosePauseExitPopupState()
    {
        ChangeExitPopupState(3, false);
    }
}
