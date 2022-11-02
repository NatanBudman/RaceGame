using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Controls", menuName = "Controllers")]
public class ControllersScriptableObject : ScriptableObject
{
    [SerializeField] private ControlsStruct _controls;
    public KeyCode MovForward
    {
        get => _controls.MovForward;
        set => _controls.MovForward = value;
    }

    public KeyCode MovLeft
    {
        get => _controls.MovLeft;
        set => _controls.MovLeft = value;
    }

    public KeyCode MovRight
    {
        get => _controls.MovRight;
        set => _controls.MovRight = value;
    }

    public KeyCode MovReverse
    {
        get => _controls.MovReverse;
        set => _controls.MovReverse = value;
    }

    public KeyCode PowerActive
    {
        get => _controls.PowerActive;
        set => _controls.PowerActive = value;
    }

    public KeyCode JumpActive
    {
        get => _controls.JumpActive;
        set => _controls.JumpActive = value;
    }

    public KeyCode TurboActive
    {
        get => _controls.TurboActive;
        set => _controls.TurboActive = value;
    }
    
    public KeyCode SkillActivate => _controls.SkillActivate;

}
[System.Serializable]
public struct ControlsStruct
{
    public KeyCode MovForward ;
    public KeyCode MovLeft;
    public KeyCode MovRight; 
    public KeyCode MovReverse;
    
    public KeyCode PowerActive;
    public KeyCode JumpActive;
    public KeyCode TurboActive;
    public KeyCode SkillActivate;

}
