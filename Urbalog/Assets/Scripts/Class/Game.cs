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


    //All the buildings that are built by the players throughout the game
    public List<Building> BuildingsBuilt { get; set; } = new List<Building>();

    public int cityAttractiveness;
    public int cityEnvironment;
    public int cityFluidity;

    public int turnNumber;
    
    public List<Player> players = new List<Player>();


    /**
     * <summary>Fills market List with the appropriate Buildings.</summary>
     * TODO: This method has to fill the market with random buildings from the deck
     * */
    public void FillMarket()
    {
        Market.Add(new Building("Piste cyclable", "Voie réservée aux cyclistes et protégée du reste de la circulation", 2, 2, 3, 1, 1, 0));
        Market.Add(new Building("Borne vélo", "Borne permettant d'emprunter un vélo en libre service", 1, 2, 2, 1, -1, 1));
        Market.Add(new Building("Terrasse", "Terasse de café ou de restaurant", 1, 2, 1, 1, -2, 1));
        Market.Add(new Building("Petit magasin", "Petit commerce (-20 salariés)", 2, 4, 1,0,1,2));
        Market.Add(new Building("Poste", "Bureau de poste", 2, 1, 1, -1, 2, 0));
    }

    public void FillMarket2()
    {
        Debug.Log("tour fillMarket2");
        Market.Clear();
        Market.Add(new Building("Pyste cyclable", "Voie réservée aux cyclistes et protégée du reste de la circulation", 2, 2, 3, 1, 1, 0));
        Market.Add(new Building("Borne vélo", "Borne permettant d'emprunter un vélo en libre service", 1, 2, 2, 1, -1, 1));
        Market.Add(new Building("Terrasse", "Terasse de café ou de restaurant", 1, 2, 1, 1, -2, 1));
        Market.Add(new Building("Petit magasin", "Petit commerce (-20 salariés)", 2, 4, 1, 0, 1, 2));
        Market.Add(new Building("Poste", "Bureau de poste", 2, 1, 1, -1, 2, 0));
    }

    /// <summary>
    /// All the urbalog buildings
    /// </summary>
    public void FillDeckBuildings()
    {
        DeckBuildings.Add(new Building("Piste cyclable", "Voie réservée aux cyclistes et protégée du reste de la circulation", 2, 2, 3, 1, 1, 0));
        DeckBuildings.Add(new Building("Borne vélo", "Borne permettant d'emprunter un vélo en libre service", 1, 2, 2, 1, -1, 1));
        DeckBuildings.Add(new Building("Terrasse", "Terasse de café ou de restaurant", 1, 2, 1, 1, -2, 1));
        DeckBuildings.Add(new Building("Petit magasin", "Petit commerce (-20 salariés)", 2, 4, 1, 0, 1, 2));
        DeckBuildings.Add(new Building("Poste", "Bureau de poste", 2, 1, 1, -1, 2, 0));
    }

    /**
     * <summary>Fills roles list with the different roles and their stats</summary>
     * */
    public void FillRoles()
    {
        Roles.Add(new Role("Collectivité Locale", "Environment", "Attractiveness", 0, 4, 6));
        Roles.Add(new Role("Habitant", "Fluidity", "Environment", 7, 3, 0));
        Roles.Add(new Role("Transporteur", "Attractiveness", "Fluidity", 0, 3, 7));
        Roles.Add(new Role("Commerçant", "Fluidity", "Attractiveness", 6, 0, 4));
        Roles.Add(new Role("Opérateur de transport public", "Environment", "Fluidity", 0, 6, 4));
    }

    /**
     * <summary>Add valueBet to the correct ressource on the correct building</summary>
     * <param name="numBuilding">The index of the building that you want to bet on</param>
     * <param name="ressource">String which is the name of the ressource the bet has been made</param>
     * <param name="ValueBet">How much we bet</param>
     */
    public void BetOnBuilding(int numBuilding, string ressource, int ValueBet)
    {
        Building building = Market[numBuilding];

        if (ressource.Equals("Economical"))
        {
            building.FinanceEconomical += ValueBet;
        }
        else if (ressource.Equals("Political"))
        {
            building.FinancePolitical += ValueBet;
        }
        else
        {
            building.FinanceSocial += ValueBet;
        }
    }


}
