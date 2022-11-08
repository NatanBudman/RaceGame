using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private KartPowerPickUp Car;
    [SerializeField] private ControllersScriptableObject _controllers;
    [SerializeField] private TurboSystem _turboSystem;
    [SerializeField] private KartControllerAlternative _kartController;

    #region MoveInputs

       public KeyCode MovForward => _controllers.MovForward;
       private KeyCode MovLeft => _controllers.MovLeft;
       private KeyCode MovRight => _controllers.MovRight;
       public KeyCode MovReverse => _controllers.MovReverse;

    #endregion

    #region ActionInputs

      private KeyCode PowerActive => _controllers.PowerActive;
      private KeyCode JumpActive => _controllers.JumpActive;
      private KeyCode TurboActive => _controllers.TurboActive;

      private KeyCode SkillActivate => _controllers.SkillActivate;

    #endregion
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(PowerActive)) Car.UsePower();

        if (Input.GetKey(TurboActive))
        {
            _kartController.maxSpeed = _turboSystem.UseTurbo(true,_kartController.maxSpeed);
        }

        if (Input.GetKeyUp(TurboActive))
        {
            _kartController.maxSpeed = _turboSystem.UseTurbo(false,_kartController.maxSpeed);
        }

       

        if (Input.GetKeyDown(SkillActivate)) Car.UseSkill();
        
            
    }
}
