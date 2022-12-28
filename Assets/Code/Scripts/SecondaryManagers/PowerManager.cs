using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager : MonoBehaviour
{
    private List<CrashObstacule> obstaculesList = new List<CrashObstacule>();
    [SerializeField] private int powerUpAmount;
    [SerializeField] private int powerDownAmount;

    void Start(){}

    /// <summary>
    ///  Remove all obstacule from list
    /// </summary>
    private void RemoveAllObstaculesFromList()
    {
        if (obstaculesList.Count > 0) obstaculesList.Clear();
    }

    /// <summary>
    /// Add all obstacule with the tag
    /// </summary>
    public void AddObstaculesToList()
    {
        RemoveAllObstaculesFromList();
        obstaculesList.AddRange(FindObjectsOfType<CrashObstacule>());
    }

    /// <summary>
    /// Give a random obstacule using Range method from Random class
    /// </summary>
    /// <returns></returns>
    private int GiveRandomObstacule()
    {
        return Random.Range(0, obstaculesList.Count - 1); ;
    }
    
    /// <summary>
    /// Add power up to obstacule
    /// </summary>

    public void AddPowerUp()
    {

        if (powerUpAmount == 0)
        {
            Debug.Log("No hay powerup asignados");
            return;
        }


        for (int e = 0; e < powerUpAmount; e++)
        {
            int obstaculeRandom = GiveRandomObstacule();

            obstaculesList[obstaculeRandom].ActivePoweUp = true;
            obstaculesList.RemoveAt(obstaculeRandom);
        }
    }

    /// <summary>
    /// Add power down to obstacule
    /// </summary>
    public void AddPowerDown()
    {

        if (powerDownAmount == 0)
        {
            Debug.Log("No hay powerdown asignados");
            return;
        }


        for (int e = 0; e < powerDownAmount; e++)
        {

            int obstaculeRandom = GiveRandomObstacule();
            obstaculesList[obstaculeRandom].ActivePowerDown = true;
            obstaculesList.RemoveAt(obstaculeRandom);
        }
    }

}
