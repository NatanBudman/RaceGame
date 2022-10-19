using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoProvisional : MonoBehaviour
{
    [SerializeField] private Camera VehicleCamera;

    #region RaceData

        [Space]
        [Header("Race Paramets")]
        [Space]
        
        public int ControlPointsReached = 0;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        VehicleCamera.transform.LookAt(this.gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
