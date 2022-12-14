using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Rules", menuName = "Rules")]
public class GameRules : ScriptableObject
{
    [SerializeField] private Rules _rules;
    
    public int DificultIA
    {
        get => _rules.DificultIA;
        set => _rules.DificultIA = value;
    }

    public float TimeToSpawnBox
    {
        get => _rules.TimeToSpawnBox;
        set => _rules.TimeToSpawnBox = value;
    }

    public bool IsHasBalance
    {
        get => _rules.IsHasBalance;
        set => _rules.IsHasBalance = value;
    }
    
    public int IAsPlayers
    {
        get => _rules.IAsPlayers;
        set => _rules.IAsPlayers = value;
    }

    public int TurnsCount
    {
        get => _rules.TurnsCount;
        set => _rules.TurnsCount = value;
    }
    
    public TypeRunners PlayerCharacterStats
    {
        get => _rules.PlayerCharacterStats;
        set => _rules.PlayerCharacterStats = value;
    }
    
    public int TimeToStart => _rules.TimeToStart;
    
    public TypeRunners AIStats
    {
        get => _rules.AIStats;
        set => _rules.AIStats = value;
    }
}
[System.Serializable]
public struct Rules
{
    public int DificultIA;

    public float TimeToSpawnBox;

    public bool IsHasBalance;

    public int IAsPlayers;

    public int TurnsCount;

    public TypeRunners PlayerCharacterStats;
    
    public TypeRunners AIStats;

    public int TimeToStart;


}
