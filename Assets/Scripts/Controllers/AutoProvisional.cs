using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoProvisional : MonoBehaviour
{
    [SerializeField] private Camera VehicleCamera;
    [SerializeField] private TypeRunners _stats;
    [SerializeField] private PowerRuletScript _ruletScript;

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

    public float Speed => _stats.velocity;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        VehicleCamera.transform.LookAt(this.gameObject.transform);
    }

    private void Update()
    {
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

    public void UpdateUI()
    {
        TotalPlayerCrossFinishLine.text = "" + TotalCrossFinishLine + "\n" + " /" + "\n" + "   3";
    }

    public void Move(KeyCode Forward, KeyCode Down, KeyCode left, KeyCode right)
    {
        if (Input.GetKey(Forward))
        {
            transform.position += Vector3.forward * Speed * Time.deltaTime;
        }
        if (Input.GetKey(Down))
        {
            transform.position -= Vector3.forward * Speed * Time.deltaTime;
        }
        if (Input.GetKey(left))
        {
            transform.position += Vector3.left * Speed * Time.deltaTime;
        }
        if (Input.GetKey(right))
        {
            transform.position += Vector3.right * Speed * Time.deltaTime;
        }
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
