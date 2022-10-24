using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
  [SerializeField] private ControllersScriptableObject _controllers;

  #region ControllersSecction
  [Space]
[Header("Controls")]
  [Space]
  public Text KeyForward;
  public Text KeyReverse;
  public Text KeyLeft;
  public Text KeyRight;
  public Text KeyPower;
  public Text KeyJump;
  public Text KeyTurbo;
  
    private bool MovForward;
    private bool MovReverse;
    private bool MovLeft;
    private bool MovRight;
    private bool Jump;
    private bool Power;
    private bool Turbo;
  
    private bool IsSelectingKey = false;

  #endregion

  private KeyCode ChangeKey;
 
  private void Update()
  {
   
    
    if (IsSelectingKey)
    {
      SelectedButtons();
    }
    else
    {
        Turbo = false;
        Power = false;
        Jump = false;
        MovRight = false;
        MovLeft = false;
        MovReverse = false;
        MovForward = false;
    }

    if (Input.GetMouseButtonDown(0) && IsSelectingKey)
    {
      IsSelectingKey = false;
     
    }
    
  }
  

  #region KeyboardButtons


  void SelectedButtons()
  {
    if (MovForward)
    {
      _controllers.MovForward = ChangeKey;
          KeyForward.text = "" + _controllers.MovForward;
        
    }

    if (MovLeft)
    {
    
        _controllers.MovLeft = ChangeKey;
        KeyLeft.text ="" + _controllers.MovLeft;
      
    }

    if (MovReverse)
    {
     
        _controllers.MovReverse = ChangeKey;
        KeyReverse.text ="" + _controllers.MovReverse;
      
    }

    if (MovRight)
    {
     
        _controllers.MovRight = ChangeKey;
        KeyRight.text ="" + _controllers.MovRight;
       
    }

    if (Power)
    {
      
        _controllers.PowerActive = ChangeKey;
        KeyPower.text ="" + _controllers.PowerActive;
      
    }

    if (Jump)
    {
      
        _controllers.JumpActive = ChangeKey;
        KeyJump.text ="" + _controllers.JumpActive;
       
    }

    if (Turbo)
    {
      
        _controllers.TurboActive = ChangeKey;
        KeyTurbo.text ="" + _controllers.TurboActive;
       
    }
    
  }
  public void ForwardButton()
  {
    
    MovForward = true;
    IsSelectingKey = true;

  }

  public void RightButton()
  {
    MovRight = true;
    IsSelectingKey = true;
  }

  public void LeftButton()
  {
    MovLeft = true;
    IsSelectingKey = true;
  }

  public void ReverseButton()
  {
    MovReverse = true;
    IsSelectingKey = true;
  }

  public void JumpButton()
  {
    Jump = true;
    IsSelectingKey = true;
  }

  public void PowerdButton()
  {
    Power = true;
    IsSelectingKey = true;
  }

  public void TurbodButton()
  {
    Turbo = true;
    IsSelectingKey = true;
  }

  private Event GetKeyPress;
  private void OnGUI()
  {
    GetKeyPress = Event.current;
    if (GetKeyPress.isKey)
    {
      
        if (Input.GetKeyDown(GetKeyPress.keyCode) && IsSelectingKey)
        {
           ChangeKey = GetKeyPress.keyCode;
                  Debug.Log(ChangeKey);
        }else if (Input.GetKeyUp(GetKeyPress.keyCode))
        {
          IsSelectingKey = false;
        }
    }
  }

  #endregion
}
