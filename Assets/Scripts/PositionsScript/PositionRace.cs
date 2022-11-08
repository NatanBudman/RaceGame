using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRace : MonoBehaviour
{
    public int RacePosition;

    public int ControlPoints;
    public int auxPoints;

    
    public int MetaCruzada;
    public int auxMetaCruzada;

    public int TotalPoitns;

    private void Update()
    {
        if (auxMetaCruzada != auxMetaCruzada || ControlPoints != auxPoints)
        {
            TotalPoitns = +((auxPoints - ControlPoints) + (auxMetaCruzada - MetaCruzada) );
            
            auxPoints = ControlPoints;
            auxMetaCruzada = MetaCruzada;
        }
    }
}
