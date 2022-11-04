using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashObstacule : MonoBehaviour
{
    public static CrashObstacule sharedInstance;

    public int obstaculePoints;
     void Awake()
    {
        sharedInstance = this;    
    }

    private void OnTriggerEnter(Collider collision)
    {
    
        if (collision.tag == "Player")
        { 
            Destroy(gameObject);
            SpawnManager.sharedInstance.ObstaculeDiscount();
            GameManager.sharedInstance.GainPoints(obstaculePoints);
          
        }
    }
}
