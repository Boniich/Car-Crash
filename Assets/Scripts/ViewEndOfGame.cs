using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ViewEndOfGame : MonoBehaviour
{

    public static ViewEndOfGame sharedInstance;
    public TextMeshProUGUI endScorePointText;
    // Start is called before the first frame update
    void Start()
    {
        sharedInstance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePointsAtEndOfGame()
    {

        if (GameManager.sharedInstance.currentGameState == GameState.endOfGame)
        {


            endScorePointText.text = GameManager.sharedInstance.points.ToString();
        }
    }
}
