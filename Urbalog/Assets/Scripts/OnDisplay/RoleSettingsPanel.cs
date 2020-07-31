using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoleSettingsPanel : MonoBehaviour
{
    public GameObject panel;

    public InputField RoleName;

    public Button HoldAttractButton;
    public Button HoldEnviButton;
    public Button HoldFluidButton;
    public bool HoldAttractIsPressed;
    public bool HoldEnviIsPressed;
    public bool HoldFluidIsPressed;

    public Button ImproveAttractButton;
    public Button ImproveEnviButton;
    public Button ImproveFluidButton;
    public bool ImproveAttractIsPressed;
    public bool ImproveEnviIsPressed;
    public bool ImproveFluidIsPressed;

    public TextMeshProUGUI HoldAttractButtonText;
    public TextMeshProUGUI HoldEnviButtonText;
    public TextMeshProUGUI HoldFluidButtonText;

    public TextMeshProUGUI ImproveAttractButtonText;
    public TextMeshProUGUI ImproveEnviButtonText;
    public TextMeshProUGUI ImproveFluidButtonText;

    public InputField PoliNumberInput;
    public InputField EcoNumberInput;
    public InputField SocialNumberInput;

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
    /// opens the panel which allows us to modify the role
    /// </summary>
    public void OpenRoleSettingsPanel(Role _role)
    {
        if (panel != null)
        {
            panel.SetActive(true);
            RoleName.text = _role.nameRole;

            ColorObjectivesButtons(_role);

            PoliNumberInput.text = _role.ressourcePolitical.ToString();
            EcoNumberInput.text = _role.ressourceEconomical.ToString();
            SocialNumberInput.text = _role.ressourceSocial.ToString();

            currentRole = _role;

        }
    }

    /// <summary>
    /// This method changes the color of the objectives button on a role so we undestand which role is already chosen.
    /// </summary>
    /// <param name="_role"></param>
    private void ColorObjectivesButtons(Role _role)
    {
        if (_role.hold == "Attractiveness")
        {
            SelectHoldAttract();
        }
        else if (_role.hold == "Environment")
        {
            SelectHoldEnvi();
        }
        else if (_role.hold == "Fluidity")
        {
            SelectHoldFluid();
        }
        else
        {
            Debug.Log("error in RoleSettingsPanel");
        }

        if (_role.improve == "Attractiveness")
        {
            SelectImproveAttract();
        }
        else if (_role.improve == "Environment")
        {
            SelectImproveEnvi();
        }
        else if (_role.improve == "Fluidity")
        {
            SelectImproveFluid();
        }
        else
        {
            Debug.Log("error in RoleSettingsPanel");
        }
    }



    /// <summary>
    /// Changes the role when the admin clicks on "validate changes"
    /// </summary>
    public void ValidateRoleChanges()
    {
        //import role List from Json
        //List<Role> _newList = JSONRoles.CurrentRoles;

        //Create a new role with inputField and button values
        Role _newRole = CreateNewRoleWithInputValues();
        Debug.Log("rôle courant :"+currentRole.nameRole);
        Debug.Log("rôle nouveau :"+_newRole.nameRole);
        
        //Take this new role and put it the role list in place of the role.
        int _index = JSONRoles.CurrentRoles.IndexOf(currentRole);
        Debug.Log("index :" + _index);
        Debug.Log("avant nouveau rôle : "+JSONRoles.RoleListToString(JSONRoles.CurrentRoles));

        JSONRoles.CurrentRoles[_index] = _newRole;
        Debug.Log("après nouveau rôle : "+JSONRoles.RoleListToString(JSONRoles.CurrentRoles));

        //Create a new JSON with this List
        JSONRoles.CreateRoleJSONWithRolesList(JSONRoles.CurrentRoles);
        

        //refresh the list
        GameObject.Find("RoleListManager").GetComponent<FillRoleList>().UpdateList();

        //Close Panel
        CloseRoleSettingsPanel();


    }

    private Role CreateNewRoleWithInputValues()
    {
        string _name = RoleName.text;
        string _hold = "";
        string _improve = "";
        int _resSocial = 0;
        int _resPoli = 0;
        int _resEco = 0;
        

        if (HoldAttractIsPressed)
        {
            _hold = "Attractiveness";
        }
        else if (HoldEnviIsPressed)
        {
            _hold = "Environment";
        }
        else if (HoldFluidIsPressed)
        {
            _hold = "Fluidity";
        }
        else
        {
            Debug.Log("error in RoleSettingsPanel : CreateNewRoleWithInputValues");
        }

        if (ImproveAttractIsPressed)
        {
            _improve = "Attractiveness";
        }
        else if (ImproveEnviIsPressed)
        {
            _improve = "Environment";
        }
        else if (ImproveFluidIsPressed)
        {
            _improve = "Fluidity";
        }
        else
        {
            Debug.Log("error in RoleSettingsPanel : CreateNewRoleWithInputValues");
        }

        _resSocial = Convert.ToInt16(SocialNumberInput.text);
        _resPoli = Convert.ToInt16(PoliNumberInput.text);
        _resEco = Convert.ToInt16(EcoNumberInput.text);

        Role _result = new Role(_name, _hold, _improve,_resSocial, _resPoli, _resEco );

        return _result;
    }
    /// <summary>
    /// Delete Role from JSON and then refresh display list
    /// </summary>
    public void DeleteRole()
    {
        //Delete currentRole from JSONRoles.CurrentRoles
        int _indexCurRole = JSONRoles.CurrentRoles.IndexOf(currentRole);
        JSONRoles.CurrentRoles.RemoveAt(_indexCurRole);

        //Create the new JSON file with CurrentRoles
        JSONRoles.CreateRoleJSONWithRolesList(JSONRoles.CurrentRoles);

        //close settings panel
        CloseRoleSettingsPanel();

        //refresh display list
        GameObject.Find("RoleListManager").GetComponent<FillRoleList>().UpdateList();
    }

    internal void CloseRoleSettingsPanel()
    {
        panel.SetActive(false);
    }

    public void SelectHoldAttract()
    {
        HoldAttractButtonText.color = Color.green;
        HoldEnviButtonText.color = Color.black;
        HoldFluidButtonText.color = Color.black;

        HoldAttractIsPressed = true;
        HoldEnviIsPressed = false;
        HoldFluidIsPressed = false;
    }

    public void SelectHoldEnvi()
    {
        HoldAttractButtonText.color = Color.black;
        HoldEnviButtonText.color = Color.green;
        HoldFluidButtonText.color = Color.black;

        HoldAttractIsPressed = false;
        HoldEnviIsPressed = true;
        HoldFluidIsPressed = false;
    }

    public void SelectHoldFluid()
    {
        HoldAttractButtonText.color = Color.black;
        HoldEnviButtonText.color = Color.black;
        HoldFluidButtonText.color = Color.green;

        HoldAttractIsPressed = false;
        HoldEnviIsPressed = false;
        HoldFluidIsPressed = true;
    }

    public void SelectImproveAttract()
    {
        ImproveAttractButtonText.color = Color.green;
        ImproveEnviButtonText.color = Color.black;
        ImproveFluidButtonText.color = Color.black;

        ImproveAttractIsPressed = true;
        ImproveEnviIsPressed = false;
        ImproveFluidIsPressed = false;
    }

    public void SelectImproveEnvi()
    {
        ImproveAttractButtonText.color = Color.black;
        ImproveEnviButtonText.color = Color.green;
        ImproveFluidButtonText.color = Color.black;

        ImproveAttractIsPressed = false;
        ImproveEnviIsPressed = true;
        ImproveFluidIsPressed = false;
    }

    public void SelectImproveFluid()
    {
        ImproveAttractButtonText.color = Color.black;
        ImproveEnviButtonText.color = Color.black;
        ImproveFluidButtonText.color = Color.green;

        ImproveAttractIsPressed = false;
        ImproveEnviIsPressed = false;
        ImproveFluidIsPressed = true;
    }
}
