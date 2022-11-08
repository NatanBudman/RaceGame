using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurboSystem : MonoBehaviour
{
    [SerializeField] private float AddForce;

    [HideInInspector] public float KartVelocity;

    public float TotalTurboAmount;
    [HideInInspector] public float _currentTurboAmount;

    [SerializeField] private float turboChargePerSecond;

    bool takeVel = false;

    public float UseTurbo(bool isUseTurbo, float VelocityModificated)
    {
        
        if (!takeVel)
        {
            KartVelocity = VelocityModificated;
            AddForce = AddForce + KartVelocity;
            takeVel = true;
        }
        
        if (_currentTurboAmount > 0 && isUseTurbo)
        {
            _currentTurboAmount -= turboChargePerSecond * Time.deltaTime;
            VelocityModificated = AddForce;
            

        }
        else if (_currentTurboAmount <= 0 || !isUseTurbo)
        {
            AddForce = AddForce - KartVelocity;
            VelocityModificated = KartVelocity;
            takeVel = false;
        }
        return VelocityModificated;
    }
    

    public void AddTurbo(float amount)
    {
        _currentTurboAmount += amount;
        _currentTurboAmount = Mathf.Clamp(_currentTurboAmount, -1, TotalTurboAmount);
        return;
    }
    
}
