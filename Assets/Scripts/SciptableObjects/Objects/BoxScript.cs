using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    [SerializeField] private PowerRuletScript _ruletScript;
    [SerializeField] private GameManager _gameManager;
    
    
    [SerializeField] private float RotateVelocity;
    private float addVelocity;
    
    [SerializeField] private float EnableTimer => _gameManager.TimeToSpawnBox;
     private float DisableCurrentTimer;
     
    [SerializeField] private GameObject Box;

    public int RacePosition;
    
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Box.activeSelf == false)
        {
            DisableCurrentTimer += Time.deltaTime;
        }

        BoxRotate();
        
        if (DisableCurrentTimer >= EnableTimer)
        {
            Box.SetActive(true);
            DisableCurrentTimer = 0;
        }
    }

    void BoxRotate()
    {
        if (Box.activeSelf) addVelocity += RotateVelocity + Time.deltaTime;

        if (addVelocity >= 360) addVelocity = 0;
                               
        Box.transform.rotation = Quaternion.Euler(0,addVelocity,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Runner"))
        {
            Box.gameObject.SetActive(false);

            if (other.GetComponent<AutoProvisional>())
            {
                // Player
                other.GetComponent<AutoProvisional>().isUseRulet = true;
                
            }else if (other.GetComponent<AutoProvisional>() == null)
            {
                // IA
            }
                
            Box.SetActive(false);
        }
    }
}
