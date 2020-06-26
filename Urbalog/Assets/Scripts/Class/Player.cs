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
    public string ID;


    [SyncVar]
    public bool nextTurn = false;

    [SerializeField]
    [SyncVar]
    public int scorePlayer = 0;
    private int OldScore = 0;

    [SerializeField]
    private int num;


    public void CheckScoreChange()
    {
        if(scorePlayer > OldScore)
        {
            DisplayPopUpWin();
        }
        else
        {
            DisplayPopUpLose();
        }
    }

    private void DisplayPopUpLose()
    {
        return;
    }

    private void DisplayPopUpWin()
    {
        return;
    }
}
