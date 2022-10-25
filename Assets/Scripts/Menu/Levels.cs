using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    #region Maps

      public GameObject PanelsMaps;

      [SerializeField] private Transform[] PointsToMoveMaps;
    
        public Dropdown DropMapsName;
    
        private int VerifiqueChangeOptions;

        private float speed = 320;

        [SerializeField] private Transform AusPosition;
    #endregion
  
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (VerifiqueChangeOptions != DropMapsName.value)
        {
            var velocity = speed * Time.deltaTime;
            
           
            AusPosition.position = PointsToMoveMaps[DropMapsName.value].position;
            
            if( PanelsMaps.transform.position.y != AusPosition.position.y)
            {
                PanelsMaps.transform.position = Vector3.MoveTowards( PanelsMaps.transform.position,-AusPosition.position,velocity);
            }


            if ( PanelsMaps.transform.position.y == AusPosition.position.y)
            {
                VerifiqueChangeOptions = DropMapsName.value;
            }
        }
       
    }
}
