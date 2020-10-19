﻿using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NextTurnButton : NetworkBehaviour
{
    public static int NumberBuildingsToEnd = 4; //default value
    public TextMeshProUGUI TextButton;
    bool LogSend = false;
    public Button ButtonNextTurn;

    public TextMeshProUGUI CityTitle;
    public TextMeshProUGUI nbNextTurn;

    public bool EndWarmup = false;


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
            if (EndWarmup)
            {
                return;
            }
            if (CheckEndGameCondition())
            {
                if (!GameSettings.Warmup)
                {
                    CmdChangeSceneToEndGame();
                    EndGameLog();
                }
                else
                {
                    Debug.Log("end tour de chauffe");
                    EndWarmup = true;
                    Player player = GameObject.Find("playerLocal").GetComponent<Player>();
                    player.CmdChangeTitleCity();

                }
                return;
            }
            if (CheckForNextTurn() || TimerEnded())
            {
                if (!NbBuildingFinancedTooHighForEndGame() && !NbBuildingFinancedTooHighForTurn())
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
        
        if (TimerEnded())
        {
            resetTimer();
        }

        PrintTheGoodNextTurnButton(Turn, NbBuildingFinancedTooHighForEndGame(), NbBuildingFinancedTooHighForTurn());

        
        if (CheckForTimerStart()) //the timer has to start
        {
            GameObject.Find("TimerManager").GetComponent<TimerManager>().StartTimer();
        }
        else
        {
            //here the timer either has to be reset or to be inactive due to the settings
            resetTimer();
        }
    }

    /// <summary>
    /// Changes how the next turn button is displayed
    /// </summary>
    /// <param name="_TurnPressed"></param>
    /// <param name="_NbBuildingFinancedTooHighForEndGame"></param>
    /// <param name="_NbBuildingFinancedTooHighForTurn"></param>
    private void PrintTheGoodNextTurnButton(bool _TurnPressed, bool _NbBuildingFinancedTooHighForEndGame, bool _NbBuildingFinancedTooHighForTurn)
    {
        int nbTurnVote = 0; 
        for (int i = 0; i < GameManager.singleton.players.Count; i++)
        {
            nbTurnVote += (GameManager.singleton.players[i].nextTurn) ? 1:0;
        }


        String DisplayNbTurnVote = nbTurnVote + "/" + GameManager.singleton.players.Count;
        nbNextTurn.text = DisplayNbTurnVote;
        if (!_TurnPressed && !_NbBuildingFinancedTooHighForEndGame && !_NbBuildingFinancedTooHighForTurn)
        {
            TextButton.text = Language.NEXT_TURN;
            TextButton.color = Color.black;
            ButtonNextTurn.interactable = true;
        }
        else if (_NbBuildingFinancedTooHighForEndGame || _NbBuildingFinancedTooHighForTurn)
        {
            TextButton.text = "TROP D'AMÉNAGEMENTS";
            TextButton.color = new Color(0.83f, 0.19f, 0.11f);
            ButtonNextTurn.interactable = false;
        }
        else if (_TurnPressed && (!_NbBuildingFinancedTooHighForEndGame || !_NbBuildingFinancedTooHighForEndGame))
        {
            TextButton.text = Language.CANCEL;
            TextButton.color = Color.black;
            ButtonNextTurn.interactable = true;
        }
    }

    private bool NbBuildingFinancedTooHighForTurn()
    {
        BetControl _betControl = GameObject.Find("playerLocal").GetComponent<BetControl>();
        return FillPlayerView.tooManyBuildingsFinanced(_betControl.NbBuildingsFinanced());
    }

    public void resetTimer()
    {
        TimerManager _timerManager = GameObject.Find("TimerManager").GetComponent<TimerManager>();
        _timerManager.currentTurnTime = GameSettings.TurnTimeMax;
        _timerManager.alreadyStarted = false;
    }

    private bool TimerEnded()
    {
        TimerManager _timerManager = GameObject.Find("TimerManager").GetComponent<TimerManager>();

        return (_timerManager.currentTurnTime <= 0);
    }

    /// <summary>
    /// Checks if the timer can decrease or not depending on the numbers of players who are not ready
    /// and what the admin chose in the settings
    /// </summary>
    /// <returns></returns>
    private bool CheckForTimerStart()
    {
        GameManager gameManager = GameManager.singleton;

        int boucle = 1;
        if (GameSettings.ServeurNonPlayer)
        {
            boucle = 2;
        }
        if (GameSettings.CentralTablet)
        {
            boucle = 3;
        }

        int countPlayersReady = 0;
        bool _OnlyOnePlayerNotReady;
        for (int i = boucle; i < gameManager.players.Count; i++)
        {
            if (gameManager.players[i].nextTurn)
            {
                countPlayersReady++;
            }
        }
        _OnlyOnePlayerNotReady = gameManager.players.Count - countPlayersReady == boucle;  //int i = 3 quand on joue avec le serveur et le plateau
        bool _res = _OnlyOnePlayerNotReady && GameSettings.isTimerActive;

        return _res;

    }


    /// <summary>
    /// Checks if the number of buildings that are financed + those who are built exceeds
    /// the number of buildings required to end the game
    /// </summary>
    public static bool NbBuildingFinancedTooHighForEndGame()
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
        //TextButton.fontSize = 25f;
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
        ResetTableBetPlayers();
        ResetTurnBoolPlayer();                   //Reset des boolean de tour des players
        betControl.CmdGiveBackResourcesToPlayerWhenNextTurn();       // Rendre les ressources aux joueurs pour les aménagements pas financés entièrement.
        DistribScorePlayer();
        betControl.BuildTheBuildings();          // Check les batiment construit, Les ajouter dans la list des batiments construit, Les supprimer du Deck
        ResetFinanceBuildingInMarket();
        gameManager.game.ChangeMarket();         // Changer le marché
        betControl.CmdResetPlayersBet();         // Réinitialiser le tableau des mises de chaques joueurs
        UpdateTurnNumber();                      // Changer le numéro de tour
        LogNextTurn();
        playerSetup.CmdSendActualGameManager();  // Envoyer le nouveau game avec la fonction dans le PlayerSetup
        GameObject.Find("CityManager").GetComponent<FillCity>().SpawnBuildingsBuilt();
        GameObject.Find("CityManager").GetComponent<FillTruckCity>().SpawnTrucks();
        CallCityView();
        GameObject.Find("playerLocal").GetComponent<Player>().InvokePopUP();
    }

    private void ResetTableBetPlayers()
    {
        for (int i = 0; i < GameManager.singleton.players.Count; i++)
        {
            GameManager.singleton.players[i].playerBets = new int[5, 2];
        }
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


    public void LogNextTurn()
    {
        LogManager.singleton.NewTurn();
    }

    public void EndGameLog()
    {
        if (!LogSend)
        {
        Debug.Log("Log Game Upload");
        LogManager.singleton.GetScoreCity();
        LogManager.singleton.SendInfo();
        LogSend = true;
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
        int boucle = 0;
        if (GameSettings.ServeurNonPlayer)
        {
            boucle = 1;
        }
        if (GameSettings.CentralTablet)
        {
            boucle = 2;
        }
        for (int i = boucle; i < gameManager.players.Count; i++) //int i = 2 quand on joue avec le serveur et le plateau
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

    public void CallCityView() {
        GameObject.Find("playerLocal").GetComponent<Player>().CmdCityView();
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
    public void CmdChangeSceneToEndGame()
    {
        NetworkManager.singleton.ServerChangeScene("EndGame");
    } 


    #endregion
}
