using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRace : MonoBehaviour
{
    public int RacePosition;

    public int ControlPoints;
    public int auxPoints;

    

    private void Update()
    {
        if (auxPoints != ControlPoints)
        {
            
        }
    }

    public void AddControlPoint()
    {
        ControlPoints++;
    }
}
