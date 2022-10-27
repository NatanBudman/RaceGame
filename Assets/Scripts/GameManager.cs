using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameRules _rules;

    public int DificultIA => _rules.DificultIA;

    public float TimeToSpawnBox => _rules.TimeToSpawnBox;

    public bool IsHasBalance => _rules.IsHasBalance;

    public int IAsPlayers => _rules.IAsPlayers;

    public int TurnsCount => _rules.TurnsCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
