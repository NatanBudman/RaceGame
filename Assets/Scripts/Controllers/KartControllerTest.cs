using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartControllerTest : MonoBehaviour
{

    [SerializeField] private Rigidbody sphereRb;
    [SerializeField] private float forwardSpeed;
    private float _forwardAmount;
    private float _currentSpeed;

    private void Start()
    {
        sphereRb.transform.parent = null;
    }


    private void Update()
    {
        transform.position = sphereRb.transform.position;

        _forwardAmount = Input.GetAxis("Vertical");

        if (_forwardAmount != 0)
            Drive();
    }


    private void FixedUpdate()
    {
        sphereRb.AddForce(transform.forward * _currentSpeed, ForceMode.Acceleration);
    }

    
    
    private void Drive()
    {
        _currentSpeed = _forwardAmount *= forwardSpeed;
    }
}
