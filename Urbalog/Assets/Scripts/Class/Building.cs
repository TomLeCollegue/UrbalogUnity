using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Building
{
    public string name { get; set; }
    public string description { get; set; }

    public int Economical { get; set; }
    public int Social { get; set; }
    public int Political { get; set; }
    public int FinanceEconomical { get; set; }
    public int FinanceSocial { get; set; }
    public int FinancePolitical { get; set; }

    public int enviScore { get; set; }
    public int fluidScore { get; set; }
    public int attractScore { get; set; }

    public int logisticScore { get; set; }

    public string logisticDescription { get; set; }


    //Constructor
    public Building(string _name, string _description,
        int _economical, int _social, int _political, int _enviScore,
        int _fluidScore, int _attractScore, int _logisticScore, string _logisticDescription)
    {
        name = _name;
        description = _description;
        Economical = _economical;
        Social = _social;
        Political = _political;
        enviScore = _enviScore;
        fluidScore = _fluidScore;
        attractScore = _attractScore;
        logisticScore = _logisticScore;
        logisticDescription = _logisticDescription;

    }

}
