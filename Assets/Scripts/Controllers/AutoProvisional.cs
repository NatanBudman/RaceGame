using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoProvisional : MonoBehaviour
{
    [SerializeField] private Camera VehicleCamera;
    [SerializeField] private TypeRunners _stats;

    #region RaceData

        [Space] [Header("Race Paramets")] [Space]
        
        public int ControlPointsReached = 0;
        public int TotalCrossFinishLine = 0;

    #endregion

    #region Canvas

    [Space] [Header("Canvas")] [Space] 
    
    [SerializeField] private Text TotalPlayerCrossFinishLine;
    
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
    }

    public void UpdateUI()
    {
        TotalPlayerCrossFinishLine.text = "" + TotalCrossFinishLine + "\n" + " /" + "\n" + "   3";
    }

}
