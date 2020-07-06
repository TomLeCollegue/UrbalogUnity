using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class LogManager : MonoBehaviour 
{

    public static LogManager singleton;
    public string uuidParty;
    public List<Player> players = new List<Player>();
    public List<Building> DeckBuilding = new List<Building>();
    public List<Turn> Turns = new List<Turn>();

    public int AttractScore;
    public int FluidScore;
    public int EnviScore;

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

        players = GameManager.singleton.players;
    }


    public void GetDeckBuilding()
    {
        DeckBuilding = GameManager.singleton.game.DeckBuildings.ToList();
    }

    private void Start()
    {
        SetUUID();
    }

    public List<Building> GetMarket()
    {
        return GameManager.singleton.game.Market.ToList(); 
    }

    public void GetScoreCity()
    {
        AttractScore = GameManager.singleton.game.cityAttractiveness;
        EnviScore = GameManager.singleton.game.cityEnvironment;
        FluidScore = GameManager.singleton.game.cityFluidity;
    }


    public void NewTurn()
    {
        Turns.Add(new Turn(GameManager.singleton.game.turnNumber, GetMarket()));
    }


}
