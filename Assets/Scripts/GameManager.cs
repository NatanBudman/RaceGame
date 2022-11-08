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

    [SerializeField] private PositionRace player;
    [SerializeField] private Transform StartPoint;
    [HideInInspector] public bool isStartRace;
    public GameObject[] IAsSpawning;
    int pos = 0;

    [HideInInspector] public float CountStart;

    [SerializeField] private Text StarCount;
// Player Stats
    public TypeRunners _PlayerStats => _rules.PlayerCharacterStats;

    public TypeRunners[] IAStats;

    [HideInInspector] public int Position;
    [HideInInspector]public int FinsihPosition;

     public PositionRace[] PlayersPositions;
    // Start is called before the first frame update
    void Awake()
    {
        CountStart = StartCount;

        PlayersPositions = new PositionRace[IAsPlayers + 1];

        PlayersPositions[0] = player;

        for (int i = 0; i < IAsPlayers; i++)
        {
            int RamdomIASkin = Random.Range(0, IAsSpawning.Length);
            
            Vector3 newPos = new Vector3(StartPoint.position.x,StartPoint.position.y,StartPoint.position.z + pos);
            pos = pos + 5 ;
            
            GameObject IA = Instantiate(IAsSpawning[RamdomIASkin].gameObject, newPos,
                StartPoint.rotation);
            
            IA.GetComponent<IAController>().IAStats = IAStats[_rules.DificultIA];
            IA.gameObject.name = "Bot " + i;
            PlayersPositions[i + 1] = IA.GetComponent<PositionRace>();

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CountStart >= 0)
        {
            CountStart -= 0.5f *Time.deltaTime;
            StarCount.text = "" + (int)CountStart;
            isStartRace = false;
        }
        else
        {
            isStartRace = true;
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
