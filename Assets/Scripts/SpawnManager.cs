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
    private float spawnPosZ;
    public int obstaculeIndex;
    void Start()
    {
        spawnPosZ = transform.position.z;
        SpawnRandomObstacules();

    }

    // Update is called once per frame


    void SpawnRandomObstacules()
    {
        float xRand = Random.Range(-5, 15);

        Vector3 spawnPos = new Vector3(xRand, 0, spawnPosZ);

        obstaculeIndex = Random.Range(0, obstacules.Length);

        Instantiate(obstacules[obstaculeIndex], spawnPos, obstacules[obstaculeIndex].transform.rotation);
    }
}
