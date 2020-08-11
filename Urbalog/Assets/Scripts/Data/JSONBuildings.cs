using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;

public class JSONBuildings : MonoBehaviour
{

    public static List<Building> DefaultDeck = new List<Building>();
    public static List<Building> DefaultDeckEN = new List<Building>();

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("file : " + Application.dataPath);
        //Debug.Log("exists : " + File.Exists(Application.dataPath + "\\buildings.json"));

        FillDeckBuildingTest();
        FillDeckBuildingEN();
        if (!File.Exists(Application.dataPath + "\\buildings.json")) //On vérifie si le buildings.json existe
        {
            CreateBuildingsJSONWithDeck("/buildings.json",DefaultDeck);
            Debug.Log("fichier Créé - fr");
        }
        else
        {
            Debug.Log("On ne crée pas le fichier - fr");
        }

        if (!File.Exists(Application.dataPath + "\\buildingsEN.json"))
        {
            CreateBuildingsJSONWithDeck("/buildingsEN.json",DefaultDeckEN);
            Debug.Log("fichier Créé - en");
        }
        else
        {
            Debug.Log("on ne crée pas le fichier - en");
        }
}


    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Takes the Deck List and puts it in a JSON File.
    /// Will be useful when the admin wants to reset his modifications on all the buildings.
    /// </summary>
    public static void CreateBuildingsJSONWithDeck(string _fileName, List<Building> _defaultDeck)
    {
        string _jsonBuilding = "";

        Building[] _DeckArray = _defaultDeck.ToArray();

        _jsonBuilding = JsonHelper.ToJson(_DeckArray, true);
        //File.WriteAllText(Application.dataPath + "/buildings.json", _jsonBuilding);
        File.WriteAllText(Application.dataPath + _fileName, _jsonBuilding);

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

    public static string BuildingArrayToString(Building[] _buildings)
    {
        string _result = "";
        for (int i = 0; i < _buildings.Length; i++)
        {
            _result = _result + _buildings[i].name + "\n";
        }
        return _result + "\n";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_buildings"></param>
    /// <returns></returns>
    public static string BuildingListToString(List<Building> _buildings)
    {
        string _result = "";

        for (int i = 0; i < _buildings.Count; i++)
        {
            _result += _buildings[i].name + "\n";
        }

        return _result + "\n";
    }

    /// <summary>
    /// takes a building in argument and deletes it from JSON
    /// </summary>
    /// <param name="_building"></param>
    public static void DeleteBuildingFromJSON(Building _building)
    {
        Building[] _buildingsFromJson = loadBuildingsFromJSON("/buildings.json");
        //Building[] _buildingsFromJson = loadBuildingsFromJSON(Directory.GetCurrentDirectory() + "\\Assets\\buildings.json");
        Building[] _newBuildingsFromJson;
        int index;

        index = findIndexInArray(_buildingsFromJson,_building);

        _newBuildingsFromJson = DeleteBuildingFromIndex(_buildingsFromJson, index);

        Debug.Log("delete index :" + index);

        Debug.Log("new array + " + BuildingArrayToString(_newBuildingsFromJson));


        CreateBuildingJSONWithBuildings(_newBuildingsFromJson); //recreate json file with the new array

    }

    /// <summary>
    /// Find the index of a building in a given array
    /// returns -1 if not in the array
    /// </summary>
    /// <param name="_buildingsFromJson"></param>
    /// <param name="_building"></param>
    /// <returns></returns>
    private static int findIndexInArray(Building[] _buildingsFromJson, Building _building)
    {
        for (int i = 0; i < _buildingsFromJson.Length; i++)
        {
            if (_building.name == _buildingsFromJson[i].name)
            {
                return i;
            }
        }
        return -1;
    }


    /// <summary>
    /// Takes a building and deletes it from an array
    /// </summary>
    /// <param name="_buildingsFromJson"></param>
    /// <returns></returns>
    private static Building[] DeleteBuildingFromIndex(Building[] _buildingsFromJson, int _indexOfBuilding)
    {
        Building[] _result = new Building[_buildingsFromJson.Length - 1];
        Debug.Log("base array length" + _buildingsFromJson.Length);
        Debug.Log("res array length" + _result.Length);

        for (int i = 0; i < _result.Length ; i++)
        {
            if (i < _indexOfBuilding)
            {
                _result[i] = _buildingsFromJson[i];
            }
            else if (i >= _indexOfBuilding)
            {
                _result[i] = _buildingsFromJson[i + 1];
            }
        }
        Debug.Log("json "+BuildingArrayToString(_buildingsFromJson));
        Debug.Log("après delete "+BuildingArrayToString(_result));
        return _result;
    }

    /// <summary>
    /// takes a building and adds it to the json file
    /// </summary>
    /// <param name="_buildingToAdd"></param>
    internal static void AddInJson(Building _buildingToAdd)
    {
        //load the current list
        Building[] _buildingsFromJson = loadBuildingsFromJSON("/buildings.json");
        //Building[] _buildingsFromJson = loadBuildingsFromJSON(Directory.GetCurrentDirectory() + "\\Assets\\buildings.json");

        //Create a new list with _buildingToAdd at the end
        Building[] _newBuildings = AddBuildingToArray(_buildingsFromJson,_buildingToAdd);

        //Create a new JSON file with the new list
        CreateBuildingJSONWithBuildings(_newBuildings);
    }

    /// <summary>
    /// add the building to an array and return the array created
    /// </summary>
    /// <param name="_buildingsFromJson"></param>
    /// <param name="_buildingToAdd"></param>
    /// <returns></returns>
    private static Building[] AddBuildingToArray(Building[] _buildingsFromJson, Building _buildingToAdd)
    {
        Building[] _result = new Building[_buildingsFromJson.Length + 1];

        for (int i = 0; i < _buildingsFromJson.Length; i++)
        {
            _result[i] = _buildingsFromJson[i];
        }
        _result[_result.Length - 1] = _buildingToAdd;

        return _result;
    }

    /// <summary>
    /// All the urbalog buildings
    /// </summary>
    public void FillDeckBuildingTest()
    {

        DefaultDeck.Clear();
        DefaultDeck.Add(new Building("Piste cyclable", "Voie réservée aux cyclistes et protégée du reste de la circulation", 2, 2, 3, 1, 1, 0, 2,
            "Toute la voie étant protégée de la circulation, cet aménagement crée un obstacle pour la livraison en limitant l'accès au trottoir.", "Piste cyclable"));
        DefaultDeck.Add(new Building("Borne vélo", "Borne permettant d'emprunter un vélo en libre service.", 1, 2, 2, 1, -1, 1, -1, "Ces structures créent des obstacles ponctuels pour la livraison en limitant l'accès au trottoir.", "Borne vélo"));
        DefaultDeck.Add(new Building("Terrasse", "Terrasse de café ou de restaurant", 1, 2, 1, 1, -2, 1, -3, "Cet aménagement limite l'accès à l'établissement tout en empiétant sur le trottoir et sur le stationnement.", "Terrasse"));
        DefaultDeck.Add(new Building("Petit magasin", "Petit commerce (-20 salariés)", 2, 4, 1, 0, 1, 2, -1, "Cet aménagement génère du trafic de marchandises : livraisons et déplacement d'achats.", "Petit magasin"));
        DefaultDeck.Add(new Building("Poste", "Bureau de poste", 2, 1, 1, -1, 2, 0, 1, "Cet aménagement permet la livraison des colis en l'absence des destinataires, les flux sont donc consolidés, mais les horaires d'ouverture sont restreints.", "Poste"));
        DefaultDeck.Add(new Building("Grand magasin", "Supermarché ou grande surface spécialisée (+ de 20 salariés)", 3, 6, 2, -1, -2, 5, -2, "Ce lieu gènère du trafic de marchandises : livraisons et déplacements d'achats.", "Grand magasin"));
        DefaultDeck.Add(new Building("Zone de rencontre", "Une zone de rencontre est une zone apaisée où la vitesse est limitée à 20km/h, sans trottoirs où tous les usagers de la voirie peuvent se croiser (vélo, autos, piétons, camions, etc...)", 2, 2, 2, 2, -1, 1, 0,
            "L'absence de trottoirs facilite l'accès aux établissements pour les véhicules de livraisons, mais la vitesse limitée réduit l'accessibilité.", "Zone de rencontre"));
        DefaultDeck.Add(new Building("Réseau de consignes", "Un réseau de consignes automatiques est composé de boites sécurisées permettant le retrait de colis à toute heure", 2, 3, 2, 0, 2, 0, 2,
            "Accessible à toute heure, cet aménagement permet la livraison des colis en l'absence des destinataires. Il limite le nombre de véhicules de livraison grâce à la consolidation permise.", "Réseau de consignes"));
        DefaultDeck.Add(new Building("Dispositif anti-bélier", "Plots en béton disposés devant les batiments pour éviter l'usage de voiture-bélier.", 1, 1, 1, 0, -2, 1, -2,
            "Ce système interdit l'accès des véhicules aux établissements économiques et aux logements des particuliers.", "Dispositif anti-bélier"));
        DefaultDeck.Add(new Building("Aire de livraison", "Emplacement réservé à l'arrêt des véhicules pour réaliser une livraison ou un enlèvement de marchandise.", 3, 1, 2, -1, 2, -1, 1,
            "Cet aménagement offre aux véhicules de livraison la possibilité de stationner. Tout en décongestionnant la voirie, il facilite le travail du livreur.", "Aire de livraison"));
        DefaultDeck.Add(new Building("CDU", "Un Centre de Distribution Urbaine est un entrepôt situé en ville qui facilite les livraisons.", 3, 2, 2, 2, 4, -1, 1,
            "Cet aménagement permet la mutualisation des flux des particuliers et des activités. La livraison finale est réalisée avec des véhicules propres. Peut s'articuler avec les autres espaces logistiques (PAV, consignes).", "CDU"));
        DefaultDeck.Add(new Building("PAV", "un Point d'Accueil des Véhicules est une grande aire de livraison équipée de moyens de manutention à la disposition des livreurs.", 2, 2, 1, -1, 4, -3, 2,
            "Le stationnement et la manutention son facilités. La livraison est donc plus efficace et les conditions de travail du chauffeur améliorées.", "PAV"));
        DefaultDeck.Add(new Building("Stations GAZ GNV", "Station de recharge au gaz naturel utilisée pour recharger des camions plus propres", 2, 3, 1, 2, 0, -1, 1,
            "Ce dispositif permet aux véhicules au gaz de se recharger et aux transporteurs de rouler même lors des pics de pollution.", "Stations GAZ GNV"));
        DefaultDeck.Add(new Building("Banc", "2 Bancs", 1, 1, 1, 1, -1, 0, -1, "Cet aménagement constitue un obstacle ponctuel pour la livraison en limitant l'accès au trottoir.", "Banc"));
        DefaultDeck.Add(new Building("Zone végétalisée", "Espace vert", 1, 2, 2, 4, -4, 1, -2, "Cette zone, non franchissable avec des outils de manutention, gêne la livraison.", "Zone végétalisée"));
    }

    public void FillDeckBuildingEN()
    {

        DefaultDeckEN.Clear();
        DefaultDeckEN.Add(new Building("Cycle lane", "Lane reserved for cyclists and protected from other traffic", 2, 2, 3, 1, 1, 0, 2,
            "As the entire lane is protected from traffic, this infrastructure creates an obstacle to deliveries by limiting the access to sidewalks.", "Piste cyclable"));
        DefaultDeckEN.Add(new Building("Bike self service dock", "Terminal for borrowing a self-service bicycle", 1, 2, 2, 1, -1, 1, -1, "These structures create punctual obstacles to deliveries by limiting access to the sidewalk.", "Borne vélo"));
        DefaultDeckEN.Add(new Building("Terrace", "Cafe or restaurant terrace", 1, 2, 1, 1, -2, 1, -3, " This development limits access to the facility while exten-ding on the sidewalk and parking slot.", "Terrasse"));
        DefaultDeckEN.Add(new Building("Shop", "Small business (less then 20 employees)", 2, 4, 1, 0, 1, 2, -1, "This activity generates goods traffic: deliveries and pur-chase trips.", "Petit magasin"));
        DefaultDeckEN.Add(new Building("Post office", "Allows the collection of parcels by private individuals.", 2, 1, 1, -1, 2, 0, 1, "This development allows parcels to be delivered in the absence of recipients, so flows are consolidated, but opening hours are restricted.", "Poste"));
        DefaultDeckEN.Add(new Building("Department store", "Supermarket or department store (more than 20 employees)", 3, 6, 2, -1, -2, 5, -2, "This location generates goods movements: deliveries and purchase trips.", "Grand magasin"));
        DefaultDeckEN.Add(new Building("Shared space", "A shared space minimises the segregation between road users (trucks, cars, cycles, pedestrians ... ). There is no sidewalk, traffic signs or lights and speed is limited to 12 mph", 2, 2, 2, 2, -1, 1, 0,
            "The absence of sidewalks facilitates access to facilities for delivery vehicles, but limited speed reduces accessibility", "Zone de rencontre"));
        DefaultDeckEN.Add(new Building("Delivery lockers", "Network of secure boxes allowing the collection of parcels at any time of the day or night", 2, 3, 2, 0, 2, 0, 2,
            "Accessible at any time of the day, this arrangement allows parcels to be delivered in the absence of the recipients. It limits the number of delivery vehicles through consolidation.", "Réseau de consignes"));
        DefaultDeckEN.Add(new Building("Bollards", "Concrete blocks in front of buildings to avoid the use of ram cars.", 1, 1, 1, 0, -2, 1, -2,
            "This system prohibits vehicle access to establishments and residents.", "Dispositif anti-bélier"));
        DefaultDeckEN.Add(new Building("Delivery area", "Space reserved for stopping vehicles to deliver or collect goods.", 3, 1, 2, -1, 2, -1, 1,
            "This facility provides parking for delivery vehicles. While relieving congestion on the road, it facilitates the work of the delivery person.", "Aire de livraison"));
        DefaultDeckEN.Add(new Building("UCC", "An Urban Consolidation Centre is a warehouse located in town to facilitate delivery.", 3, 2, 2, 2, 4, -1, 1,
            "This development allows the pooling of freight flows. The final delivery is made with clean vehicles. Can be linked with other logistics areas (VRP, lockers).", "CDU"));
        DefaultDeckEN.Add(new Building("VRP", "A VRP is a large delivery area equipped with handling facilities for the delivery men.", 2, 2, 1, -1, 4, -3, 2,
            "Parking and handling are facilitated. As a result, delivery is more efficient and the driver’s working conditions are improved.", "PAV"));
        DefaultDeckEN.Add(new Building("NGV station", "Natural gas charging station used to refill cleaner trucks.", 2, 3, 1, 2, 0, -1, 1,
            "This equipment allows gas vehicles to be recharged and carriers to operate even during pollution peak periods.", "Stations GAZ GNV"));
        DefaultDeckEN.Add(new Building("Benches", "2 benches", 1, 1, 1, 1, -1, 0, -1, "This development constitutes a punctual obstacle to delive-ries by limiting access to the sidewalk.", "Banc"));
        DefaultDeckEN.Add(new Building("Green space", "Urban open space", 1, 2, 2, 4, -4, 1, -2, "This area, which cannot be crossed with handling tools, hinders delivery.", "Zone végétalisée"));
    }


}



