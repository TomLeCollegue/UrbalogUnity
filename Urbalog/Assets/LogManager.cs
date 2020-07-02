using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogManager : MonoBehaviour
{
    public string uuidParty;
    public List<Player> players = new List<Player>();
    public List<Building> DeckBuilding = new List<Building>();
    public List<Turn> Turns = new List<Turn>();



    public void SetUUID()
    {
        uuidParty = Guid.NewGuid().ToString();
    }

    private void Start()
    {
        SetUUID();
    }


}
