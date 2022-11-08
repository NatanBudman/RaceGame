using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CareerGoal : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    public int TotalControlPoints;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Runner"))
        {
            if (other.GetComponent<KartPowerPickUp>())
            {
                KartPowerPickUp ProvisionalCar = other.gameObject.GetComponent<KartPowerPickUp>();
                
                if (ProvisionalCar.ControlPointsReached < TotalControlPoints) return;
                ProvisionalCar.ControlPointsReached = 0;
                            ProvisionalCar.TotalCrossFinishLine++;
            }

            if (other.GetComponent<IAController>())
            {
                if (other.GetComponent<IAController>()._countPoint >= other.GetComponent<IAController>().TotalPointControl )
                {
                    other.GetComponent<IAController>().TotalPlayerCrossFinishLine++;
                    other.GetComponent<IAController>().ChangeRute();
                    other.GetComponent<IAController>()._countPoint = 0;
                    return;
                }
            }

           
           
            
            
        }
    }
}
