using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Building
{
    private string name;
    private string description;

    private int Economical;
    private int Social;
    private int Political;
    private int FinanceEconomical;
    private int FinanceSocial;
    private int FinancePolitical;

    private int enviScore;
    private int fluidScore;
    private int attractScore;

    public Building(string _name, string _description,
        int _economical, int _social, int _political, int _enviScore,
        int _fluidScore, int _attractScore)
    {
        name = _name;
        description = _description;
        Economical = _economical;
        Social = _social;
        Political = _political;
        enviScore = _enviScore;
        fluidScore = _fluidScore;
        attractScore = _attractScore;

    }

}
