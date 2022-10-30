using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    float vel;

    private KartControllerTest kart;

    [SerializeField] private GameObject Bomb; 

    [SerializeField] private float timeToReturnVel;

   float currentRetunrVel;

   [SerializeField] private float TimeLife;

   private float currenTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (kart == null)
        {
             currentRetunrVel = 0;
        }
        
        if (kart != null)
        {
            currentRetunrVel += Time.deltaTime;
            if (currentRetunrVel >= timeToReturnVel)
            {
                kart.forwardSpeed = vel;

                kart = null;
                
            }
        }

        if (Bomb.activeSelf)
        {
            currenTime += Time.deltaTime;

            if (currenTime >= TimeLife )
            {
                Bomb.SetActive(false);
            }
        }
        else
        {
            currenTime = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Runner") && Bomb.activeSelf)
        {
            Debug.Log("entre");
            kart = other.GetComponent<KartControllerTest>();

            vel = kart.forwardSpeed;

            kart.forwardSpeed = 0;
            Debug.Log(kart.forwardSpeed);
            
            Bomb.SetActive(false);

        }
    }

}
