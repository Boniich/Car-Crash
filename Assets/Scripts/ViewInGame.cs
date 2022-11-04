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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateObstaculeCountText()
    {
        obstaculeCountText.text = SpawnManager.sharedInstance.GetDestroyedObstaculeCount().ToString();
    }


    public void UpdatePointLabel()
    {

        if(GameManager.sharedInstance.currentGameState == GameState.inGame)
        {


            scoreTextPoint.text = GameManager.sharedInstance.points.ToString();
        }
    }
}
