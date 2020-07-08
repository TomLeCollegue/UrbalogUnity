﻿using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NextTurnButton : NetworkBehaviour
{
    public static int NumberBuildingsToEnd = 3; //default value
    public TextMeshProUGUI TextButton;

    /// <summary>
    /// Change your Next turn bool from a state to an other
    /// </summary>
    public void ClickNextTurn()
    {
        string _id = GameObject.Find("playerLocal").GetComponent<Player>().ID.ToString();
        GameObject.Find("playerLocal").GetComponent<PlayerSetup>().CmdChangeBoolNextTurn(_id);
    }




    private void Update()
    {
        if (isServer)
        {
            if (CheckEndGameCondition())
            {
                CmdChangeSceneToEndGame();
                return;
            }
            if (CheckForNextTurn() || TimerEnded())
            {
                if (!NbBuildingFinancedTooHigh())
                {
                    NextTurn();
                }
                else
                {
                    DisplayErrorTooMuchBuildings();
                }
            }
        }
        bool Turn = GameObject.Find("playerLocal").GetComponent<Player>().nextTurn;
        //if (!Turn)
        //{
        //    TextButton.text = "Tour Suivant";
        //}
        //else
        //{
        //    TextButton.text = "Annuler";
        //}
        if (TimerEnded())
        {
            resetTimer();
        }

        if (!Turn && !NbBuildingFinancedTooHigh())
        {
            TextButton.text = "Tour Suivant";
        }
        else if (NbBuildingFinancedTooHigh())
        {
            TextButton.text = "TROP D'AMÉNAGEMENTS";
        }
        else if (Turn && !NbBuildingFinancedTooHigh())
        {
            TextButton.text = "Annuler";
        }

        if (CheckForTimerStart())
        {
            GameObject.Find("TimerManager").GetComponent<TimerManager>().StartTimer();
        }
        else
        {
            resetTimer();
        }
    }

    public void resetTimer()
    {
        TimerManager _timerManager = GameObject.Find("TimerManager").GetComponent<TimerManager>();
        _timerManager.currentTurnTime = 60f;
        _timerManager.alreadyStarted = false;
    }

    private bool TimerEnded()
    {
        TimerManager _timerManager = GameObject.Find("TimerManager").GetComponent<TimerManager>();



        return (_timerManager.currentTurnTime <= 0);
    }

    private bool CheckForTimerStart()
    {
        GameManager gameManager = GameManager.singleton;
        int countPlayersReady = 0;
        for (int i = 0; i < gameManager.players.Count; i++) //int i = 2 quand on joue avec le serveur et le plateau
        {
            if (gameManager.players[i].nextTurn)
            {
                countPlayersReady++;
            }
        }
        return ( gameManager.players.Count - countPlayersReady == 1 );

    }


    /// <summary>
    /// Checks if the number of buildings that are financed + those who are built exceeds
    /// the number of buildings required to end the game
    /// </summary>
    private bool NbBuildingFinancedTooHigh()
    {
        //Si le nombre de bâtiments financés + ceux déjà construits dépassent le nombre de bâtiments avant d'arriver
        // à la fin, return true
        BetControl _betControl = GameObject.Find("playerLocal").GetComponent<BetControl>();
        Game _game = GameManager.singleton.game;

        if (_betControl.NbBuildingsFinanced() + _game.BuildingsBuilt.Count > NumberBuildingsToEnd)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void DisplayErrorTooMuchBuildings()
    {
        TextButton.text = "TROP D'AMÉNAGEMENTS";
    }


    #region Next turn 

    /// <summary>
    /// Fonction for next Turn in general
    /// </summary>
    private void NextTurn()
    {
        BetControl betControl = GameObject.Find("playerLocal").GetComponent<BetControl>();
        PlayerSetup playerSetup = GameObject.Find("playerLocal").GetComponent<PlayerSetup>();
        GameManager gameManager = GameManager.singleton;

        ResetTurnBoolPlayer();                   //Reset des boolean de tour des players
        betControl.CmdGiveBackResourcesToPlayerWhenNextTurn();       // Rendre les ressources aux joueurs pour les aménagements pas financés entièrement.
        DistribScorePlayer();
        betControl.BuildTheBuildings();          // Check les batiment construit, Les ajouter dans la list des batiments construit, Les supprimer du Deck
        ResetFinanceBuildingInMarket();
        gameManager.game.ChangeMarket();         // Changer le marché
        betControl.CmdResetPlayersBet();         // Réinitialiser le tableau des mises de chaques joueurs
        UpdateTurnNumber();                      // Changer le numéro de tour
        playerSetup.CmdSendActualGameManager();  // Envoyer le nouveau game avec la fonction dans le PlayerSetup
        GameObject.Find("CityManager").GetComponent<FillCity>().SpawnBuildingsBuilt();
        Invoke("PopUpPlayer", 2);
    }

    private void ResetFinanceBuildingInMarket()
    {
        Game _game = GameManager.singleton.game;
        for (int i = 0; i < _game.Market.Count; i++)
        {
            _game.Market[i].FinanceEconomical = 0;
            _game.Market[i].FinancePolitical = 0;
            _game.Market[i].FinanceSocial = 0;
        }
    }

    /// <summary>
    /// Check if every player want to past the turn
    /// </summary>
    /// <returns></returns>
    private bool CheckForNextTurn()
    { 
        GameManager gameManager = GameManager.singleton;
        bool boolTurn = true;
        for (int i = 0; i < gameManager.players.Count; i++) //int i = 2 quand on joue avec le serveur et le plateau
        {    
            if (!gameManager.players[i].nextTurn)
            {
                boolTurn = false;
            }
        }

        return boolTurn;
    }

    /// <summary>
    /// Reset the Next turn bools for every player.
    /// </summary>
    private void ResetTurnBoolPlayer()
    {
        GameManager gameManager = GameManager.singleton;
        for (int i = 0; i < gameManager.players.Count; i++)
        {
            gameManager.players[i].nextTurn = false;
        }
    }


    /// <summary>
    /// Each turn, the turn number update on the playerView scene
    /// </summary>
    public void UpdateTurnNumber()
    {
        Game _game = GameManager.singleton.game;
        _game.turnNumber += 1;
        FillPlayerView fillView = GameObject.Find("PlayerViewManager").GetComponent<FillPlayerView>();
        fillView.UpdateTurn();
    }

    #endregion


    #region Score Player
    public void DistribScorePlayer()
    {
        int ScoreEnvi = 0;
        int ScoreAttract = 0;
        int ScoreFluid = 0;
        BetControl betControl = GameObject.Find("playerLocal").GetComponent<BetControl>();
        Game game = GameManager.singleton.game;
        for (int i = 0; i < game.Market.Count; i++)
        {
            if (betControl.IsFinanced(game.Market[i]))
            {
                ScoreEnvi += game.Market[i].enviScore;
                ScoreAttract += game.Market[i].attractScore;
                ScoreFluid += game.Market[i].fluidScore;
            }
        }


        CheckScorePlayers(ScoreEnvi, ScoreAttract, ScoreFluid);
        
    }

    public void CheckScorePlayers(int envi, int attract, int fluid)
    {
        GameManager gameManager = GameManager.singleton;
        for (int i = 0; i < gameManager.players.Count; i++)
        {
            if(CheckObjectifPlayer(gameManager.players[i], envi, fluid, attract))
            {
                gameManager.players[i].scorePlayer += 1;
            }
        }
    }

    public bool CheckObjectifPlayer(Player player, int envi, int fluid, int attract)
    {
        bool GainScore = true;
        //Hold Check
        if (player.role.hold.Equals("Environment") && envi < 0)
        {
            GainScore = false;
        }
        else if (player.role.hold.Equals("Attractiveness") && attract < 0)
        {
            GainScore = false;
        }
        else if (player.role.hold.Equals("Fluidity") && fluid < 0)
        {
            GainScore = false;
        }



        //Improve Check
        if (player.role.improve.Equals("Environment") && envi < 1)
        {
            GainScore = false;
        }
        else if (player.role.improve.Equals("Attractiveness") && attract < 1)
        {
            GainScore = false;
        }
        else if (player.role.improve.Equals("Fluidity") && fluid < 1)
        {
            GainScore = false;
        }

        return GainScore;
    }

    public void PopUpPlayer()
    {
        GameObject.Find("playerLocal").GetComponent<Player>().CmdScore();
    }

    


    #endregion

    #region EndGame

    /// <summary>
    /// Checks if the number of buildings that are built exceeds the number of buildings required for the game to end
    /// </summary>
    /// <returns></returns>
    public bool CheckEndGameCondition()
    {
        if(GameManager.singleton.game.BuildingsBuilt.Count >= NumberBuildingsToEnd)
        {
            return true;
        }
        else
        {
            return false;
        }
    }



    [Server]
    private void CmdChangeSceneToEndGame()
    {
        NetworkManager.singleton.ServerChangeScene("EndGame");
    } 


    #endregion
}
