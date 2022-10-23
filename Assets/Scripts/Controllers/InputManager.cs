using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private AutoProvisional Car;

    [Space] [Header("Move Inputs")] [Space]

    #region MoveInputs

       [SerializeField] private KeyCode MovForward = KeyCode.W;
       [SerializeField] private KeyCode MovLeft = KeyCode.A;
       [SerializeField] private KeyCode MovRight = KeyCode.D;
       [SerializeField] private KeyCode MovReverse = KeyCode.S;

    #endregion
    [Space]
    [Header("Actions Inputs")]
    [Space]

    #region ActionInputs

      [SerializeField] private KeyCode PowerActive = KeyCode.E;
      [SerializeField] private KeyCode JumpActive = KeyCode.Space;
      [SerializeField] private KeyCode TurboActive = KeyCode.LeftShift;

    #endregion
    
  
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Car.Move(MovForward,MovReverse,MovLeft,MovRight);

        if (Input.GetKeyDown(PowerActive)) Car.UsePower();
        
            
        
    }
}
