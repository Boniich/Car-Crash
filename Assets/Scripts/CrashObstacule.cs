using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashObstacule : MonoBehaviour
{
    void HideObstacule()
    {
        this.GetComponent<MeshRenderer>().enabled = false;
        this.GetComponent<MeshCollider>().enabled = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
       
        if (collision.tag == "Player")
        {
            HideObstacule();
            Debug.Log("Has sumado 10 puntos");
        }
    }
}
