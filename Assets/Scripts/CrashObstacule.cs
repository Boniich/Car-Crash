using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CrashObstacule : MonoBehaviour
{
   
     [SerializeField] private int obstaculePoints;
     [SerializeField] private TextMeshPro pointsLabel;


    public int ObstaculePoints { get { return obstaculePoints; } }
    public TextMeshPro PointsLabel { get { return pointsLabel; } }

    private void Start()
    {
        PointsLabel.text = ObstaculePoints.ToString();
        PointsLabel.enabled = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
    
        if (collision.tag == "Player")
        { 
            PointsLabel.enabled = true;
            Invoke("DestroyObject", 0.5f);
        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
        SpawnManager.sharedInstance.ObstaculeDiscount();
        GameManager.sharedInstance.GainPoints(ObstaculePoints);
        ViewInGame.sharedInstance.UpdateObstaculeCountText();
    }


}
