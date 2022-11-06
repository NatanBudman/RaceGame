using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public GameObject Power;
    public GameObject Skill;

    public GameObject[] ArreyPower;
    public void TakeObject()
    {
        int powerSelec = Random.Range(0, ArreyPower.Length);

        Power = ArreyPower[powerSelec].gameObject;
    }
}
