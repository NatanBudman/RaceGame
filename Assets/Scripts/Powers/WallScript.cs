using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    [SerializeField] private float TimeLife;

    private float currenTime;

    [SerializeField] private GameObject Wall;

    [SerializeField] private BoxCollider wallCollider;
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
            wallCollider.enabled = true;

            if (currenTime >= TimeLife )
            {
                Destroy(this);
            }
        }
        else
        {
            Destroy(this);
        }

    }

  
    
}

