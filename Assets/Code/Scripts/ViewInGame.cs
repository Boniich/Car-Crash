using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ViewInGame : MonoBehaviour
{
    public static ViewInGame sharedInstance;
    private SaveMaxScore maxScore = new SaveMaxScore();
    [SerializeField]  private TextMeshProUGUI scoreTextPoint;
    [SerializeField]  private TextMeshProUGUI maxScoreText;
    [SerializeField]  private TextMeshProUGUI obstaculeCountText;
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
        maxScoreText.text = maxScore.GetMaxScoreString();
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

        if(GameManager.sharedInstance.GetGameState() == GameState.inGame)
        {
            scoreTextPoint.text = GameManager.sharedInstance.GetPoints().ToString();
        }
    }
}
