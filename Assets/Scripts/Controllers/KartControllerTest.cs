using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartControllerTest : MonoBehaviour
{

    [SerializeField] private Rigidbody sphereRb;
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float turnSpeed;
    
    private float _forwardAmount;
    private float _currentSpeed;
    private float _turnAmount;

    private void Start()
    {
        sphereRb.transform.parent = null;
    }


    private void Update()
    {
        transform.position = sphereRb.transform.position;

        _forwardAmount = Input.GetAxis("Vertical");
        _turnAmount = Input.GetAxis("Horizontal");
        
        if (_forwardAmount != 0)
            Drive();
        else
            NoDrive();

        TurnHandler();
    }



    private void FixedUpdate()
    {
        sphereRb.AddForce(transform.forward * _currentSpeed, ForceMode.Acceleration);
    }

    private void TurnHandler()
    {
        float newRotatation = _turnAmount * turnSpeed * Time.deltaTime;
        transform.Rotate(0, newRotatation, 0, Space.World);
    }
    private void Drive()
    {
        _currentSpeed = _forwardAmount *= forwardSpeed;
    }
    
    private void NoDrive()
    {
        _currentSpeed = 0;
    }
    
}
