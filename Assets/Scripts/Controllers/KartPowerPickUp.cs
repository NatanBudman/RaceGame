using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KartPowerPickUp : MonoBehaviour
{
    [SerializeField] private PowerRuletScript _ruletScript;
    [SerializeField] private KartControllerTest kart;

    #region RaceData

        [Space] [Header("Race Parameter")] [Space]
        
        public int ControlPointsReached = 0;
        public int TotalCrossFinishLine = 0;

    #endregion

    #region Canvas

    [Space] [Header("Canvas")] [Space] 
    
    [SerializeField] private Text TotalPlayerCrossFinishLine;

    [SerializeField] private Image TurboBar;

    public bool isUseRulet = false;
    public bool isHasPower = false;
    
    #endregion

    #region KartStats

    private float _turboBarAmount = 100;

    public float TurboAmount = 0;
    [SerializeField] private float TurboForce = 195;
    private float BaseKarVel;
    
    #endregion


    private bool isUseTurbo;
    private bool isSlowed;

    private float TimeSlowed;
    private float VelSlowed ;
    
    void Start()
    {
        kart.GetComponent<KartControllerTest>();
        
        BaseKarVel = kart.forwardSpeed;
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
         

            isUseRulet = false;
        }

        if (isUseTurbo)
        {
            if (TurboAmount >= 1)
            {
                TurboAmount -= 10 * Time.deltaTime;

                kart.forwardSpeed = TurboForce;
            }
            else
            {
                isUseTurbo = false;
                kart.forwardSpeed = BaseKarVel;

            }
        }

        if (isSlowed)
        {
            
            if (TimeSlowed > 0f)
            {
                TimeSlowed -= Time.deltaTime;
                kart.forwardSpeed = VelSlowed;
            }
            else
            {
                kart.forwardSpeed = BaseKarVel;
                Debug.Log(kart.forwardSpeed);

                isSlowed = false;
            }
        }
    }
    

   

    public void UpdateUI()
    {
        TotalPlayerCrossFinishLine.text = "" + TotalCrossFinishLine + "\n" + " /" + "\n" + "   3";
        
        TurboBar.fillAmount = TurboAmount / _turboBarAmount;
    }
    
    
    public void UsePower()
    {
        if (isHasPower && _ruletScript.StopSpin)
        {
            isHasPower = false;
            _ruletScript.isSpinRulet = false;
        }
    }

    public void UseTurbo(bool useTurbo)
    {
        isUseTurbo = useTurbo;
        if (!isUseTurbo)
        {
            kart.forwardSpeed = BaseKarVel;

        }
    }

    public void GetTurbo(float amount)
    {
        TurboAmount += amount;
    }

    public void Slowed(bool isSlowed, float TimeSlow, float velocySlow)
    {
        this.isSlowed = isSlowed;
        TimeSlowed = TimeSlow;
        VelSlowed = velocySlow;
    }
}
