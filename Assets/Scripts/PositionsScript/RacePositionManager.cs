using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RacePositionManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private PositionPila Pila;

    [SerializeField] private Text[] PositionTable;

    public GameObject SlotsPanel;
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

    private void FixedUpdate()
    {
        RefreshPositions();
    }
    

    private int v;
    public void RefreshPositions()
    {
        if (!Pila.EmptyTDA())
        {
            v = _gameManager.PlayersPositions.Length;
            for (int i = 0; i < _gameManager.PlayersPositions.Length; i++)
            {
                Pila.StackKartsPositions(_gameManager.PlayersPositions[i]);
            }
            
            for (int i = 0; i < _gameManager.PlayersPositions.Length; i++)
            {
                PositionTable[i] = SlotsPanel.transform.GetChild(i).gameObject.GetComponent<Text>();
                PositionTable[i].text = $"Pos.{v} "+ Pila.TopPlayer().RacePosition + Pila.TopPlayer().name;
                v--;
                Pila.UnstackPosition();
            }
        }
        else
        {
            Pila.ResetTDA();
        }

    }
}
