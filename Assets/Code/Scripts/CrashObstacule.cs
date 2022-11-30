using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CrashObstacule : MonoBehaviour
{
   
     [SerializeField] private int obstaculePoints;
     [SerializeField] private TextMeshPro pointsLabel;
     public int damage;
     private int totalDamage = 0;


    public int ObstaculePoints { get { return obstaculePoints; } }
    public TextMeshPro PointsLabel { get { return pointsLabel; } }

    public int TotalDamage { get => totalDamage; set => totalDamage = value; }

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
        
        ReduceResistence();
        Destroy(gameObject);
        SpawnManager.sharedInstance.ObstaculeDiscount();
        GameManager.sharedInstance.GainPoints(ObstaculePoints);
        ViewInGame.sharedInstance.UpdateObstaculeCountText();
        ViewInGame.sharedInstance.UpdateResistenceCount();
        ViewInGame.sharedInstance.UpdateImpactDamage(TotalDamage);

    }

    public void ReduceResistence()
    {
        int resistence = PlayerController.sharedInstance.Resistence;
        int randomDamage = Random.Range(0, 3);
        TotalDamage = damage + randomDamage;

        if((resistence -= totalDamage) <= 0)
        {
            PlayerController.sharedInstance.Resistence = 0;
        }
        else
        {
            PlayerController.sharedInstance.Resistence -= TotalDamage;
        }
    }


}
