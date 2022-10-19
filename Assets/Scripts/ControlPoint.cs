using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPoint : MonoBehaviour
{
    [SerializeField] private int OrderPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Runner"))
        {
            AutoProvisional ProvisionalCar = other.gameObject.GetComponent<AutoProvisional>();

            if (ProvisionalCar.ControlPointsReached <= OrderPoint)
            {
                ProvisionalCar.ControlPointsReached = OrderPoint;
            }
            
        }
    }
}
