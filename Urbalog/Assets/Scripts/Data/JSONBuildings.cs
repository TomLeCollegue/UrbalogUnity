using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;

public class JSONBuildings : MonoBehaviour
{

    public static List<Building> DefaultDeck = new List<Building>();

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("file : " + Application.dataPath);
        Debug.Log("exists : " + File.Exists(Application.dataPath + "\\buildings.json"));

        FillDeckBuildingTest();
        if (/*!File.Exists(Directory.GetCurrentDirectory() + "\\Assets\\buildings.json")*/
            !File.Exists(Application.dataPath + "\\buildings.json")) //On vérifie si le buildings.json existe
        {
            CreateBuildingsJSONWithDeck(DefaultDeck);
            Debug.Log("fichier Créé");
        }
        else
        {
            Debug.Log("On ne crée pas le fichier");
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
    public static void CreateBuildingsJSONWithDeck(List<Building> _defaultDeck)
    {
        string _jsonBuilding = "";

        Building[] _DeckArray = _defaultDeck.ToArray();

        _jsonBuilding = JsonHelper.ToJson(_DeckArray, true);
        File.WriteAllText(Application.dataPath + "/buildings.json", _jsonBuilding);

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


