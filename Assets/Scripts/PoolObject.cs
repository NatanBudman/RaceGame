using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public static List<GameObject> ItemsPool = new List<GameObject>();

    public static void ItemInstantiate(GameObject Item, Transform transform, Quaternion quaternion)
    {
        ItemsPool.Add(Item);
        
        foreach (var Items in ItemsPool)
        {
            if (Items == Item)
            {
                if (!Items.activeSelf)
                {
                    Items.SetActive(true);
                    Items.transform.position = transform.position;
                    Items.transform.rotation = quaternion;
                    
                    return;
                }
                else
                {
                    Item.SetActive(false);
                    Debug.Log("enre");
                }
            }
            
        }
    }
}
