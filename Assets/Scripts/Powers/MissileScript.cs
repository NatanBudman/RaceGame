using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    [HideInInspector]
    public GameObject OwnerGameObject;

    [SerializeField] private float vel;

    [SerializeField] private float TimeLife;
    private float currentLifeTime;

    [SerializeField] private Rigidbody _rb;
    
    // Update is called once per frame
    void Update()
    {
        currentLifeTime += Time.deltaTime;

        if (currentLifeTime >= TimeLife)
        {
            Destroy(this.gameObject);
        }
        
        transform.position += transform.forward * vel * Time.deltaTime;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Runner") && OwnerGameObject != other.gameObject)
        {
            other.GetComponent<KartPowerPickUp>().Slowed(true,1.5f,0);
            Destroy(this.gameObject);
            return;
        }
        else if (other.CompareTag("Item"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            return;

        }
        if (other.GetComponent<IAController>())
        {
            other.GetComponent<IAController>().Slowed(true,1.5f,0);
            Destroy(this.gameObject);
            return;

        }
        
    }
}
