using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bet
{
    public int PlayerId;
    public int politic;
    public int econommical;
    public int social;
    public string BuildingName;
    public string dateTime;

    public Bet(int playerId, int politic, int econommical, int social, string buildingName)
    {
        PlayerId = playerId;
        this.politic = politic;
        this.econommical = econommical;
        this.social = social;
        BuildingName = buildingName;
        dateTime = DateTime.Now.ToString();
    }
}
