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

    public Role currentRole;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Takes the role from the fill role list
    /// </summary>
    /// <param name="_role"></param>
    public void getCurrentRole(Role _role)
    {
        currentRole = _role;
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

    /// <summary>
    /// When clicked, the role panel is opened so you can modify the role
    /// </summary>
    public void OpenRoleSettingPanel()
    {
        GameObject.Find("RoleListManager").GetComponent<RoleSettingsPanel>().OpenRoleSettingsPanel(currentRole);
    }

    public void CloseRoleSettingsPanel()
    {
        GameObject.Find("RoleListManager").GetComponent<RoleSettingsPanel>().CloseRoleSettingsPanel();
    }

    /// <summary>
    /// On validate button on role settings panel
    /// </summary>
    public void SaveRoleModification()
    {
        //GameObject.Find("RoleListManager").GetComponent<RoleSettingsPanel>().ValidateRoleChanges();
    }

}
