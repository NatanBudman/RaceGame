using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurboScript : MonoBehaviour
{
    [SerializeField] float addTurbo = 25;
    private float vel;

    private KartPowerPickUp kart;

    private IAController _iaController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Runner"))
        {
            if (other.GetComponent<TurboSystem>())
            {
                other.GetComponent<TurboSystem>().AddTurbo(addTurbo);
                return;
            }            
        }
    }
}
