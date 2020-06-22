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



    #region Market management
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
        DeckBuildings.Add(new Building("Piste cyclable", "Voie réservée aux cyclistes et protégée du reste de la circulation", 2, 2, 3, 1, 1, 0, 2, 
            "Toute la voie étant protégée de la circulation, cet aménagement crée un obstacle pour la livraison en limitant l'accès au trottoir."));
        DeckBuildings.Add(new Building("Borne vélo", "Borne permettant d'emprunter un vélo en libre service.", 1, 2, 2, 1, -1, 1,-1, "Ces structures créent des obstacles ponctuels pour la livraison en limitant l'accès au trottoir."));
        DeckBuildings.Add(new Building("Terrasse", "Terasse de café ou de restaurant", 1, 2, 1, 1, -2, 1, -3, "Cet aménagement limite l'accès à l'établissement tout en empiétant sur le trottoir et sur le stationnement."));
        DeckBuildings.Add(new Building("Petit magasin", "Petit commerce (-20 salariés)", 2, 4, 1, 0, 1, 2,-1,"Cet aménagement génère du trafic de marchandises : livraisons et déplacement d'achats."));
        DeckBuildings.Add(new Building("Poste", "Bureau de poste", 2, 1, 1, -1, 2, 0, 1, "Cet aménagement permet la livraison des colis en l'absence des destinataires, les flux sont donc consolidés, mais les horaires d'ouverture sont restreints."));
        DeckBuildings.Add(new Building("Grand magasin", "Supermarché ou grande surface spécialisée (+ de 20 salariés)",3,6,2,-1,-2,5,-2,"Ce lieu gènère du trafic de marchandises : livraisons et déplacements d'achats."));
        DeckBuildings.Add(new Building("Zone de rencontre", "Une zone de rencontre est une zone apaisée où la vitesse est limitée à 20km/h, sans trottoirs où tous les usagers de la voirie peuvent se croiser (vélo, autos, piétons, camions, etc...)",2,2,2,2,-1,1,0,
            "L'absence de trottoirs facilite l'accès aux établissements pour les véhicules de livraisons, mais la vitesse limitée réduit l'accessibilité."));
        DeckBuildings.Add(new Building("Réseau de consignes", "Un réseau de consignes automatiques est composé de boites sécurisées permettant le retrait de colis à toute heure",2,3,2,0,2,0,2,
            "Accessible à toute heure, cet aménagement permet la livraison des colis en l'absence des destinataires. Il limite le nombre de véhicules de livraison grâce à la consolidation permise."));
        DeckBuildings.Add(new Building("Dispositif anti-bélier", "Plots en béton disposés devant les batiments pour éviter l'usage de voiture-bélier.",1,1,1,0,-2,1,-2,
            "Ce système interdit l'accès des véhicules aux établissements économiques et aux logements des particuliers."));
        DeckBuildings.Add(new Building("Aire de livraison", "Emplacement réservé à l'arrêt des véhicules pour réaliser une livraison ou un enlèvement de marchandise.",3,1,2,-1,2,-1,1,
            "Cet aménagement offre aux véhicules de livraison la possibilité de stationner. Tout en décongestionnant la voirie, il facilite le travail du livreur."));
        DeckBuildings.Add(new Building("CDU", "Un Centre de Distribution Urbaine est un entrepôt situé en ville qui facilite les livraisons.",3,2,2,2,4,-1,1,
            "Cet aménagement permet la mutualisation des flux des particuliers et des activités. La livraison finale est réalisée avec des véhicules propres. Peut s'articuler avec les autres espaces logistiques (PAV, consignes)."));
        DeckBuildings.Add(new Building("PAV", "un Point d'Accueil des Véhicules est une grande aire de livraison équipée de moyens de manutention à la disposition des livreurs.",2,2,1,-1,4,-3,2,
            "Le stationnement et la manutention son facilités. La livraison est donc plus efficace et les conditions de travail du chauffeur améliorées."));
        DeckBuildings.Add(new Building("Stations GAZ GNV", "Station de recharge au gaz naturel utilisée pour recharger des camions plus propres",2,3,1,2,0,-1,1,
            "Ce dispositif permet aux véhicules au gaz de se recharger et aux transporteurs de rouler même lors des pics de pollution."));
        DeckBuildings.Add(new Building("Banc", "2 Bancs",1,1,1,1,-1,0,-1, "Cet aménagement constitue un obstacle ponctuel pour la livraison en limitant l'accès au trottoir."));
        DeckBuildings.Add(new Building("Zone végétalisée", "Espace vert",1,2,2,4,-4,1,-2,"Cette zone, non franchissable avec des outils de manutention, gêne la livraison.")); 
    }

    /**
     * <summary>Fills roles list with the different roles and their stats</summary>
     * */
  
    public void ChangeMarket()
    {
        Debug.Log("tour ChangeMarket");
        Market.Clear();
        FillMarket();
    }

    #endregion

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

