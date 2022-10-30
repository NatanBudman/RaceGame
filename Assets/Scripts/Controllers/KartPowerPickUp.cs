using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KartPowerPickUp : MonoBehaviour
{
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
    
    
    void Start()
    {
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
       
    }

   

    public void UpdateUI()
    {
        TotalPlayerCrossFinishLine.text = "" + TotalCrossFinishLine + "\n" + " /" + "\n" + "   3";
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
