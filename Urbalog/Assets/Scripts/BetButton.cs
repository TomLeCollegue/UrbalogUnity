
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This contains the behavior for the '-' and '+' button in BetPanel
/// </summary>
public class BetButton : MonoBehaviour
{
    /// <summary>
    /// Sends to the <see cref="BetControl"/> class the number of the building the player
    /// clicked on. Which is the building he will potentially bet.
    /// </summary>
    /// <param name="_num">the index of the building the player clicked on to open BetPanel</param>
    public void ChangeNumberButton(int _num)
    {
        BetControl betControl = GameObject.Find("playerLocal").GetComponent<BetControl>();
        betControl.ChangeNumBuildingBet(_num);
        
    }

    /// <summary>
    /// Finds the Building the player is betting on and the player role
    /// then send +1 or -1 to <see cref="BetControl"/> for a +1 bet or a -1 bet.
    /// It's for the first resource in BetPanel
    /// </summary>
    /// <param name="value">if -1 then player wanted to take back his resource
    /// if +1 then player wanted to bet 1 resource</param>
    public void CallBetInPlayerRessource1InPlayer(int value)
    {
        BetControl betControl = GameObject.Find("playerLocal").GetComponent<BetControl>();
        Role role = GameObject.Find("playerLocal").GetComponent<Player>().role;
        betControl.VerifBet(value, role.ressource1);
    }

    /// <summary>
    /// Finds the Building the player is betting on and the player role
    /// then send +1 or -1 to <see cref="BetControl"/> for a +1 bet or a -1 bet.
    /// It's for the second resource in BetPanel
    /// </summary>
    /// <param name="value">if -1 then player wanted to take back his resource
    /// if +1 then player wanted to bet 1 resource</param>
    public void CallBetInPlayerRessource2InPlayer(int value)
    {
        BetControl betControl = GameObject.Find("playerLocal").GetComponent<BetControl>();
        Role role = GameObject.Find("playerLocal").GetComponent<Player>().role;
        betControl.VerifBet(value, role.ressource2);
    }


}
