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

    public List<Building> pioche { get; set; } = new List<Building>();
 
    public int cityAttractiveness = 0;
    public int cityEnvironment = 0;
    public int cityFluidity = 0;

    public int turnNumber = 0;


    /**
     * <summary>Fills market List with the appropriate Buildings.</summary>
     * TODO: This method has to fill the market with random buildings from the deck
     * */
    public void FillMarket()
    {

        pioche = DeckBuildings;
        var randomMarket = new System.Random();
        for (int i = 0; i < 5; i++){
            int index = randomMarket.Next((pioche.Count)-1);
            Debug.Log(index);
            while (BuildingInMarket(pioche[index]))
            {
                index = randomMarket.Next((pioche.Count)-1);
            
            }
            Building buildingToAdd = pioche[index];
            Market.Add(buildingToAdd);
        }
    }

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
    /// All the urbalog buildings
    /// </summary>
    public void FillDeckBuildings()
    {
        DeckBuildings.Add(new Building("Piste cyclable", "Voie réservée aux cyclistes et protégée du reste de la circulation", 2, 2, 3, 1, 1, 0));
        DeckBuildings.Add(new Building("Borne vélo", "Borne permettant d'emprunter un vélo en libre service", 1, 2, 2, 1, -1, 1));
        DeckBuildings.Add(new Building("Terrasse", "Terasse de café ou de restaurant", 1, 2, 1, 1, -2, 1));
        DeckBuildings.Add(new Building("Petit magasin", "Petit commerce (-20 salariés)", 2, 4, 1, 0, 1, 2));
        DeckBuildings.Add(new Building("Poste", "Bureau de poste", 2, 1, 1, -1, 2, 0));
        DeckBuildings.Add(new Building("Grand magasin", "Supermarché ou grande surface spécialisée (+ de 20 salariés)",3,6,2,-1,-2,5));
        DeckBuildings.Add(new Building("Zone de rencontre", "Une zone de rencontre est une zone apaisée où la vitesse est limitée à 20km/h, sans trottoirs où tous les usagers de la voirie peuvent se croiser (vélo, autos, piétons, camions, etc...)",2,2,2,2,-1,1));
        DeckBuildings.Add(new Building("Réseau de consignes", "Un réseau de consignes automatiques est composé de boites sécurisées permettant le retrait de colis à toute heure",2,3,2,0,2,0));
        DeckBuildings.Add(new Building("Dispositif anti-bélier", "Plots en béton disposés devant les batiments pour éviter l'usage de voiture-bélier",1,1,1,0,-2,1));
        DeckBuildings.Add(new Building("Aire de livraison", "Emplacement réservé à l'arrêt des véhicules pour réaliser une livraison ou un enlèvement de marchandise",3,1,2,-1,2,-1));
        DeckBuildings.Add(new Building("CDU", "Un Centre de Distribution Urbaine est un entrepôt situé en ville qui facilite les livraisons",3,2,2,2,4,-1));
        DeckBuildings.Add(new Building("PAV", "un Point d'Accueil des Véhicules est une grande aire de livraison équipée de moyens de manutention à la disposition des livreurs",2,2,1,-1,4,-3));
        DeckBuildings.Add(new Building("Stations GAZ GNV", "Station de recharge au gaz naturel utilisée pour recharger des camions plus propres",2,3,1,2,0,-1));
        DeckBuildings.Add(new Building("Banc", "2 Bancs",1,1,1,1,-1,0));
        DeckBuildings.Add(new Building("Zone végétalisée", "Espace vert",1,2,2,4,-4,1)); 
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
