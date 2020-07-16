using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

[Serializable]
public class Player : NetworkBehaviour 
{
    public Role role { get; set; }

    [SerializeField]
    [SyncVar]
    public string namePlayer = "nom";

    [SyncVar]
    public string playerFamilyName = "";
    [SyncVar]
    public string gender = "";
    [SyncVar]
    public string age = "";
    [SyncVar]
    public string zipcode = "";
    [SyncVar]
    public string company = "";
    [SyncVar]
    public string jobStatus = "";
    [SyncVar]
    public string field = "";
    [SyncVar]
    public string nameRole = "";

    public string ID;


    [SyncVar]
    public bool nextTurn = false;

    [SerializeField]
    [SyncVar]
    public int scorePlayer = 0;
    private int OldScore = 0;

    [SerializeField]
    private int num;

    [Command]
    public void CmdScore()
    {
        RpcCheckScoreChange();
    }

    [ClientRpc]
    public void RpcCheckScoreChange()
    {
        Player player = GameObject.Find("playerLocal").GetComponent<Player>();
        Debug.Log("PopUp Win or Lose");
        if(player.role.nameRole.Equals("SERVEUR") || player.role.nameRole.Equals("PLATEAU"))
        {
            return;
        }

        if(player.scorePlayer > player.OldScore)
        {
            DisplayPopUpWin();
            player.OldScore = player.scorePlayer;
        }
        else
        {
            DisplayPopUpLose();
            player.OldScore = scorePlayer;
        }
    }

    private void DisplayPopUpLose()
    {
        Debug.Log("Perdu");
        GameObject.Find("PlayerViewManager").GetComponent<PopUpScoreManager>().OpenPopUpLose();
    }

    private void DisplayPopUpWin()
    {
        Debug.Log("Gagné");
        GameObject.Find("PlayerViewManager").GetComponent<PopUpScoreManager>().OpenPopUpWin();
    }


    [Command]
    public void CmdCityView()
    {
        RpcClientOnCityView();
    }

    [ClientRpc]
    public void RpcClientOnCityView()
    {
        GameObject.Find("PlayerViewManager").GetComponent<CityScoreButton>().OpenPanel();
    }



    public void InvokePopUP()
    {
        Invoke("CmdScore", 2);
    }

}
