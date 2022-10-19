using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPoint : MonoBehaviour
{
    [SerializeField] private int OrderPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Runner"))
        {
            AutoProvisional ProvisionalCar = other.gameObject.GetComponent<AutoProvisional>();

            if (ProvisionalCar.ControlPointsReached <= OrderPoint)
            {
                ProvisionalCar.ControlPointsReached = OrderPoint;
            }
            
        }
    }
}
