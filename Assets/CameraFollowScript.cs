using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Vector3 offset;
    public Transform player;

    private KartControllerAlternative playerScript;
    
    public Vector3 originalCamPos;
    public Vector3 boostCamPos;
    
    
    private void Start()
    {
        playerScript = player.GetComponent<KartControllerAlternative>();
    }

    
    private void LateUpdate()
    {
        transform.position = player.position + offset;
        transform.rotation = Quaternion.Slerp(transform.rotation, player.rotation, 3* Time.deltaTime);
    }
}
