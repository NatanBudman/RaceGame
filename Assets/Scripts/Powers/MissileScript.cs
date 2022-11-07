using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    [HideInInspector]
    public GameObject OwnerGameObject;

    [SerializeField] private float vel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y,
            transform.position.z + vel * Time.deltaTime);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Runner") && OwnerGameObject != other.gameObject)
        {
            other.GetComponent<KartPowerPickUp>().Slowed(true,1.5f,0);
            Destroy(this);
            return;
        }
        else if (other.CompareTag("Item"))
        {
            other.gameObject.SetActive(false);
            Destroy(this);
            return;

        }
        if (other.GetComponent<IAController>())
        {
            other.GetComponent<IAController>().Slowed(true,1.5f,0);
            Destroy(this);
            return;

        }

        if (other.gameObject)
        {
            Destroy(this);
            return;
        }
    }
}
