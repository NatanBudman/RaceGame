using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Game_Rules

       [SerializeField] private GameRules _rules;
    
        public int DificultIA => _rules.DificultIA;
    
        public float TimeToSpawnBox => _rules.TimeToSpawnBox;
    
        public bool IsHasBalance => _rules.IsHasBalance;
    
        public int IAsPlayers => _rules.IAsPlayers;
    
        public int TurnsCount => _rules.TurnsCount;

        public int StartCount => _rules.TimeToStart;

    #endregion

    [SerializeField] private Transform StartPoint;
    public GameObject[] IAsSpawning;
    int pos = 0;

    private float CountStart;

    [SerializeField] private Text StarCount;
// Player Stats
    public TypeRunners _PlayerStats => _rules.PlayerCharacterStats;

    public TypeRunners[] IAStats;

    [HideInInspector] public int Position;
    [HideInInspector]public int FinsihPosition;
    // Start is called before the first frame update
    void Start()
    {
        CountStart = StartCount;
        
        for (int i = 0; i < IAsPlayers; i++)
        {
            int RamdomIASkin = Random.Range(0, IAsSpawning.Length);
            
            Vector3 newPos = new Vector3(StartPoint.position.x,StartPoint.position.y,StartPoint.position.z + pos);
            pos = pos + 5 ;
            
            GameObject IA = Instantiate(IAsSpawning[RamdomIASkin].gameObject, newPos,
                StartPoint.rotation);
            
            int RamdomStatsIA = Random.Range(0, IAStats.Length);
            IA.GetComponent<IAController>().IAStats = IAStats[RamdomStatsIA];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CountStart >= 0)
        {
            CountStart -= 0.5f *Time.deltaTime;
            StarCount.text = "" + (int)CountStart;
        }
        else
        {
            StarCount.gameObject.SetActive(false);
        }
    }

    public static void IsGamePuase(bool isPause)
    {
        if (isPause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
