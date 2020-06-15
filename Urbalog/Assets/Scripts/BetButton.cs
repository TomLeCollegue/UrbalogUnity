
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetButton : MonoBehaviour
{
    
    public void ChangeNumberButton(int _num)
    {
        BetControl betControl = GameObject.Find("playerLocal").GetComponent<BetControl>();
        betControl.ChangeNumBuildingBet(_num);
        
    }

    public void CallBetInPlayerRessource1InPlayer(int value)
    {
        BetControl betControl = GameObject.Find("playerLocal").GetComponent<BetControl>();
        Role role = GameObject.Find("playerLocal").GetComponent<Player>().role;
        betControl.VerifBet(value, role.ressource1);
    }
    public void CallBetInPlayerRessource2InPlayer(int value)
    {
        BetControl betControl = GameObject.Find("playerLocal").GetComponent<BetControl>();
        Role role = GameObject.Find("playerLocal").GetComponent<Player>().role;
        betControl.VerifBet(value, role.ressource2);
    }


}
