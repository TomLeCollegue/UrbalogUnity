using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Turn 
{
    public int numTurn;
    public List<Building> Market;
    public List<Bet> Bets = new List<Bet>();
    public List<Building> BuildingBuild;
    
    public int AttractScore;
    public int EnviScore;
    public int FluidScore;


    public void SetScore(int _AttractScore, int _EnviScore, int _FluidScore)
    {
        AttractScore = _AttractScore;
        EnviScore = _EnviScore;
        FluidScore = _FluidScore;
    }

    public Turn(int _numTurn, List<Building> _Market)
    {
        numTurn = _numTurn;
        Market = _Market;
    }

    public void AddBet(int playerId, int politic, int econommical, int social, string buildingName)
    {
        Bets.Add(new Bet(playerId, politic,econommical,social,buildingName));
    }

    

}
