using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurboScript : MonoBehaviour
{
    [SerializeField] float addTurbo = 25;
    private float vel;

    private KartPowerPickUp kart;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Runner"))
        {
            kart = other.GetComponent<KartPowerPickUp>();

            kart.GetTurbo(addTurbo);

            kart = null;
        }
    }
}
