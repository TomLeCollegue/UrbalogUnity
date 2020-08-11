using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JSONRoles : MonoBehaviour
{
    public static List<Role> DefaultRoles = new List<Role>();
    public static List<Role> DefaultRolesEN = new List<Role>();

    public static List<Role> CurrentRoles = new List<Role>();
    public static List<Role> CurrentRolesEN = new List<Role>();

    // Start is called before the first frame update
    void Start()
    {
        FillRoles();
        FillRolesEN();
        if (!File.Exists(Application.dataPath + "\\roles.json")) //On vérifie si le buildings.json existe
        {
            CreateRoleJSONWithRolesList(DefaultRoles, "/roles.json");
            Debug.Log("fichier role Créé fr");
            CurrentRoles = new List<Role>(DefaultRoles);
        }
        else
        {
            Debug.Log("On ne crée pas le fichier role fr");
            //récupérer les roles provenant du json
            putRolesArrayInRolesList(loadRoleFromJson("/roles.json"), CurrentRoles);
        }

        if (!File.Exists(Application.dataPath + "\\rolesEN.json"))
        {
            CreateRoleJSONWithRolesList(DefaultRolesEN, "/rolesEN.json");
            CurrentRolesEN = new List<Role>(DefaultRolesEN);
            Debug.Log("fichier role Créé en");
        }
        else
        {
            Debug.Log("On ne crée pas le fichier role en");
            putRolesArrayInRolesList(loadRoleFromJson("/rolesEN.json"), CurrentRolesEN);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Takes the default role list and creates a JSON file with it.
    /// Will be useful when we will want to reset role modifications to default.
    /// </summary>
    /// <param name="_roles"></param>
    /// <param name="_fileName"></param>
    public static void CreateRoleJSONWithRolesList(List<Role> _roles, string _fileName)
    {
        string _jsonRoles = "";

        Role[] _RolesArray = _roles.ToArray();
        _jsonRoles = JsonHelper.ToJson(_RolesArray, true);
        File.WriteAllText(Application.dataPath + _fileName, _jsonRoles);

    }

    /// <summary>
    /// the json JSON file named _filename and creates a Building Array with it.
    /// </summary>
    /// <param name="_filename"></param>
    /// <returns></returns>
    public static Role[] loadRoleFromJson(string _filename)
    {
        string _rolesFromJSONInStrings = File.ReadAllText(Application.dataPath + _filename);

        Role[] _rolesFromJSON = JsonHelper.FromJson<Role>(_rolesFromJSONInStrings);
        return _rolesFromJSON;
    }

    /// <summary>
    /// takes the rolesArray in parameter and puts all the buildings in the roles list in game.
    /// </summary>
    /// <param name="_rolesArray"></param>
    public static void putRolesArrayInRolesList(Role[] _rolesArray, List<Role> _Roles)
    {
        _Roles.Clear();

        if (GameSettings.ServeurNonPlayer)
        {
            _Roles.Add(new Role("SERVEUR", "Environment", "Environment", 0, 1, 1));
            //TODO: working in English
        }
        if (GameSettings.CentralTablet)
        {
            _Roles.Add(new Role("PLATEAU", "Environment", "Environment", 0, 1, 1));
            //TODO: working in English
        }
        for (int i = 0; i < _rolesArray.Length; i++)
        {
            _Roles.Add(new Role(_rolesArray[i].nameRole, _rolesArray[i].hold, _rolesArray[i].improve, 
                _rolesArray[i].ressourceSocial, _rolesArray[i].ressourcePolitical, _rolesArray[i].ressourceEconomical));
        }
    }

    /// <summary>
    /// takes the rolesArray in parameter and puts all the buildings in the roles list in game.
    /// </summary>
    /// <param name="_rolesArray"></param>
    public static List<Role> returnRolesArrayInRolesList(Role[] _rolesArray)
    {
        List<Role> _newRolesList = new List<Role>();

        for (int i = 0; i < _rolesArray.Length; i++)
        {
            _newRolesList.Add(new Role(_rolesArray[i].nameRole, _rolesArray[i].hold, _rolesArray[i].improve,
                _rolesArray[i].ressourceSocial, _rolesArray[i].ressourcePolitical, _rolesArray[i].ressourceEconomical));
        }

        return _newRolesList;
    }


    /// <summary>
    /// Create a default roles list
    /// </summary>
    public void FillRoles()
    {
        DefaultRoles.Clear();
        //DefaultRoles.Add(new Role("SERVEUR", "Environment", "Environment", 0, 1, 1));
        //DefaultRoles.Add(new Role("PLATEAU", "Environment", "Environment", 0, 1, 1));
        DefaultRoles.Add(new Role("Transporteur", "Attractiveness", "Fluidity", 0, 3, 7));
        DefaultRoles.Add(new Role("Habitant", "Fluidity", "Environment", 7, 3, 0));
        DefaultRoles.Add(new Role("Collectivité Locale", "Environment", "Attractiveness", 0, 4, 6));
        DefaultRoles.Add(new Role("Commerçant", "Fluidity", "Attractiveness", 6, 0, 4));
        DefaultRoles.Add(new Role("Opérateur de transport public", "Environment", "Fluidity", 0, 6, 4));
    }


    /// <summary>
    /// Create a default roles list in English
    /// </summary>
    public void FillRolesEN()
    {
        DefaultRolesEN.Clear();
        //DefaultRoles.Add(new Role("SERVEUR", "Environment", "Environment", 0, 1, 1));
        //DefaultRoles.Add(new Role("PLATEAU", "Environment", "Environment", 0, 1, 1));
        DefaultRolesEN.Add(new Role("Freight operator", "Attractiveness", "Fluidity", 0, 3, 7));
        DefaultRolesEN.Add(new Role("Citizen", "Fluidity", "Environment", 7, 3, 0));
        DefaultRolesEN.Add(new Role("Metropolitan authority", "Environment", "Attractiveness", 0, 4, 6));
        DefaultRolesEN.Add(new Role("Shop owner", "Fluidity", "Attractiveness", 6, 0, 4));
        DefaultRolesEN.Add(new Role("Public transport operator", "Environment", "Fluidity", 0, 6, 4));
    }

    /// <summary>
    /// Takes a roles list and transforms it into a string so we can Log it for example
    /// </summary>
    /// <param name="_roles"></param>
    /// <returns></returns>
    public static string RoleListToString(List<Role> _roles)
    {
        string _result = "";

        for (int i = 0; i < _roles.Count; i++)
        {
            _result += _roles[i].nameRole + "\n";
        }

        return _result + "\n";
    }

    /// <summary>
    /// Returns a filename for the role json depending on the Language chosen
    /// </summary>
    /// <returns></returns>
    public static string RoleFileNameDependingOnLanguage()
    {
        if (GameSettings.Language == "Fr")
        {
            return "/roles.json";
        }
        else //GameSettings.Language == "En"
        {
            return "/rolesEN.json";
        }
    }

}
