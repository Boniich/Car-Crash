using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    //this spawn will be cover since 
    // y: 60 to 180
    // x: -5 to 25
    // Start is called before the first frame update

    public static SpawnManager sharedInstance;

    private int obstaculeIndex;
    [SerializeField] private int obstaculeCount = 7;
   
    [SerializeField] private GameObject[] obstacules;

    private float[] spawnRangeX = { -5, 25 };
    private float finalSpawnRangeY = 180;
    private float spawnPosZ;
    private int destroyObstaculeCount;


    void Awake()
    {
        sharedInstance = this;
        destroyObstaculeCount = obstaculeCount;
    }

    void Start()
    {
        spawnPosZ = transform.position.z;
    }


    /// <summary>
    ///  Discount count of obstacules for now when game is over
    /// </summary>
    public void ObstaculeDiscount()
    {
        destroyObstaculeCount--;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns> A count of obstacule destroyed </returns>

    public int GetDestroyedObstaculeCount()
    {
        return destroyObstaculeCount;
    }

    /// <summary>
    /// Reset the destroyed obstacule count for when the gameplay is reseted
    /// </summary>

    public void ResetDestroyedObstaculeCount()
    {
        if(destroyObstaculeCount == 0) destroyObstaculeCount = obstaculeCount;
    }

    /// <summary>
    /// Generate a number of random obstacule, in ramdom position on the road
    /// </summary>

    public void SpawnRandomObstacules()
    {
        float xRange = 0;
        float yRange = 0;

        for(int i = 0; i < obstaculeCount; i++)
        {

            if(i == 0)
            {
                yRange = spawnPosZ;

            } else if(i == obstaculeCount - 1)
            {
                yRange = finalSpawnRangeY;
            }
            else
            {
                yRange = Random.Range(spawnPosZ, finalSpawnRangeY);
            }

            xRange = Random.Range(spawnRangeX[0], spawnRangeX[1]);
            

            Vector3 spawnPos = new Vector3(xRange, 0, yRange);

            obstaculeIndex = Random.Range(0, obstacules.Length);

            Instantiate(obstacules[obstaculeIndex], spawnPos, obstacules[obstaculeIndex].transform.rotation);
        }

       
    }
}
