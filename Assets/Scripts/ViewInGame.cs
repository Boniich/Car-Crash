using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ViewInGame : MonoBehaviour
{
    public static ViewInGame sharedInstance;
    public TextMeshProUGUI scoreTextPoint;
    // Start is called before the first frame update

    private void Awake()
    {
        sharedInstance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePointLabel()
    {
        if(GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            scoreTextPoint.text = GameManager.sharedInstance.points.ToString();
        }
    }
}
