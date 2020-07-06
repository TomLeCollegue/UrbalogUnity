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
        else if(_value == 1) //if player choose '+'
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
            int idPlayer = Convert.ToInt32(GameObject.Find("playerLocal").GetComponent<Player>().ID);
            CmdBet(idPlayer, _value, _resource, numBuildingBet);
            ChangeRessourcePlayer(_value, _resource);
            AddBetInPlayerBets(_value, FindIndexFromResource(_resource, _role));
            Debug.Log(playerBets.ToString());
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
    public void CmdBet(int idPlayer, int value, string Ressource, int num)
    {
        BetLog(idPlayer, value, Ressource, num);
        RpcBet(value, Ressource, num);
    }

    public void BetLog(int playerId,int value, string Ressource, int num)
    {
        int turnNumber = GameManager.singleton.game.turnNumber - 1;
        
        string nameBuilding = GameManager.singleton.game.Market[num].name;
        int social = 0;
        int political = 0;
        int economical = 0;
        if (Ressource.Equals("Political"))
        {
            political = value;
        }
        else if (Ressource.Equals("Social"))
        {
            social = value;
        }
        else
        {
            economical = value;
        }

        LogManager.singleton.Turns[turnNumber].AddBet(playerId, political, economical, social,nameBuilding);
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
    public bool IsFinanced(Building _building)
    {
        return (_building.FinanceEconomical >= _building.Economical && _building.FinancePolitical >= _building.Political
            /*&& _building.FinanceSocial >= _building.Social*/);
    }
    /// <summary>
    /// Check how many buildings are financed and return it
    /// </summary>
    /// <returns>Returns the number of Buildings that are financed</returns>
    public int NbBuildingsFinanced()
    {
        Game _game = GameManager.singleton.game;
        int _res = 0;
        for (int i = 0; i < 5; i++)
        {
            if (IsFinanced(_game.Market[i]))
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
            if (IsFinanced(_game.Market[i]))
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
        BetControl _betControl = GameObject.Find("playerLocal").GetComponent<BetControl>();

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 2 ; j++)
            {
                _betControl.playerBets[i, j] = 0;
            }
        }
    }

    [Command]
    public void CmdResetPlayersBet()
    {
        RpcResetPlayersBet();
    }

    [ClientRpc]
    public void RpcResetPlayersBet()
    {
        ResetPlayersBet();
    }

    /// <summary>
    /// Checks the market for all the buildings that are not financed entirely to give back
    /// the resources for the players who bet.
    /// </summary>
    public void GiveBackResourcesToPlayerWhenNextTurn()
    {
        Game _game = GameManager.singleton.game;
        Player _player = GameObject.Find("playerLocal").GetComponent<Player>();

        for (int i = 0; i < _game.Market.Count; i++)
        {
            if (!IsFinanced(_game.Market[i]) && !BuildingIsNotFinancedAtAll(_game.Market[i])) 
            {
                ReturnBuildingResources(_game.Market[i], _player , i);
            }
        }

    }

    [Command]
    public void CmdGiveBackResourcesToPlayerWhenNextTurn()
    {
        RpcGiveBackResourcesToPlayerWhenNextTurn();
        GiveBackResourcesToPlayerWhenNextTurn();
    }

    [ClientRpc]
    public void RpcGiveBackResourcesToPlayerWhenNextTurn()
    {
        GiveBackResourcesToPlayerWhenNextTurn();
    }

    /// <summary>
    /// tells if a building as at least one resource on it or not.
    /// </summary>
    /// <param name="_building"></param>
    /// <returns></returns>
    public bool BuildingIsNotFinancedAtAll(Building _building)
    {
        return (_building.FinancePolitical == 0 && _building.FinanceEconomical == 0 && _building.FinanceSocial == 0);
    }

    /// <summary>
    /// Checks player bet and the building given and returns the player investment to them.
    /// Also it takes this amount back from building finances.
    /// </summary>
    /// <param name="_building">The building we check</param>
    /// <param name="_player">the player we return the resources</param>
    private void ReturnBuildingResources(Building _building, Player _player, int _indexBuilding)
    {
        int _indexPolitical = FindIndexFromResource("Political", _player.role);
        int _indexEconomical = FindIndexFromResource("Economical", _player.role);
        int _indexSocial = FindIndexFromResource("Social", _player.role);

        BetControl _betControl = GameObject.Find("playerLocal").GetComponent<BetControl>();

        int _tempPolitical = 0;
        int _tempEconomical = 0;
        int _tempSocial = 0;

        if (_indexPolitical > -1)
        {
            if (_betControl.playerBets[_indexBuilding,_indexPolitical]>0)
            {
                _tempPolitical = _betControl.playerBets[_indexBuilding, _indexPolitical]; 
                _betControl.playerBets[_indexBuilding, _indexPolitical] -= _building.FinancePolitical; //substract in playerBets
                _building.FinancePolitical -= _tempPolitical; //Update how is _building financed
                _player.role.ressourcePolitical += _tempPolitical; //give back the resource to the player's hand
            }
        }

        if (_indexEconomical > -1)
        {
            if (_betControl.playerBets[_indexBuilding, _indexEconomical] > 0)
            {
                _tempEconomical = _betControl.playerBets[_indexBuilding, _indexEconomical];
                _betControl.playerBets[_indexBuilding, _indexEconomical] -= _building.FinanceEconomical;
                _building.FinanceEconomical -= _tempEconomical;
                _player.role.ressourceEconomical += _tempEconomical;
            }
        }

        if (_indexSocial > -1)
        {
            if (_betControl.playerBets[_indexBuilding, _indexSocial] > 0)
            {
                _tempSocial = _betControl.playerBets[_indexBuilding, _indexSocial];
                _betControl.playerBets[_indexBuilding, _indexSocial] -= _building.FinanceSocial;
                _building.FinanceSocial -= _tempSocial;
                _player.role.ressourceSocial += _tempSocial;
            }
        }
    }

    /// <summary>
    /// Tells if a given resource on a given building is fully financed or not
    /// </summary>
    /// <param name="_finance">this parameter is the finance we want to check on our building</param>
    /// <param name="_max">The maximum before a resource is completed</param>
    /// <returns></returns>
    public bool ResourceIsCompleted(int _finance, int _max)
    {
        return (_finance >= _max);
    }
}
