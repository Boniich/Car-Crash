using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points 
{
    private int gamePoints = 0;

    private int GamePoints { get => gamePoints; set => gamePoints = value; }


    /// <summary>
    /// Return the value of variable points
    /// </summary>
    /// <returns></returns>

    public int GetPoints()
    {
        return gamePoints;
    }

    /// <summary>
    /// Incress the score point in code
    /// </summary>
    /// <param name="pointsAmount">Recibe diferent value depedding to value of obstacule</param>
    public void GainPoints(int pointsAmount)
    {
        GamePoints += pointsAmount;
        ViewInGame.sharedInstance.UpdatePointLabel();

    }

    /// <summary>
    /// Reset the point for each gameplay
    /// </summary>

    public void ResetPoints()
    {
        GamePoints = 0;
        ViewInGame.sharedInstance.UpdatePointLabel();
    }
}
