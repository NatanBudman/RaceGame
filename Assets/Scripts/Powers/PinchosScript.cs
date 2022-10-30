using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchosScript : MonoBehaviour
{
    [SerializeField]
    private float VelSlowd = 50;

    [SerializeField] private KartPowerPickUp kart;

    [SerializeField] private float TimeSlowed = 0.5f;
    
   
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Runner"))
        {
            kart = other.GetComponent<KartPowerPickUp>();

            kart.Slowed(true,TimeSlowed,VelSlowd);

        }
    }

    private void OnCollisionExit(Collision other)
    {
        kart = null;
    }
}
