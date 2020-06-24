﻿using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NextTurnButton : NetworkBehaviour
{
    public static int NumberBuildingsToEnd = 2;
    public GameObject Panel;
    public TextMeshProUGUI turnNumberText;



    /// <summary>
    /// Change your Next turn bool from a state to an other
    /// </summary>
    public void ClickNextTurn()
    {
        string _id = GameObject.Find("playerLocal").GetComponent<Player>().ID.ToString();
        Debug.Log("nextTurn " + _id);
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
            if (CheckForNextTurn())
            {
                Debug.Log("Cest la fin du tour");
                NextTurn();
            }
        }
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
        betControl.BuildTheBuildings();          // Check les batiment construit, Les ajouter dans la list des batiments construit, Les supprimer du Deck
        betControl.GiveBackResourcesToPlayerWhenNextTurn();       // Rendre les ressources aux joueurs pour les aménagements pas financés entièrement.
        gameManager.game.ChangeMarket();         // Changer le marché
        betControl.ResetPlayersBet();            // Réinitialiser le tableau des mises de chaques joueurs
        UpdateTurnNumber();                      // Changer le numéro de tour
        playerSetup.CmdSendActualGameManager();  // Envoyer le nouveau game avec la fonction dans le PlayerSetup

    }

    /// <summary>
    /// Check if every player want to past the turn
    /// </summary>
    /// <returns></returns>
    private bool CheckForNextTurn()
    { 
        GameManager gameManager = GameManager.singleton;
        bool boolTurn = true;
        for (int i = 0; i < gameManager.players.Count; i++)
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
    /// When NextTurn button is clicked, the cityScorePanel is closed
    /// </summary>
    public void CloseCityScorePanel()
    {
        Panel.SetActive(false);
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

    #region EndGame

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
