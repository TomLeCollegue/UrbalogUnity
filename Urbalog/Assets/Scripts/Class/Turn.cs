using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Turn 
{
    public int numTurn;
    public List<Building> Market;
    public List<Bet> Bets = new List<Bet>();
    public List<Building> BuildingBuild = new List<Building>();
    public string dateTime;

    public Turn(int _numTurn, List<Building> _Market)
    {
        numTurn = _numTurn;
        Market = _Market;
        dateTime = DateTime.Now.ToString();
    }

    public void AddBet(int playerId, int politic, int econommical, int social, string buildingName)
    {
        Bets.Add(new Bet(playerId, politic,econommical,social,buildingName));
    }

    

}
