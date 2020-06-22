﻿using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BetControl : NetworkBehaviour
{
    public int numBuildingBet;

    #region Bet
    /// <summary>
    /// Change the number of the builgding we are Betting on
    /// </summary>
    /// <param name="num"></param>
    public void ChangeNumBuildingBet(int num)
    {
        numBuildingBet = num;
    }

    /// <summary>
    /// See if the bet is a -1 or a +1 bet and on which ressource.
    /// Then, check if the bet is possible on the building the player chose to open
    /// BetPanel.
    /// </summary>
    /// <param name="value">if -1 then player wanted to take back his resource
    /// if +1 then player wanted to bet 1 resource</param>
    /// <param name="Ressource">It's the resource the player wanted to bet on
    /// can be "Political", "Economical" or "Social"</param>
    public void VerifBet(int value, string Ressource)
    {
        Game game = GameManager.singleton.game;
        bool isOk = true;
        
        if (value == -1)
        {
            if (Ressource.Equals("Political"))
            {
                if(game.Market[numBuildingBet].FinancePolitical < 1)
                {
                    isOk = false;
                }   
            }
            else if (Ressource.Equals("Economical"))
            {
                if (game.Market[numBuildingBet].FinanceEconomical < 1)
                {
                    isOk = false;
                }
            }
            else
            {
                if (game.Market[numBuildingBet].FinanceSocial < 1)
                {
                    isOk = false;
                }
            }

        }
        if (value == 1)
        {
            if (Ressource.Equals("Political"))
            {
                if(GetComponent<Player>().role.ressourcePolitical < 1){
                    isOk = false;
                }
                if (game.Market[numBuildingBet].FinancePolitical >= game.Market[numBuildingBet].Political)
                {
                    isOk = false;
                }
            }
            else if (Ressource.Equals("Economical"))
            {
                if (GetComponent<Player>().role.ressourceEconomical < 1){
                    isOk = false;
                }
                if (game.Market[numBuildingBet].FinanceEconomical >= game.Market[numBuildingBet].Economical)
                {
                    isOk = false;
                }
            }
            else
            {
                if (GetComponent<Player>().role.ressourceSocial < 1){
                    isOk = false;
                }
                if (game.Market[numBuildingBet].FinanceSocial >= game.Market[numBuildingBet].Social)
                {
                    isOk = false;
                }
            }
        }
        //The bet is considered doable
        if (isOk)
        {
            CmdBet(value, Ressource, numBuildingBet);
            ChangeRessourcePlayer(value, Ressource);
        }
    }

    /// <summary>
    /// Is used when a player bet is done.
    /// It changes accurately the ressources available to the player depending on his bet.
    /// </summary>
    /// <param name="value">can be -1 or +1, it's what should be substracted to the player resources.</param>
    /// <param name="Ressource">The Resource the player used to bet</param>
    private void ChangeRessourcePlayer(int value, string Ressource)
    {
        if (Ressource.Equals("Economical"))
        {
            GetComponent<Player>().role.ressourceEconomical -= value;
        }
        else if (Ressource.Equals("Political"))
        {
            GetComponent<Player>().role.ressourcePolitical -= value;
        }
        else
        {
            GetComponent<Player>().role.ressourceSocial -= value;
        }
    }

    /// <summary>
    /// Done by the server.
    /// Does a bet
    /// </summary>
    /// <param name="value">value of the bet : -1 or +1</param>
    /// <param name="Ressource">The resource the player chose to bet</param>
    /// <param name="num">The index of the building in the market</param>
    [Command]
    public void CmdBet(int value, string Ressource, int num)
    {
        RpcBet(value, Ressource, num);
    }

    /// <summary>
    /// Client side.
    /// Changes how a building is financed according to one bet
    /// </summary>
    /// <param name="value">value of the bet : -1 or +1</param>
    /// <param name="Ressource">The resource the player chose to bet</param>
    /// <param name="numBuildingBet">The index of the building in the market</param>
    [ClientRpc]
    public void RpcBet(int value, string Ressource, int numBuildingBet)
    {
        Game game = GameManager.singleton.game;
        if (Ressource.Equals("Political"))
        {
            game.Market[numBuildingBet].FinancePolitical += value;
        }
        else if (Ressource.Equals("Economical"))
        {
            game.Market[numBuildingBet].FinanceEconomical += value;
        }
        else
        {
            game.Market[numBuildingBet].FinanceSocial += value;
        }
    }

    #endregion

    #region Finance
    /// <summary>
    /// Checks if a building is financed and ready to be built when a player presses Next Turn.
    /// </summary>
    /// <param name="_building">the building we check of type Building</param>
    /// <returns></returns>
    public bool isFinanced(Building _building)
    {
        return (_building.FinanceEconomical >= _building.Economical && _building.FinancePolitical >= _building.Political
            /*&& _building.FinanceSocial >= _building.Social*/);
    }
    /// <summary>
    /// Check how many buildings are financed and return it
    /// </summary>
    /// <returns>Returns the number of Buildings that are financed</returns>
    public int nbBuildingsFinanced()
    {
        Game _game = GameManager.singleton.game;
        int _res = 0;
        for (int i = 0; i < 5; i++)
        {
            if (isFinanced(_game.Market[i]))
            {
                _res += 1;
            }
        }
        return _res;
    }

    #endregion

    #region Management Built buildings

    /// <summary>
    /// Add an Object of type Building in the <see cref="Game.BuildingsBuilt"/> list.
    /// </summary>
    /// <param name="_building">Type Building, the building we want to add.</param>
    public void AddBuildingInBuildingsBuilt(Building _building)
    {
        Game _game = GameManager.singleton.game;

        _game.BuildingsBuilt.Add(_building);
        RemoveBuildingFromPioche(_building);
    }

    /// <summary>
    /// Remove the building in argument from <see cref="Game.pioche"/> so it doesn't appear in the Market until the end of the game.
    /// </summary>
    /// <param name="_building">The building we wan to remove.</param>
    public void RemoveBuildingFromPioche(Building _building)
    {
        Game _game = GameManager.singleton.game;
        _game.pioche.Remove(_building);
    }

    public void BuildTheBuildings()
    {
        Game _game = GameManager.singleton.game;
        for (int i = 0; i < 5; i++)
        {
            if (isFinanced(_game.Market[i]))
            {
                AddBuildingInBuildingsBuilt(_game.Market[i]);
                UpdateCityScores();
                RemoveBuildingFromPioche(_game.Market[i]);
            }
        }
    }

    public void UpdateCityScores()
    {
        Game _game = GameManager.singleton.game;
        _game.cityEnvironment = 0;
        _game.cityFluidity = 0;
        _game.cityAttractiveness = 0;
        _game.cityLogistic = 0;

        for (int i = 0; i < _game.BuildingsBuilt.Count ; i++)
        {
            _game.cityEnvironment += _game.BuildingsBuilt[i].enviScore;
            _game.cityFluidity += _game.BuildingsBuilt[i].fluidScore;
            _game.cityAttractiveness += _game.BuildingsBuilt[i].attractScore;
            _game.cityLogistic += _game.BuildingsBuilt[i].logisticScore;
        }
    }

    #endregion
}
