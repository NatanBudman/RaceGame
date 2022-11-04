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
            if (other.GetComponent<KartPowerPickUp>())
            {
                KartPowerPickUp ProvisionalCar = other.gameObject.GetComponent<KartPowerPickUp>();
                
                            if (ProvisionalCar.ControlPointsReached <= OrderPoint && ProvisionalCar.ControlPointsReached + 1 ==  OrderPoint)
                            {
                                ProvisionalCar.ControlPointsReached = OrderPoint;
                            }
            }

            if (other.GetComponent<IAController>())
            {
                IAController Ia = other.GetComponent<IAController>();

                Ia._countPoint = OrderPoint;
                
            }
            
            
        }
    }
}
