using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    //this spawn will be cover since 
    // y: 60 to 180
    // x: -5 to 25
    // Start is called before the first frame update
    public GameObject[] obstacules;
    private float[] spawnRangeX = { -5, 25 };
    private float finalSpawnRangeY = 180;
    private float spawnPosZ;
    public int obstaculeIndex;
    void Start()
    {
        spawnPosZ = transform.position.z;
        for(int i = 0; i < 7; i++)
        {
            SpawnRandomObstacules();
        }
        

    }

    // Update is called once per frame


    void SpawnRandomObstacules()
    {
        float xRand = Random.Range(spawnRangeX[0], spawnRangeX[1]);
        float yRand = Random.Range(spawnPosZ, finalSpawnRangeY);

        Vector3 spawnPos = new Vector3(xRand, 0, yRand);

        obstaculeIndex = Random.Range(0, obstacules.Length);

        Instantiate(obstacules[obstaculeIndex], spawnPos, obstacules[obstaculeIndex].transform.rotation);
    }
}
