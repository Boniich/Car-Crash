using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ViewEndOfGame : MonoBehaviour
{

    public static ViewEndOfGame sharedInstance;
    private SaveMaxScore maxScore = new SaveMaxScore();
    [SerializeField] private TextMeshProUGUI endScorePointText;
    [SerializeField] private TextMeshProUGUI maxScorePointText;
    // Start is called before the first frame update
    void Start()
    {
        sharedInstance = this;
    }

    /// <summary>
    /// Update the max score point in the view of endGame
    /// </summary>
    public void UpdateMaxScoreText()
    {
        maxScorePointText.text = maxScore.GetMaxScoreString();
    }
    /// <summary>
    /// Update the score point in the view of endGame
    /// </summary>
    public void UpdatePointsAtEndOfGame()
    {

        if (GameManager.sharedInstance.GetGameState() == GameState.endOfGame)
        {
            endScorePointText.text = GameManager.sharedInstance.GetPoints().ToString();
        }
    }
}
