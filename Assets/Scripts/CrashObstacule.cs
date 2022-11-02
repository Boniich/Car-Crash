using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashObstacule : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {

        if (collision.tag == "Player")
        { 
            GameManager.sharedInstance.RemoveObstaculeFromList(gameObject);
            Destroy(gameObject);
            GameManager.sharedInstance.GainPoints();
        }
    }
}
