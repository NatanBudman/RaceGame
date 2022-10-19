using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerRuletScript : MonoBehaviour
{
    public Transform LimitPos;
    public Transform SpawnPos;

    public float ImageVelocity;

    public bool isSpinRulet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ImageVelocity >= 1)
        {
            isSpinRulet = true;
        }
    }
}
