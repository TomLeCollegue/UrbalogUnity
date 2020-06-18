using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextTurnButton : NetworkBehaviour
{
    
    public void ClickNextTurn()
    {
        string _id = GameObject.Find("playerLocal").GetComponent<Player>().ID.ToString();
        Debug.Log("nextTurn " + _id);
        GameObject.Find("playerLocal").GetComponent<PlayerSetup>().CmdChangeBoolNextTurn(_id);
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
