using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextTurnButton : NetworkBehaviour
{
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
            if (CheckForNextTurn())
            {
                Debug.Log("Cest la fin du tour");

                //Player Boolean to False
                CmdResetTurnBoolPlayer();
            }
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
        for (int i = 0; i < gameManager.game.players.Count; i++)
        {    
            if (!gameManager.game.players[i].nextTurn)
            {
                boolTurn = false;
                
            }
        }
        return boolTurn;
    }

    /// <summary>
    /// Reset the Next turn bools for every player.
    /// </summary>
    private void CmdResetTurnBoolPlayer()
    {
        GameManager gameManager = GameManager.singleton;
        for (int i = 0; i < gameManager.game.players.Count; i++)
        {
            gameManager.game.players[i].nextTurn = false;
        }
    }


    /// <summary>
    /// Goes in BetControl so the city score is updated for all players
    /// </summary>
    public void UpdateCityScore()
    {
        BetControl _betControl = GameObject.Find("playerLocal").GetComponent<BetControl>();
        _betControl.CmdUpdateCityScore();
    }
}
