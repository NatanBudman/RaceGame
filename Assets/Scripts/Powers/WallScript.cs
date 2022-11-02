using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    [SerializeField] private float TimeLife;

    private float currenTime;

    [SerializeField] private GameObject Wall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Wall.activeSelf)
        {
            currenTime += Time.deltaTime;

            if (currenTime >= TimeLife )
            {
                Wall.SetActive(false);
            }
        }
        else
        {
            currenTime = 0;
        }
    }

  
    
}

