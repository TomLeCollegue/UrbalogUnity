using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameRoleInList : MonoBehaviour
{
    public TextMeshProUGUI roleName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Take all the informations of _role and print them in the prefab
    /// </summary>
    /// <param name="_role"></param>
    public void Rename(Role _role)
    {
        roleName.text = _role.nameRole;
    }
}
