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
            KartPowerPickUp ProvisionalCar = other.gameObject.GetComponent<KartPowerPickUp>();

            if (ProvisionalCar.ControlPointsReached <= OrderPoint && ProvisionalCar.ControlPointsReached + 1 ==  OrderPoint)
            {
                ProvisionalCar.ControlPointsReached = OrderPoint;
            }
            
        }
    }
}
