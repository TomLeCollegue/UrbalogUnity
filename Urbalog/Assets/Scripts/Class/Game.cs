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


    public void FillMarket()
    {
        Market.Add(new Building("Piste cyclable", "Voie réservée aux cyclistes et protégée du reste de la circulation", 2, 2, 3, 1, 1, 0));
        Market.Add(new Building("Borne vélo", "Borne permettant d'emprunter un vélo en libre service", 1, 2, 2, 1, -1, 1));
        Market.Add(new Building("Terrasse", "Terasse de café ou de restaurant", 1, 2, 1, 1, -2, 1));
        Market.Add(new Building("Petit magasin", "Petit commerce (-20 salariés)", 2, 4, 1,0,1,2));
        Market.Add(new Building("Poste", "Bureau de poste", 2, 1, 1, -1, 2, 0));
    }
    public void FillDeckBuildings()
    {
        DeckBuildings.Add(new Building("Piste cyclable", "Voie réservée aux cyclistes et protégée du reste de la circulation", 2, 2, 3, 1, 1, 0));
        DeckBuildings.Add(new Building("Borne vélo", "Borne permettant d'emprunter un vélo en libre service", 1, 2, 2, 1, -1, 1));
        DeckBuildings.Add(new Building("Terrasse", "Terasse de café ou de restaurant", 1, 2, 1, 1, -2, 1));
        DeckBuildings.Add(new Building("Petit magasin", "Petit commerce (-20 salariés)", 2, 4, 1, 0, 1, 2));
        DeckBuildings.Add(new Building("Poste", "Bureau de poste", 2, 1, 1, -1, 2, 0));
    }

    public void FillRoles()
    {
        Roles.Add(new Role("Role1", "Environment", "Fluidity",0, 8, 7));
        Roles.Add(new Role("Role2", "Attractiveness", "Fluidity", 3, 0, 2));
    }


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
