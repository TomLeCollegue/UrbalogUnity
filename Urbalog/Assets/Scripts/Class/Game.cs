using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Game
{
  
    public List<Building> Market { get; set; } = new List<Building>();
    public List<Building> DeckBuildings { get; set; } = new List<Building>();
    public List<Role> Roles { get; set; } = new List<Role>();

    public List<Building> BuildingsBuilt = new List<Building>();
    public List<Building> pioche { get; set; } = new List<Building>();
 

    //City Scores
    public int cityAttractiveness = 0;
    public int cityEnvironment = 0;
    public int cityFluidity = 0;
    public int cityLogistic = 0;

    public int turnNumber = 1;

    public float currentTurnTime = 0f;
    public float turnTimeMax= 60f;

    #region Market management

    /// <summary>
    /// Fill pioche with all the buildings that are in the .json file
    /// </summary>
    public void FillPiocheAtTheBeginning()
    {
        if (GameSettings.Language == "Fr")
        {
            pioche = GetPiocheFromJSON("/buildings.json");
            DeckBuildings = GetPiocheFromJSON("/buildings.json"); //Is it useful for logs ?
        }
        else if (GameSettings.Language == "En")
        {
            pioche = GetPiocheFromJSON("/buildingsEN.json");
            DeckBuildings = GetPiocheFromJSON("/buildingsEN.json"); //Is it useful for logs ?
        }
    }

    
    /**
     * <summary>Fills market List with the appropriate Buildings.</summary>
     * TODO: This method has to fill the market with random buildings from the deck
     * */
    public void FillMarket()
    {
        var randomMarket = new System.Random();
        for (int i = 0; i < 5; i++){
            int index = randomMarket.Next((pioche.Count));
            Debug.Log(index);
            while (BuildingInMarket(pioche[index]))
            {
                index = randomMarket.Next((pioche.Count));
            
            }
            Building buildingToAdd = pioche[index];
            Market.Add(buildingToAdd);
        }
    }
    /// <summary>
    /// Shows if buildingpioché is in the market or not.
    /// </summary>
    /// <param name="buildingPioché"></param>
    /// <returns></returns>
    public bool BuildingInMarket(Building buildingPioché)
    {
        for(int i=0;i<(Market.Count);i++)
        {
            if(Market[i].name == buildingPioché.name)
            {
                return true;
            }
        }
        return false;
    }



    /// <summary>
    /// Fills roles list with the different roles and their stats
    /// </summary>
    public void ChangeMarket()
    {
        Debug.Log("tour ChangeMarket");
        Market.Clear();
        FillMarket();
    }

    #endregion

    public void FillRoles()
    {
        if (GameSettings.ServeurNonPlayer)
        {
            Roles.Add(new Role("SERVEUR", "Environment", "Environment", 0, 1, 1));
        }
        if (GameSettings.CentralTablet)
        {
            Roles.Add(new Role("PLATEAU", "Environment", "Environment", 0, 1, 1));
        }
        Roles.Add(new Role("Transporteur", "Attractiveness", "Fluidity", 0, 20, 20));
        Roles.Add(new Role("Habitant", "Fluidity", "Environment", 7, 3, 0));
        Roles.Add(new Role("Collectivité Locale", "Environment", "Attractiveness", 0, 4, 6));
        Roles.Add(new Role("Commerçant", "Fluidity", "Attractiveness", 6, 0, 4));
        Roles.Add(new Role("Opérateur de transport public", "Environment", "Fluidity", 0, 6, 4));
    }

    /// <summary>
    /// Takes the roles used from JSON File to fill the Roles List
    /// </summary>
    public void fillRolesFromJson()
    {
        string _fileName = JSONRoles.RoleFileNameDependingOnLanguage();

        JSONRoles.putRolesArrayInRolesList(JSONRoles.loadRoleFromJson(_fileName), Roles);
    }

    /**
     * <summary>Add valueBet to the correct ressource on the correct building</summary>
     * <param name="_numBuilding">The index of the building that you want to bet on</param>
     * <param name="_ressource">String which is the name of the ressource the bet has been made</param>
     * <param name="_ValueBet">How much we bet</param>
     */
    public void BetOnBuilding(int _numBuilding, string _ressource, int _ValueBet)
    {
        Building building = Market[_numBuilding];

        if (_ressource.Equals("Economical"))
        {
            building.FinanceEconomical += _ValueBet;
        }
        else if (_ressource.Equals("Political"))
        {
            building.FinancePolitical += _ValueBet;
        }
        else
        {
            building.FinanceSocial += _ValueBet;
        }
    }


    public List<Building> GetPiocheFromJSON(string _filename)
    {
        Building[] _jsonarray = JSONBuildings.loadBuildingsFromJSON(_filename);
        List<Building> _BuildingsList = new List<Building>(_jsonarray);

        return _BuildingsList;
    }


}

