using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartControllerAlternative : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private TurboSystem _turboSystem;
    [SerializeField] private GameManager _manager;

    [SerializeField] private TypeRunners _runners => _manager._PlayerStats;
    
    [SerializeField] private float steerDirection;
    private float driftTime;
    [HideInInspector] public float currentSpeed = 0;
    private float realSpeed;//not the applied speed
    [SerializeField] private float steerAmount;
    
    public float maxSpeed; //max possible speed
    public float boostSpeed; //speed while boosting

    [SerializeField] private float outwardDriftForce;
    private bool driftLeft;
    private bool driftRight;

    public bool isSliding = false;
    private bool isGrounded;
    
    
    [SerializeField] private Rigidbody rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        maxSpeed = _runners.velocity;
    }


    private void FixedUpdate()
    {
        Drive();
        Steering();
        GroundNormalRotation();
        Drift();
    }


    private void Drive()
    {
        realSpeed = transform.InverseTransformDirection(rb.velocity).z; //real velocity before setting the value

        if (Input.GetKey(_inputManager.MovForward))
        {
            currentSpeed = Mathf.Lerp(currentSpeed, maxSpeed, Time.deltaTime * 0.5f); //lerp=(el valor de interpolacion, el valor al que quiero llegar, velocidad de interpolacion/aceleracion)
        }
        else if (Input.GetKey(_inputManager.MovReverse))
        {
            currentSpeed = Mathf.Lerp(currentSpeed, -maxSpeed / 1.75f, Time.deltaTime * 1f);
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0, Time.deltaTime * 1.5f);
        }

        Vector3 vel = transform.forward * currentSpeed;
        vel.y = rb.velocity.y; //gravity setting
        rb.velocity = vel;
    }

    private void Steering()
    {
        steerDirection = Input.GetAxisRaw("Horizontal");
        Vector3 steerDirVector; //se usa para la rotacion final del kart al doblar
        
        if (driftLeft && !driftRight) //drift a izq
        {
            steerDirection = Input.GetAxis("Horizontal") < 0 ? -1.5f : -0.5f;
            
            _turboSystem.GetTurbo();
            
            if (isGrounded)
            {
                rb.AddForce(transform.right * (outwardDriftForce * Time.deltaTime), ForceMode.Acceleration);
            }
        }
        else if (driftRight && !driftLeft) //drift a der
        {
            steerDirection = Input.GetAxis("Horizontal") > 0 ? 1.5f : 0.5f;
            _turboSystem.GetTurbo();
            if (isGrounded)
            {
                rb.AddForce(transform.right * (-outwardDriftForce * Time.deltaTime), ForceMode.Acceleration);
            }
        }
        
        //como la direccion del auto es mas fuerte al ir a velocidades mas bajas, ajustamos steerAmount en base a la velocidad real del kart y luego rotamos el kart sobre su eje con steerAmount
        // los numeros 4 y 1.5 pueden requerir ajustes segun la maniobrabilidad del kart

        if ((realSpeed > 30f))
        {
            steerAmount = realSpeed / 2.5f * steerDirection;
        }
        else if ((realSpeed <= 30f && realSpeed > 20f) || (realSpeed < -20f))
        {
            steerAmount = realSpeed / 2f * steerDirection;
        }
        else if ((realSpeed <= 20f && realSpeed > 10f) || (realSpeed < -10f && realSpeed >= -20f))
        {
            steerAmount = realSpeed * steerDirection;
        }
        else if ((realSpeed < 10f) || (realSpeed > -5f))
        {
            steerAmount = 0;
        }

        steerDirVector = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + steerAmount, transform.eulerAngles.z);

        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, steerDirVector, 1.5f * Time.deltaTime);
    }

    private void GroundNormalRotation()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 1f))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(transform.up * 2, hit.normal) * transform.rotation, 7.5f * Time.deltaTime);
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void Drift()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            if (steerDirection > 0)
            {
                driftRight = true;
                driftLeft = false;
            }
            else if (steerDirection < 0)
            {
                driftLeft = true;
                driftRight = false;
            }
        }

        if (!Input.GetKey(KeyCode.Space) || realSpeed < 35f) //aca podemos dar turbo luego terminar un derrape en base al tiempo de derrape (aun no implementado)
        {
            driftLeft = false;
            driftRight = false;
            isSliding = false;
        }
    }
}



/*if (Input.GetKey(KeyCode.Space) && isGrounded && currentSpeed > 35f && Input.GetAxis("Horizontal") != 0)
        {
            driftTime += Time.deltaTime;
        }*/