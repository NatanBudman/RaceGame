using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private KartPowerPickUp Car;
    [SerializeField] private ControllersScriptableObject _controllers;

    #region MoveInputs

       private KeyCode MovForward => _controllers.MovForward;
       private KeyCode MovLeft => _controllers.MovLeft;
       private KeyCode MovRight => _controllers.MovRight;
       private KeyCode MovReverse => _controllers.MovReverse;

    #endregion

    #region ActionInputs

      private KeyCode PowerActive => _controllers.PowerActive;
      private KeyCode JumpActive => _controllers.JumpActive;
      private KeyCode TurboActive => _controllers.TurboActive;

      private KeyCode SkillActivate => _controllers.SkillActivate;

    #endregion
    
  
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(PowerActive)) Car.UsePower();

        if (Input.GetKey(TurboActive)) Car.UseTurbo(true);
        if (Input.GetKeyUp(TurboActive)) Car.UseTurbo(false);

        if (Input.GetKeyDown(SkillActivate)) Car.UseSkill();
        
            
    }
}
