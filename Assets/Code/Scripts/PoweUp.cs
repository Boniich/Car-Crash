using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoweUp
{
   
    /// <summary>
    /// Duplicate points of obstacule
    /// </summary>
    public int DuplicatePoints(int obstaculePoints)
    {
        int multiplier = 2;
        return obstaculePoints * multiplier;
    }
}
