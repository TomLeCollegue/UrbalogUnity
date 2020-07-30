﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JSONRoles : MonoBehaviour
{
    public static List<Role> DefaultRoles = new List<Role>();

    public static List<Role> CurrentRoles = new List<Role>();

    // Start is called before the first frame update
    void Start()
    {
        FillRoles();
        if (/*!File.Exists(Directory.GetCurrentDirectory() + "\\Assets\\buildings.json")*/
            !File.Exists(Application.dataPath + "\\roles.json")) //On vérifie si le buildings.json existe
        {
            CreateRoleJSONWithRolesList(CurrentRoles);
            Debug.Log("fichier role Créé");
        }
        else
        {
            Debug.Log("On ne crée pas le fichier role");
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
    public static void CreateRoleJSONWithRolesList(List<Role> _roles)
    {
        string _jsonRoles = "";

        Role[] _RolesArray = _roles.ToArray();
        _jsonRoles = JsonHelper.ToJson(_RolesArray, true);
        File.WriteAllText(Application.dataPath + "/roles.json", _jsonRoles);

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
        for (int i = 0; i < _rolesArray.Length; i++)
        {
            _Roles.Add(new Role(_rolesArray[i].nameRole, _rolesArray[i].hold, _rolesArray[i].improve, 
                _rolesArray[i].ressourceSocial, _rolesArray[i].ressourcePolitical, _rolesArray[i].ressourceEconomical));
        }
    }


    /// <summary>
    /// Create a default roles list
    /// </summary>
    public void FillRoles()
    {
        //CurrentRoles.Add(new Role("SERVEUR", "Environment", "Environment", 0, 1, 1));
        //CurrentRoles.Add(new Role("PLATEAU", "Environment", "Environment", 0, 1, 1));
        CurrentRoles.Add(new Role("Transporteur", "Attractiveness", "Fluidity", 0, 3, 7));
        CurrentRoles.Add(new Role("Habitant", "Fluidity", "Environment", 7, 3, 0));
        CurrentRoles.Add(new Role("Collectivité Locale", "Environment", "Attractiveness", 0, 4, 6));
        CurrentRoles.Add(new Role("Commerçant", "Fluidity", "Attractiveness", 6, 0, 4));
        CurrentRoles.Add(new Role("Opérateur de transport public", "Environment", "Fluidity", 0, 6, 4));
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

}
