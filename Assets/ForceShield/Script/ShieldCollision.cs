using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollision : MonoBehaviour
{
    [SerializeField] private float TimeLife;
    [SerializeField]private float currentLifeTime;
    
    [SerializeField] private float RotateVel;

    [SerializeField] string[] _collisionTag;
    float hitTime;
    Material mat;

    void Start()
    {
        if (GetComponent<Renderer>())
        {
            mat = GetComponent<Renderer>().sharedMaterial;
        }

    }

    void Update()
    {
        if (this.gameObject.activeSelf)
        {
            currentLifeTime += Time.deltaTime;

            if (currentLifeTime >= TimeLife)
            {
                currentLifeTime = 0;
                this.gameObject.SetActive(false);
            }

            transform.Rotate(transform.rotation.x + RotateVel * Time.deltaTime,transform.rotation.y+ RotateVel * Time.deltaTime,transform.rotation.z+ RotateVel * Time.deltaTime);

        }
        else
        {
            currentLifeTime = 0;
        }

        if (hitTime > 0)
        {
            float myTime = Time.fixedDeltaTime * 1000;
            hitTime -= myTime;
            if (hitTime < 0)
            {
                hitTime = 0;
            }
            mat.SetFloat("_HitTime", hitTime);
        }

    }

    void OnCollisionEnter(Collision collision)
    {

        for (int i = 0; i < _collisionTag.Length; i++)
        {

            if (_collisionTag.Length > 0 || collision.transform.CompareTag(_collisionTag[i]))
            {
                //Debug.Log("hit");
                ContactPoint[] _contacts = collision.contacts;
                for (int i2 = 0; i2 < _contacts.Length; i2++)
                {
                    mat.SetVector("_HitPosition", transform.InverseTransformPoint(_contacts[i2].point));
                    hitTime = 500;
                    mat.SetFloat("_HitTime", hitTime);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            Debug.Log("shield entre");
            other.gameObject.SetActive(false);
            currentLifeTime = 0;
            this.gameObject.SetActive(false);
        }
    }
}

