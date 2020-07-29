using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameRoleInList : MonoBehaviour
{
    public TextMeshProUGUI roleName;

    public TextMeshProUGUI holdObjective;
    public TextMeshProUGUI improveObjective;

    public TextMeshProUGUI poliResources;
    public TextMeshProUGUI ecoResources;
    public TextMeshProUGUI socialResources;

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
    public void FillDisplay(Role _role)
    {
        roleName.text = _role.nameRole;

        holdObjective.text = _role.hold;
        improveObjective.text = _role.improve;

        poliResources.text = _role.ressourcePolitical.ToString();
        ecoResources.text = _role.ressourceEconomical.ToString();
        socialResources.text = _role.ressourceSocial.ToString();
    }
}
