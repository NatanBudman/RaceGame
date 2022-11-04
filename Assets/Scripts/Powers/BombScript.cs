using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    float vel;

    private List<KartPowerPickUp>kart = new List<KartPowerPickUp>();

    [SerializeField] private GameObject Bomb; 

    [SerializeField] private float timeToReturnVel;

   [SerializeField] private float TimeLife;

   private float currenTime;
   
   public GameObject OwnerObject;

   [SerializeField] private float TimeOwnerObject;
   private float currentOwner;
   
   [SerializeField] private BoxCollider bombCollider;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (kart.Count > 0)
        {
            bombCollider.size = new Vector3(10, 10, 10);
            for (int i = 0; i < kart.Count + 1 ; i++)
            {
                if (i <= kart.Count - 1)
                {
                    bombCollider.size = new Vector3(10, 10, 10);
                    kart[i].Slowed(true,timeToReturnVel,0);
                }
                else
                {
                    DisableBomb();
                }
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
            bombCollider.size = new Vector3(1, 1, 1);
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
            bombCollider.size = new Vector3(10, 10, 10);
            if (other.GetComponent<KartPowerPickUp>())
            {
                kart.Add(other.GetComponent<KartPowerPickUp>());
                            Debug.Log(kart.Count);
            }else if (other.GetComponent<IAController>())
            {
                other.GetComponent<IAController>().Slowed(true,timeToReturnVel,0);
            }
            
        }
    }

    void DisableBomb()
    {
        Debug.Log("entre");
        for (int i = 0; i < kart.Count; i++)
        {
            kart.RemoveAt(i);
        }
    }
    

    private void OnTriggerExit(Collider other)
    {
        Bomb.SetActive(false);
    }
}
