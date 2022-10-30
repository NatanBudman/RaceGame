using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] private int Amount;

    public GameObject Item;

    public Transform pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Amount >= 1)
        {
            PoolObject.ItemInstantiate(Item,pos,Quaternion.identity);
            Amount--;
        }
    }
}
