using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogManager : MonoBehaviour
{

    public static LogManager singleton;
    public string uuidParty;
    public List<Player> players = new List<Player>();
    public List<Building> DeckBuilding = new List<Building>();
    public List<Turn> Turns = new List<Turn>();

    private void Awake()
    {
        if (singleton != null)
        {
            Debug.LogError("more than One LogManager");
        }
        else
        {
            singleton = this;
            DontDestroyOnLoad(this);
        }
    }


        public void SetUUID()
    {
        uuidParty = Guid.NewGuid().ToString();
    }

    public void GetPlayers()
    {

        players = new List<Player>(GameManager.singleton.players);
    }


    public void GetDeckBuilding()
    {
        DeckBuilding = new List<Building>(GameManager.singleton.game.DeckBuildings);
    }

    private void Start()
    {
        SetUUID();
    }

    public List<Building> GetMarket()
    {
        return GameManager.singleton.game.Market; 
    }


    public void NewTurn()
    {
        Turns.Add(new Turn(GameManager.singleton.game.turnNumber, GetMarket()));
    }


}
