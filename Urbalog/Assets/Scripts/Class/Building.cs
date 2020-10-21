using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Building
{
    public string name ;
    public string description ;

    public int Economical ;
    public int Social ;
    public int Political ;
    public int FinanceEconomical ;
    public int FinanceSocial ;
    public int FinancePolitical ;

    public int enviScore ;
    public int fluidScore ;
    public int attractScore ;

    public int logisticScore ;

    public string logisticDescription ;

    public string nameForSprite;


    //Constructor
    public Building(string _name, string _description,
        int _economical, int _social, int _political, int _enviScore,
        int _fluidScore, int _attractScore, int _logisticScore, string _logisticDescription, string _nameForSprite)
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
        nameForSprite = _nameForSprite;

    }

    /// <summary>
    /// Can be use if you need to quickly print a building for a test in a Log
    /// </summary>
    /// <returns></returns>
    public String ToStringForJSON()
    {
        String res = 
                "    {\n" +
                "      \"name\": \""+name+"\",\n" +
                "      \"description\": \""+description+"\",\n" +
                "      \"Couts\": {\n" +
                "        \"politique\": "+Political+",\n" +
                "        \"social\": "+Social+",\n" +
                "        \"economique\": "+Economical+"\n" +
                "      },\n" +
                "      \"Effets\": {\n" +
                "        \"attractivite\": "+attractScore+",\n" +
                "        \"fluidite\": "+fluidScore+",\n" +
                "        \"environnemental\": "+enviScore+"\n" +
                "      },\n" +
                "      \"scoreLogistique\": "+logisticScore+",\n" +
                "      \"explicationLogistique\": \""+logisticDescription+"\"\n" +
                "    \"nomPourSprite\": \"" + nameForSprite + "\"\n" +
                "    }\n";
        return res;
    }

}
