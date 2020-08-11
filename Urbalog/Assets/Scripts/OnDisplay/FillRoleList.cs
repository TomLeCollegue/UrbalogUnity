using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillRoleList : MonoBehaviour
{

    public GameObject RoleItem;
    public Transform listHolder;
    public List<GameObject> RoleItemInList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        SpawnAllRoles();
    }

    /// <summary>
    /// Spawn a role in the list and gives it its role
    /// </summary>
    /// <param name="_role"></param>
    public void SpawnRoleItem(Role _role)
    {
        GameObject Item = Instantiate(RoleItem, listHolder);
        Item.GetComponent<NameRoleInList>().getCurrentRole(_role);
        Item.GetComponent<NameRoleInList>().FillDisplay(_role);

        RoleItemInList.Add(Item);
    }

//    public static Role[] loadRoleFromJson(string _filename)
//public static void putRolesArrayInRolesList(Role[] _rolesArray, List<Role> _Roles)


    /// <summary>
    /// Spawn all the items
    /// </summary>
    public void SpawnAllRoles()
    {
        string _fileName = JSONRoles.RoleFileNameDependingOnLanguage();

        Role[] _roles = JSONRoles.loadRoleFromJson(_fileName);
        //JSONRoles.putRolesArrayInRolesList(_roles, JSONRoles.CurrentRoles);
        JSONRoles.CurrentRoles = JSONRoles.returnRolesArrayInRolesList(_roles);
        for (int i = 0; i < JSONRoles.CurrentRoles.Count; i++)
        {
            SpawnRoleItem(JSONRoles.CurrentRoles[i]);
        }
    }

    /// <summary>
    /// Destroy the list so we can update it later
    /// </summary>
    public void DestroyList()
    {
        for (int i = 0; i < RoleItemInList.Count; i++)
        {
            Destroy(RoleItemInList[i]);
        }
        RoleItemInList.Clear();
    }

    /// <summary>
    /// Update the role settings list
    /// </summary>
    public void UpdateList()
    {

        Debug.Log("not updated");
        DestroyList();
        SpawnAllRoles();
        Debug.Log("updated");
    }

    /// <summary>
    /// Reset the List to the default value --> Icebreaker Rules
    /// </summary>
    public void ResetListToDefault()
    {
        //Gets the default values of a building in a List
        string _fileName = JSONRoles.RoleFileNameDependingOnLanguage();

        if (GameSettings.Language == "Fr")
        {
            //Create a new JSON with this List
            JSONRoles.CreateRoleJSONWithRolesList(JSONRoles.DefaultRoles, _fileName);
        }
        else //GameSettings.Language == "En"
        {
            JSONRoles.CreateRoleJSONWithRolesList(JSONRoles.DefaultRolesEN, _fileName);
        }

        UpdateList();
    }



}
