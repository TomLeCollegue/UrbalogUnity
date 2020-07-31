using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerBackUp
{
    public Role role;

 
    public string namePlayer = "";
    public string playerFamilyName = "";
    public string gender = "";
    public string age = "";
    public string zipcode = "";
    public string company = "";
    public string jobStatus = "";
    public string field = "";
    public string nameRole = "";

    public string ID;
    public bool nextTurn = false;

    public int scorePlayer = 0;
    public int OldScore = 0;


    public int num;

    public PlayerBackUp(Role role, string namePlayer, string playerFamilyName, string gender, string age, string zipcode, string company, string jobStatus, string field, string nameRole, string iD, bool nextTurn, int scorePlayer, int oldScore, int num)
    {
        this.role = role;
        this.namePlayer = namePlayer;
        this.playerFamilyName = playerFamilyName;
        this.gender = gender;
        this.age = age;
        this.zipcode = zipcode;
        this.company = company;
        this.jobStatus = jobStatus;
        this.field = field;
        this.nameRole = nameRole;
        ID = iD;
        this.nextTurn = nextTurn;
        this.scorePlayer = scorePlayer;
        OldScore = oldScore;
        this.num = num;
    }
}
