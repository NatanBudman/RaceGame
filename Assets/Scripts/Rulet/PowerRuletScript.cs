using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerRuletScript : MonoBehaviour
{
    public Transform[] ArrayPowerImage;
    [SerializeField] private Transform _centerRulet;
    [SerializeField] private Transform powerSelected;
    
    public Transform LimitPos;
    public Transform SpawnPos;

    public GameObject Rulet;

    public float ImageVelocity;
    private float AuxVelocity;

    public float TimeToStopRulet;
    private float CurrentStopRulet;
    
    public bool isSpinRulet;

    public bool StopSpin;

    private bool isPowerSelectedPositionEqualsPower = false;

    private bool isSelectedItem;

    private bool isForceStop;
[Space]
    [Header("PowersPicks")]
    [Space]
    public GameObject PowerSelected;

    [Space] [SerializeField] private GameObject[] Powers;
    
    
    
    // Events

    public EventHandler Spin;
    
    
    // Start is called before the first frame update
    void Start()
    {
        AuxVelocity = ImageVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        // Active rulet
        if (isSpinRulet && Rulet.activeSelf == false)
        {
            Rulet.SetActive(true);
            StopSpin = false;
        }
        else if (Rulet.activeSelf == true && !isSpinRulet)
        {
            Rulet.SetActive(false);
        }
        
        // Stop Rulet
        if (StopSpin)
        {
            ImageVelocity = 0;
        }
        else
        {
            ImageVelocity = AuxVelocity;
        }
        
        // Active Time rulet
        if (!StopSpin && isSpinRulet && Rulet.activeSelf == true)
        {
            CurrentStopRulet += Time.deltaTime;
        }
        else
        {
            CurrentStopRulet = 0;
        }
        
        // Stop boolean Rulet
        if (CurrentStopRulet >= TimeToStopRulet)
        {
            SelectedPowerImage();
            isSelectedItem = true;
            CurrentStopRulet = 0;
        }

        if ( ArrayPowerImage[ClosePower].position.y >= powerSelected.position.y && ArrayPowerImage[ClosePower].position.y <= powerSelected.position.y + 5 && !StopSpin  && isSelectedItem)
        {
            isPowerSelectedPositionEqualsPower = true;
        }
        else
        {
            isPowerSelectedPositionEqualsPower = false;
        }

        if (isPowerSelectedPositionEqualsPower)
        {
            StopSpin = true;
            isSelectedItem = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ForceStop();

            isForceStop = true;
        }

        if (isForceStop)
        {
            if (ArrayPowerImage[ClosePower].position.y >= powerSelected.position.y && ArrayPowerImage[ClosePower].position.y <= powerSelected.position.y + 5)
            {
                StopSpin = true;
                isForceStop = false;
            }
        }
        
    }

    private int ClosePower;
    void SelectedPowerImage()
    {
        ClosePower = Random.Range(0, ArrayPowerImage.Length);
        PowerSelected = Powers[ClosePower];
        
        
    }

    void ForceStop()
    {
        ClosePower = Random.Range(0, ArrayPowerImage.Length);
        PowerSelected = Powers[ClosePower];
    }

    public void SpinRulet()
    {
        
        Spin?.Invoke(this,EventArgs.Empty);
    }
}
