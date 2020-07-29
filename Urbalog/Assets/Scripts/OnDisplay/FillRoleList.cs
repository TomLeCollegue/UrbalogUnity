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
        
    }


    public void SpawnPlayerItem(Role _role)
    {
        GameObject Item = Instantiate(RoleItem, listHolder);
        Item.GetComponent<NameRoleInList>().Rename(_role);

        RoleItemInList.Add(Item);
    }
}
