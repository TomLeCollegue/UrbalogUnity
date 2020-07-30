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

    /// <summary>
    /// Spawn all the items
    /// </summary>
    public void SpawnAllRoles()
    {
        for (int i = 0; i < JSONRoles.DefaultRoles.Count; i++)
        {
            SpawnRoleItem(JSONRoles.DefaultRoles[i]);
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

}
