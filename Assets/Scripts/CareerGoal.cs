using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CareerGoal : MonoBehaviour
{
    public int TotalControlPoints;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Runner"))
        {
            AutoProvisional ProvisionalCar = other.gameObject.GetComponent<AutoProvisional>();

            if (ProvisionalCar.ControlPointsReached >= TotalControlPoints)
            {
                ProvisionalCar.ControlPointsReached = 0;
                ProvisionalCar.TotalCrossFinishLine++;
            }
            
        }
    }
}
