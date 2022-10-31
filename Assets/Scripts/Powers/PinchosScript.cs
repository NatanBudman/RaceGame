using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchosScript : MonoBehaviour
{
    [SerializeField]
    private float VelSlowd = 50;

    [SerializeField] private KartPowerPickUp kart;

    [HideInInspector] public GameObject OwnerObject;

    [SerializeField] private float TimeSlowed = 0.5f;

    [SerializeField] private float LifeTime;
    private float currentLife;


    [SerializeField] private float TimeOwnerObject;
    private float currentOwner;
    
    [SerializeField] private GameObject pincho;

    private void Update()
    {
        if (pincho.activeSelf)
        {
            currentLife += Time.deltaTime;

            if (currentLife >= LifeTime)
            {
                pincho.SetActive(false);
            }
        }
        else
        {
            currentLife = 0;
            OwnerObject = null;
        }

        if (OwnerObject != null)
        {
            currentOwner += Time.deltaTime;

            if (currentOwner >= TimeOwnerObject)
            {
                OwnerObject = null;
            }
        }
        else
        {
            currentOwner = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Runner") && other.gameObject != OwnerObject && pincho.activeSelf)
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
