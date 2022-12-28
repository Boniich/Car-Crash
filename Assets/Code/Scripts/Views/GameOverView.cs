using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverView : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI subTextOfGameOver;
    private Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowLostAllResistenceSubText()
    {
        if(PlayerController.sharedInstance.Resistence == 0)
        {
            subTextOfGameOver.text = "Resistence got to empty! Try again";
        }
        
    }

    public void ShowEndTimeSubText()
    {
        if (timer.GetEndTimer()){

            subTextOfGameOver.text = "Time is over! Try again";
        }
    }
}
