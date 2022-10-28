using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoProvisional : MonoBehaviour
{
    public LayerMask layerMask;
    //[SerializeField] private Transform kartModel;
    [SerializeField] private Transform kartNormal;
    
    [SerializeField] private Camera VehicleCamera;
    [SerializeField] private TypeRunners _stats;
    [SerializeField] private PowerRuletScript _ruletScript;
    public Rigidbody sphere;

    #region RaceData

        [Space] [Header("Race Parameter")] [Space]
        
        public int ControlPointsReached = 0;
        public int TotalCrossFinishLine = 0;

    #endregion

    #region Canvas

    [Space] [Header("Canvas")] [Space] 
    
    [SerializeField] private Text TotalPlayerCrossFinishLine;

    public bool isUseRulet = false;
    public bool isHasPower = false;
    
    #endregion

    #region PlayerStats

    public float Speed
    {
        get => _stats.velocity;
        set => value = Accel;
    }

    public float Accel => _stats.Acceleration;

    private float currentSpeed;
    private float rotate;
    private float currentRotate;
    [SerializeField] private float gravity;
    public float steering = 50f;
    #endregion
    
    void Start()
    {
        VehicleCamera.transform.LookAt(this.gameObject.transform);
    }

    private void Update()
    {
        //transform.position = sphere.transform.position - new Vector3(0, 0.2f, 0);
        
        currentSpeed = Mathf.SmoothStep(currentSpeed, Speed, Time.deltaTime * 12f); Speed = 0f;
        currentRotate = Mathf.Lerp(currentRotate, rotate, Time.deltaTime * 2f); rotate = 0f;

        if (Speed < 0)
        {
            Speed = 0;
        }
        
        UpdateUI();
        if (isUseRulet)
        {
            if (!isHasPower)
            {
                _ruletScript.isSpinRulet = true;
                isHasPower = true;
            }
            else
            {
                
            }

            isUseRulet = false;
        }
       
    }

    private void FixedUpdate()
    {
        sphere.AddForce(transform.right * currentSpeed, ForceMode.Acceleration);
        
        //Gravity
        sphere.AddForce(Vector3.down * gravity, ForceMode.Acceleration);
        
        //Steering
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, transform.eulerAngles.y + currentRotate, 0), Time.deltaTime * 5f);
        
        RaycastHit hitOn;
        RaycastHit hitNear;

        Physics.Raycast(transform.position + (transform.up*.1f), Vector3.down, out hitOn, 1.1f,layerMask);
        Physics.Raycast(transform.position + (transform.up * .1f)   , Vector3.down, out hitNear, 2.0f, layerMask);

        //Normal Rotation
        kartNormal.up = Vector3.Lerp(kartNormal.up, hitNear.normal, Time.deltaTime * 8.0f);
        kartNormal.Rotate(0, transform.eulerAngles.y, 0);
    }

    public void UpdateUI()
    {
        TotalPlayerCrossFinishLine.text = "" + TotalCrossFinishLine + "\n" + " /" + "\n" + "   3";
    }

    public void Move(KeyCode Forward, KeyCode Down, KeyCode left, KeyCode right)
    {
        
        if (Input.GetKey(Forward))
        {
            sphere.AddForce(transform.forward * currentSpeed ,ForceMode.Acceleration);
        }

        if (Input.GetKey((Down)))
        {
            sphere.AddForce(-transform.forward * currentSpeed ,ForceMode.Acceleration);
            
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            var dir = Input.GetAxis("Horizontal") > 0 ? 1 : -1;
            var amount = Mathf.Abs((Input.GetAxis("Horizontal")));
            Steer(dir, amount);
        }
    }

    public void Steer(int direction, float amount)
    {
        rotate = (steering * direction) * amount;
    }
    
    public void UsePower()
    {
        if (isHasPower && _ruletScript.StopSpin)
        {
            isHasPower = false;
            _ruletScript.isSpinRulet = false;
        }
    }
}
