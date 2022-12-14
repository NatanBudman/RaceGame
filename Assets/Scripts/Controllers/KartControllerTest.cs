using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartControllerTest : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    private TypeRunners _stats => _gameManager._PlayerStats;

    [SerializeField] private Rigidbody sphereRb;
    [SerializeField] private LayerMask groundLayerMask;

    #region KartStats

      
    
        public float forwardSpeed;
        private float turnSpeed => _stats.TurnSpeed;

    #endregion

    
    private float _forwardAmount;
    private float _currentSpeed;
    private float _turnAmount;
    private bool _isGrounded; //opcional para que no doble en el piso sin moverse ni acelerar en el aire
    private float _vel;

    private void Awake()
    {
        forwardSpeed = _stats.velocity;
    }

    private void Start()
    {
        sphereRb.transform.parent = null;
        _gameManager = FindObjectOfType<GameManager>();
    }


    private void Update()
    {
        transform.position = sphereRb.transform.position;

        _forwardAmount = Input.GetAxis("Vertical");
        _turnAmount = Input.GetAxis("Horizontal");
        
        if (_forwardAmount != 0 && _isGrounded)
            Drive();
        else
            NoDrive();

        TurnHandler();
        GroundCheckAndNormalHandler();

    }
    private void FixedUpdate()
    {
        sphereRb.AddForce(transform.forward * _currentSpeed, ForceMode.Acceleration);
    }

    private void GroundCheckAndNormalHandler()
    {
        RaycastHit hit;
        
        _isGrounded = Physics.Raycast(transform.position, -transform.up, out hit, 1, groundLayerMask);
        
        transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation, 0.1f);
    }
    
    private void TurnHandler()
    {
        float newRotatation = _turnAmount * turnSpeed * Time.deltaTime;
        
        if(_currentSpeed > 0.1f || _currentSpeed < -0.1f)
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
