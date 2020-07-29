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
        for (int i = 0; i < JSONRoles.DefaultRoles.Count; i++)
        {
            SpawnRoleItem(JSONRoles.DefaultRoles[i]);
        }
    }

    /// <summary>
    /// Spawn a role in the list
    /// </summary>
    /// <param name="_role"></param>
    public void SpawnRoleItem(Role _role)
    {
        GameObject Item = Instantiate(RoleItem, listHolder);
        Item.GetComponent<NameRoleInList>().FillDisplay(_role);

        RoleItemInList.Add(Item);
    }

/*    public void UpdateList()
    {
        DestroyList();

        for (int i = 0; i < GameManager.singleton.players.Count; i++)
        {
            if (i >= 0) // 2 if server and tablet non player
            {
                SpawnPlayerItem(GameManager.singleton.players[i]);
            }
        }
    }*/
}
