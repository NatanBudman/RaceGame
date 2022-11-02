using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeSkill : MonoBehaviour
{
    float vel;

    private KartPowerPickUp kart;

    [SerializeField] private GameObject[] FakeObject; 

    [SerializeField] private float timeToReturnVel;

    float currentRetunrVel;

    [SerializeField] private float TimeLife;

    private float currenTime;
   
    [HideInInspector] public GameObject OwnerObject;

    [SerializeField] private float TimeOwnerObject;
    private float currentOwner;

    private int ObjectSelected = -1;

    [SerializeField] private BoxCollider Box;
    [SerializeField] private BoxCollider Turbo;
    
    
    [SerializeField] private float RotateVelocity;
    private float addVelocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (ObjectSelected == 0)
        {
            Box.enabled = true;
            Turbo.enabled = false;
            BoxRotate();
            
        }else if (ObjectSelected == 1)
        {
            Box.enabled = false;
            Turbo.enabled = true;
        }

        if (ObjectSelected == -1)
        {
            SelecObject();
        }
        if (kart == null)
        {
            currentRetunrVel = 0;
        }
        
        if (FakeObject[ObjectSelected].activeSelf)
        {
            currenTime += Time.deltaTime;

            if (currenTime >= TimeLife )
            {
                FakeObject[ObjectSelected].SetActive(false);
            }
        }
        else
        {
            currenTime = 0;
        }
        
        if (OwnerObject != null)
        {
            currentOwner += Time.deltaTime;

            if (currentOwner >= TimeOwnerObject)
            {
                OwnerObject = null;
            }
        }
        else
        {
            currentOwner = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Runner") && FakeObject[ObjectSelected].activeSelf)
        {
            kart = other.GetComponent<KartPowerPickUp>();

            kart.Slowed(true,timeToReturnVel,0);

            SelecObject();
            
            Debug.Log(ObjectSelected);
            
            this.gameObject.SetActive(false);            

        }
    }

    void SelecObject()
    {
        ObjectSelected = Random.Range(0, FakeObject.Length );
        

        for (int i = 0; i < FakeObject.Length; i++)
        {
            if (i == ObjectSelected)
            {
                FakeObject[i].SetActive(true);
            }
            else
            {
                FakeObject[i].SetActive(false);
            }
        }
    }
    
    void BoxRotate()
    {
        if (FakeObject[0].activeSelf) addVelocity += RotateVelocity + Time.deltaTime;

        if (addVelocity >= 360) addVelocity = 0;
                               
        FakeObject[0].transform.rotation = Quaternion.Euler(0,addVelocity,0);
    }
}
