using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RacePositionManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private PositionPila Pila;

    [SerializeField] private Text[] PositionTable;

    [SerializeField] private GameObject SlotsPanel;
    // Start is called before the first frame update
    void Start()
    {
        
        Pila.InicializateTDA(_gameManager.IAsPlayers + 1);

        PositionTable = new Text[_gameManager.IAsPlayers + 1];

        for (int i = 0; i < _gameManager.PlayersPositions.Length; i++)
        {
            Pila.StackKartsPositions(_gameManager.PlayersPositions[i]);
        }

        for (int i = 0; i < _gameManager.PlayersPositions.Length; i++)
        {
            PositionTable[i] = SlotsPanel.transform.GetChild(i).gameObject.GetComponent<Text>();
            PositionTable[i].text = ""+ Pila.TopPlayer().RacePosition + Pila.TopPlayer().name;
            Pila.UnstackPosition();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RefreshPositions();
        }
        
    }

    private int v;
    public void RefreshPositions()
    {
        if (!Pila.EmptyTDA())
        {
            for (int i = 0; i < _gameManager.PlayersPositions.Length; i++)
            {
                Pila.StackKartsPositions(_gameManager.PlayersPositions[i]);
            }
            
            for (int i = 0; i < _gameManager.PlayersPositions.Length; i++)
            {
                Debug.Log("entre a la cola");
                PositionTable[i] = SlotsPanel.transform.GetChild(i).gameObject.GetComponent<Text>();
                PositionTable[i].text = $"Pos.{i + 1} "+ Pila.TopPlayer().RacePosition + Pila.TopPlayer().name;
                Pila.UnstackPosition();
            }
        }
        else
        {
            Pila.ResetTDA();
        }

    }
}
