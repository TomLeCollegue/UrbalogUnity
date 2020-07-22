using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONBuildings : MonoBehaviour
{

    public List<Building> DefaultDeck = new List<Building>();

    // Start is called before the first frame update
    void Start()
    {
        FillDeckBuildingTest();
        if (!File.Exists(Directory.GetCurrentDirectory() + "\\Assets\\buildings.json")) //On vérifie si le buildings.json existe
        {
            CreateBuildingsJSONWithDeck();
            Debug.Log("fichier Créé");
        }
        else
        {
            Debug.Log("On ne crée pas le fichier");
        }


        //Debug.Log(File.Exists("/buildings.json") + " json avant");
        //     //public static bool Exists(string path);
        //CreateBuildingsJSONWithDeck();
        //Debug.Log(File.Exists("/buildings.json") + " json après");
        //Debug.Log(Directory.GetCurrentDirectory());
        //Debug.Log(File.Exists(Directory.GetCurrentDirectory()+ "\\Assets\\buildings.json") + " json après absolute : "
        //    + Directory.GetCurrentDirectory()+"\\Assets\\buildings.json");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Takes the Deck List and puts it in a JSON File.
    /// Will be useful when the admin wants to reset his modifications on all the buildings.
    /// </summary>
    public void CreateBuildingsJSONWithDeck()
    {
        string _jsonBuilding = "";

        Building[] _DeckArray = DefaultDeck.ToArray();

        _jsonBuilding = JsonHelper.ToJson(_DeckArray, true);
        File.WriteAllText(Application.dataPath + "/buildings.json", _jsonBuilding);

        //LOAD

        //string _stringFromJSON = File.ReadAllText(Application.dataPath + "/buildings.json");
        //Building[] _buildingsFromJSON = JsonHelper.FromJson<Building>(_stringFromJSON);

    }

    public static void CreateBuildingJSONWithBuildings(Building[] _buildings)
    {
        string _jsonBuilding = JsonHelper.ToJson(_buildings, true);
        File.WriteAllText(Application.dataPath + "/buildings.json", _jsonBuilding);
    }

    /// <summary>
    /// Takes the Deck List which is in this file and puts it in the JSON.
    /// So all the modifications the admin made on the buildings are gone.
    /// </summary>
    public void resetDeckToDefault()
    {
        Building[] _DeckArray = DefaultDeck.ToArray();

        string _jsonBuildings = JsonHelper.ToJson(_DeckArray, true);
        File.WriteAllText(Application.dataPath + "/buildings.json", _jsonBuildings);
    }

    /// <summary>
    /// Reads a JSON file and sends a building[] depending on this JSON
    /// </summary>
    /// <param name="_fileName">the filename for the json file</param>
    /// <returns>return an array of all the buildings in the JSON, note that it is an Array, and not a List.</returns>
    public static Building[] loadBuildingsFromJSON(string _fileName)
    {
        string _buildingsFromJSONInStrings = File.ReadAllText(Application.dataPath + _fileName);

        Building[] _buildingsFromJSON = JsonHelper.FromJson<Building>(_buildingsFromJSONInStrings);
        
        return _buildingsFromJSON;
    }

    /// <summary>
    /// All the urbalog buildings
    /// </summary>
    public void FillDeckBuildingTest()
    {
        DefaultDeck.Add(new Building("Piste cyclable", "Voie réservée aux cyclistes et protégée du reste de la circulation", 2, 2, 3, 1, 1, 0, 2,
            "Toute la voie étant protégée de la circulation, cet aménagement crée un obstacle pour la livraison en limitant l'accès au trottoir."));
        DefaultDeck.Add(new Building("Borne vélo", "Borne permettant d'emprunter un vélo en libre service.", 1, 2, 2, 1, -1, 1, -1, "Ces structures créent des obstacles ponctuels pour la livraison en limitant l'accès au trottoir."));
        DefaultDeck.Add(new Building("Terrasse", "Terrasse de café ou de restaurant", 1, 2, 1, 1, -2, 1, -3, "Cet aménagement limite l'accès à l'établissement tout en empiétant sur le trottoir et sur le stationnement."));
        DefaultDeck.Add(new Building("Petit magasin", "Petit commerce (-20 salariés)", 2, 4, 1, 0, 1, 2, -1, "Cet aménagement génère du trafic de marchandises : livraisons et déplacement d'achats."));
        DefaultDeck.Add(new Building("Poste", "Bureau de poste", 2, 1, 1, -1, 2, 0, 1, "Cet aménagement permet la livraison des colis en l'absence des destinataires, les flux sont donc consolidés, mais les horaires d'ouverture sont restreints."));
        DefaultDeck.Add(new Building("Grand magasin", "Supermarché ou grande surface spécialisée (+ de 20 salariés)", 3, 6, 2, -1, -2, 5, -2, "Ce lieu gènère du trafic de marchandises : livraisons et déplacements d'achats."));
        DefaultDeck.Add(new Building("Zone de rencontre", "Une zone de rencontre est une zone apaisée où la vitesse est limitée à 20km/h, sans trottoirs où tous les usagers de la voirie peuvent se croiser (vélo, autos, piétons, camions, etc...)", 2, 2, 2, 2, -1, 1, 0,
            "L'absence de trottoirs facilite l'accès aux établissements pour les véhicules de livraisons, mais la vitesse limitée réduit l'accessibilité."));
        DefaultDeck.Add(new Building("Réseau de consignes", "Un réseau de consignes automatiques est composé de boites sécurisées permettant le retrait de colis à toute heure", 2, 3, 2, 0, 2, 0, 2,
            "Accessible à toute heure, cet aménagement permet la livraison des colis en l'absence des destinataires. Il limite le nombre de véhicules de livraison grâce à la consolidation permise."));
        DefaultDeck.Add(new Building("Dispositif anti-bélier", "Plots en béton disposés devant les batiments pour éviter l'usage de voiture-bélier.", 1, 1, 1, 0, -2, 1, -2,
            "Ce système interdit l'accès des véhicules aux établissements économiques et aux logements des particuliers."));
        DefaultDeck.Add(new Building("Aire de livraison", "Emplacement réservé à l'arrêt des véhicules pour réaliser une livraison ou un enlèvement de marchandise.", 3, 1, 2, -1, 2, -1, 1,
            "Cet aménagement offre aux véhicules de livraison la possibilité de stationner. Tout en décongestionnant la voirie, il facilite le travail du livreur."));
        DefaultDeck.Add(new Building("CDU", "Un Centre de Distribution Urbaine est un entrepôt situé en ville qui facilite les livraisons.", 3, 2, 2, 2, 4, -1, 1,
            "Cet aménagement permet la mutualisation des flux des particuliers et des activités. La livraison finale est réalisée avec des véhicules propres. Peut s'articuler avec les autres espaces logistiques (PAV, consignes)."));
        DefaultDeck.Add(new Building("PAV", "un Point d'Accueil des Véhicules est une grande aire de livraison équipée de moyens de manutention à la disposition des livreurs.", 2, 2, 1, -1, 4, -3, 2,
            "Le stationnement et la manutention son facilités. La livraison est donc plus efficace et les conditions de travail du chauffeur améliorées."));
        DefaultDeck.Add(new Building("Stations GAZ GNV", "Station de recharge au gaz naturel utilisée pour recharger des camions plus propres", 2, 3, 1, 2, 0, -1, 1,
            "Ce dispositif permet aux véhicules au gaz de se recharger et aux transporteurs de rouler même lors des pics de pollution."));
        DefaultDeck.Add(new Building("Banc", "2 Bancs", 1, 1, 1, 1, -1, 0, -1, "Cet aménagement constitue un obstacle ponctuel pour la livraison en limitant l'accès au trottoir."));
        DefaultDeck.Add(new Building("Zone végétalisée", "Espace vert", 1, 2, 2, 4, -4, 1, -2, "Cette zone, non franchissable avec des outils de manutention, gêne la livraison."));
    }

}


