using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ViewInGame : MonoBehaviour
{
    public static ViewInGame sharedInstance;
    public TextMeshProUGUI scoreTextPoint;
    public TextMeshProUGUI maxScoreText;
    public TextMeshProUGUI obstaculeCountText;
    // Start is called before the first frame update

    private void Awake()
    {
        sharedInstance = this;
    }

    /// <summary>
    /// Update the max score point in the view of inGame
    /// </summary>
    public void UpdateMaxScoreText()
    {
        maxScoreText.text = PlayerPrefs.GetInt("maxScore").ToString();
    }

    /// <summary>
    /// Check if the new score point obtained by player is higher than the old max score point
    /// </summary>
    /// <param name="points"> It get the score point obteined in the gameplay by player</param>

    public void SetMaxScoreText(int points)
    {

        if(PlayerPrefs.GetInt("maxScore") < points)
        {
           PlayerPrefs.SetInt("maxScore", points);
        }
    }

    /// <summary>
    /// It show the obstacule that player has to destroy. Each time that she destroy one it is updated
    /// </summary>

    public void UpdateObstaculeCountText()
    {
        obstaculeCountText.text = SpawnManager.sharedInstance.GetDestroyedObstaculeCount().ToString();
    }

    /// <summary>
    /// Update the score points
    /// </summary>

    public void UpdatePointLabel()
    {

        if(GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            scoreTextPoint.text = GameManager.sharedInstance.points.ToString();
        }
    }
}
