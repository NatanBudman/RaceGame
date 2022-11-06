using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    float vel;

    [SerializeField] private GameObject Bomb; 

    [SerializeField] private float timeToReturnVel;

   [SerializeField] private float TimeLife;

   private float currenTime;
   
   public GameObject OwnerObject;

   [SerializeField] private float TimeOwnerObject;
   private float currentOwner;
    
    void Update()
    {
        
        
        if (Bomb.activeSelf)
        {
            currenTime += Time.deltaTime;

            if (currenTime >= TimeLife )
            {
                Destroy(this);
            }
        }
        else
        {
            currenTime = 0;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Runner") && Bomb.activeSelf && OwnerObject != other.gameObject)
        {
            if (other.GetComponent<KartPowerPickUp>())
            {
                other.GetComponent<KartPowerPickUp>().Slowed(true,timeToReturnVel,0);
                Destroy(this);
                return;
            } 
            if (other.GetComponent<IAController>() && Bomb.activeSelf && OwnerObject != other.gameObject)
            {
                other.GetComponent<IAController>().Slowed(true,timeToReturnVel,0);
                Destroy(this);
                return;
            }
            
        }
    }
    
}
