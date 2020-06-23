using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BetControl : NetworkBehaviour
{
    public int numBuildingBet; //Controled by the button, so this number is always the number we bet on.

    public int[,] playerBets = new int[5,2]; //each row is for a building
    //each column for resources


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
    /// Check if a bet can be done and then does it if possible.
    /// </summary>
    /// <param name="_value">+1 or -1. Is the value of the bet</param>
    /// <param name="_resource">"Economical", "Political" or "Social", is the type of ressource which is bet</param>
    /// <param name="_role">player's role so we can know which resources he can use</param>
    public void CheckBet(int _value, string _resource, Role _role)
    {
        Game _game = GameManager.singleton.game;
        bool betDoable = true;

        int _index = FindIndexFromResource(_resource, _role);

        if (_value == -1) //if player choose '-'
        {
            if (_index<0) //it means this player doesn't have _resource at all
            {
                betDoable = false;
            }
            else
            {
                //We don't even need to check how it is on the market
                //Because to take money back, we only need to know if
                //current player paid himself
                if (playerBets[numBuildingBet,_index] <= 0) //The player didn't bet on this building with this resource so he can't take money from it
                    {
                        betDoable = false;
                    }
            }
        }
        else if(_value == 1) ////if player choose '+'
        {
            if (_resource.Equals("Political"))
            {
                if (GetComponent<Player>().role.ressourcePolitical < 1)
                {
                    betDoable = false;
                }
                if (_game.Market[numBuildingBet].FinancePolitical >= _game.Market[numBuildingBet].Political)
                {
                    betDoable = false;
                }
            }
            else if (_resource.Equals("Economical"))
            {
                if (GetComponent<Player>().role.ressourceEconomical < 1)
                {
                    betDoable = false;
                }
                if (_game.Market[numBuildingBet].FinanceEconomical >= _game.Market[numBuildingBet].Economical)
                {
                    betDoable = false;
                }
            }
            else
            {
                if (GetComponent<Player>().role.ressourceSocial < 1)
                {
                    betDoable = false;
                }
                if (_game.Market[numBuildingBet].FinanceSocial >= _game.Market[numBuildingBet].Social)
                {
                    betDoable = false;
                }
            }
        }

        if (betDoable)
        {
            CmdBet(_value, _resource, numBuildingBet);
            ChangeRessourcePlayer(_value, _resource);
            AddBetInPlayerBets(_value, FindIndexFromResource(_resource, _role));
        }
    }

    /// <summary>
    /// when given the name of the resource and the player's role, gives the index of the resource in playersBet.
    /// </summary>
    /// <param name="_resource">the name of the resource : Economical, Political or Social</param>
    /// <param name="_role">The player's role, allowing us to find what are his resource1 and resource2</param>
    /// <returns>-1 if the player doesn't have this resource in his role
    /// 0 if it's in the first spot and 1 if _resource is in 2nd spot</returns>
    public int FindIndexFromResource(string _resource, Role _role)
    {
        if (_resource.Equals(_role.ressource1))
        {
            return 0;
        }
        else if (_resource.Equals(_role.ressource2))
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }

    /// <summary>
    /// When given an index for playerBets, gives the corresponding resource from a player.
    /// </summary>
    /// <param name="_index"></param>
    /// <param name="_role"></param>
    /// <returns>"Economical", "Political" or "Social"</returns>
    public string FindResourceFromIndex(int _index, Role _role)
    {
        string res = "";
        if (_index == 0)
        {
            res = _role.ressource1;
        }
        else if (_index == 1)
        {
            res = _role.ressource2;
        }
        else
        {
            Debug.LogError("bad index send in FindResourceFromIndex");
        }
        return res;
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

    /// <summary>
    /// It builds the buildings when we go to the next turn if they are financed.
    /// </summary>
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

    /// <summary>
    /// Checks all the buildings already built and changes the 4 city score accordingly.
    /// </summary>
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

    /// <summary>
    /// Adds +1 or -1 in playerBets[][] so we can track where a player has bet and how many
    /// </summary>
    /// <param name="_value">+1 or -1, the amount someone bets</param>
    /// <param name="_nbResource">0 or 1 : It's the resource the player decided to bet with.</param>
    public void AddBetInPlayerBets(int _value, int _nbResource)
    {
        if (playerBets[numBuildingBet, _nbResource] >= 1)
        {
            playerBets[numBuildingBet, _nbResource] += _value ;
        }
        else if (playerBets[numBuildingBet, _nbResource] == 0 && _value > 0)
        {
            playerBets[numBuildingBet, _nbResource] += _value ;
        }

    }

    /// <summary>
    /// reset playersBet for each player
    /// </summary>
    public void ResetPlayersBet()
    {
        Game _game = GameManager.singleton.game;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 2 ; j++)
            {
                playerBets[i, j] = 0;
            }
        }
    }
}
