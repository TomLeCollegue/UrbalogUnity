using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoleSettingsPanel : MonoBehaviour
{
    #region RoleSettingsPanel
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
    #endregion

    public Role currentRole;

    #region addRolePanel
    public GameObject addRolePanel;

    public InputField addRoleName;

    public InputField addRoleNameInput;

    public Button addHoldAttractButton;
    public Button addHoldEnviButton;
    public Button addHoldFluidButton;
    public bool addHoldAttractIsPressed;
    public bool addHoldEnviIsPressed;
    public bool addHoldFluidIsPressed;

    public Button addImproveAttractButton;
    public Button addImproveEnviButton;
    public Button addImproveFluidButton;
    public bool addImproveAttractIsPressed;
    public bool addImproveEnviIsPressed;
    public bool addImproveFluidIsPressed;

    public TextMeshProUGUI addHoldAttractButtonText;
    public TextMeshProUGUI addHoldEnviButtonText;
    public TextMeshProUGUI addHoldFluidButtonText;

    public TextMeshProUGUI addImproveAttractButtonText;
    public TextMeshProUGUI addImproveEnviButtonText;
    public TextMeshProUGUI addImproveFluidButtonText;

    public InputField addPoliNumberInput;
    public InputField addEcoNumberInput;
    public InputField addSocialNumberInput;


    #endregion


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
    /// Opens the panels which allow us to create a role
    /// </summary>
    public void OpenAddRolePanel()
    {
        if (addRolePanel != null)
        {
            addRolePanel.SetActive(true);
        }
    }

    public void CloseAddRolePanel()
    {
        if (addRolePanel != null)
        {
            addRolePanel.SetActive(false);
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
        string _fileName = JSONRoles.RoleFileNameDependingOnLanguage();
        int _index;

        //Create a new role with inputField and button values
        Role _newRole = CreateNewRoleWithInputValues();

        if (GameSettings.Language == "Fr")
        {
            _index = JSONRoles.CurrentRoles.IndexOf(currentRole);
            //Debug.Log("index :" + _index);
            //Debug.Log("avant nouveau rôle : "+JSONRoles.RoleListToString(JSONRoles.CurrentRoles));

            JSONRoles.CurrentRoles[_index] = _newRole;
            //Debug.Log("après nouveau rôle : "+JSONRoles.RoleListToString(JSONRoles.CurrentRoles));

            //Create a new JSON with this List
            JSONRoles.CreateRoleJSONWithRolesList(JSONRoles.CurrentRoles, _fileName);
        }
        else //GameSettings.Language == "En"
        {
            _index = GetIndexFromRoleInRoleList(JSONRoles.CurrentRolesEN, currentRole);

            JSONRoles.CurrentRolesEN[_index] = _newRole;

            JSONRoles.CreateRoleJSONWithRolesList(JSONRoles.CurrentRolesEN, _fileName);
        }

        ////Take this new role and put it the role list in place of the role.
        //int _index = JSONRoles.CurrentRoles.IndexOf(currentRole);
        ////Debug.Log("index :" + _index);
        ////Debug.Log("avant nouveau rôle : "+JSONRoles.RoleListToString(JSONRoles.CurrentRoles));

        //JSONRoles.CurrentRoles[_index] = _newRole;
        ////Debug.Log("après nouveau rôle : "+JSONRoles.RoleListToString(JSONRoles.CurrentRoles));

        ////Create a new JSON with this List
        //JSONRoles.CreateRoleJSONWithRolesList(JSONRoles.CurrentRoles, "/roles.json");
        

        //refresh the list
        GameObject.Find("RoleListManager").GetComponent<FillRoleList>().UpdateList();

        //Close Panel
        CloseRoleSettingsPanel();
    }

    /// <summary>
    /// Takes the input of the admin from the input field, creates a Role with that, and then adds it in the json file.
    /// </summary>
    public void AddRole()
    {
        string _fileName = JSONRoles.RoleFileNameDependingOnLanguage();

        //Create Role with Input Values
        Role _newRole = CreateNewRoleWithInputValuesInAddPanel();
        Debug.Log("add role 1");

        if (GameSettings.Language == "Fr")
        {
            //Adds into JSON.CurrentRoles
            JSONRoles.CurrentRoles.Add(_newRole);
            Debug.Log("add role 2");

            //CreateNewJsonRole with JSON.CurrentRoles
            JSONRoles.CreateRoleJSONWithRolesList(JSONRoles.CurrentRoles, _fileName);
            Debug.Log("add role 3");
        }
        else //GameSettings.Language == "En"
        {
            //Adds into JSON.CurrentRoles
            JSONRoles.CurrentRolesEN.Add(_newRole);
            Debug.Log("add role 2");

            //CreateNewJsonRole with JSON.CurrentRoles
            JSONRoles.CreateRoleJSONWithRolesList(JSONRoles.CurrentRolesEN, _fileName);
            Debug.Log("add role 3");
        }

        //Close add role panel
        CloseAddRolePanel();
        Debug.Log("add role 4");

        //Refresh the list
        GameObject.Find("RoleListManager").GetComponent<FillRoleList>().UpdateList();
        Debug.Log("add role 5");


    }

    /// <summary>
    /// Takes the values of the inputs in the addRolePanel and creates a role.
    /// </summary>
    /// <returns></returns>
    private Role CreateNewRoleWithInputValuesInAddPanel()
    {
        string _name = addRoleName.text;
        string _hold = "";
        string _improve = "";
        int _resSocial = 0;
        int _resPoli = 0;
        int _resEco = 0;

        if (addHoldAttractIsPressed)
        {
            _hold = "Attractiveness";
        }
        else if (addHoldEnviIsPressed)
        {
            _hold = "Environment";
        }
        else if (addHoldFluidIsPressed)
        {
            _hold = "Fluidity";
        }
        else
        {
            Debug.Log("error in RoleSettingsPanel : CreateNewRoleWithInputValuesInAddPanel");
        }

        if (addImproveAttractIsPressed)
        {
            _improve = "Attractiveness";
        }
        else if (addImproveEnviIsPressed)
        {
            _improve = "Environment";
        }
        else if (addImproveFluidIsPressed)
        {
            _improve = "Fluidity";
        }
        else
        {
            Debug.Log("error in RoleSettingsPanel : CreateNewRoleWithInputValuesInAddPanel");
        }


        if (addSocialNumberInput.text == "" || !(addSocialNumberInput.text.All(char.IsDigit)))
        {
            _resSocial = 0;
        }
        else
        {
            _resSocial = Convert.ToInt16(addSocialNumberInput.text);
        }
        if (addPoliNumberInput.text == "" || !(addPoliNumberInput.text.All(char.IsDigit)))
        {
            _resPoli = 0;
        }
        else
        {
            _resPoli = Convert.ToInt16(addPoliNumberInput.text);
        }
        if (addEcoNumberInput.text == "" || !(addEcoNumberInput.text.All(char.IsDigit)))
        {
            _resEco = 0;
        }
        else
        {
            _resEco = Convert.ToInt16(addEcoNumberInput.text);
        }

        

        Role _result = new Role(_name, _hold, _improve, _resSocial, _resPoli, _resEco);

        return _result;
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

        if (SocialNumberInput.text == "" || !(SocialNumberInput.text.All(char.IsDigit)))
        {
            _resSocial = 0;
        }
        else
        {
            _resSocial = Convert.ToInt16(SocialNumberInput.text);
        }
        if (PoliNumberInput.text == "" || !(PoliNumberInput.text.All(char.IsDigit)))
        {
            _resPoli = 0;
        }
        else
        {
            _resPoli = Convert.ToInt16(PoliNumberInput.text);
        }
        if (EcoNumberInput.text == "" || !(EcoNumberInput.text.All(char.IsDigit)))
        {
            _resEco = 0;
        }
        else
        {
            _resEco = Convert.ToInt16(EcoNumberInput.text);
        }

        Role _result = new Role(_name, _hold, _improve,_resSocial, _resPoli, _resEco );

        return _result;
    }

    /// <summary>
    /// Delete Role from JSON and then refresh display list
    /// </summary>
    public void DeleteRole()
    {
        string _fileName = JSONRoles.RoleFileNameDependingOnLanguage();
        int _indexCurRole;

        if (GameSettings.Language == "Fr")
        {
            //Delete currentRole from JSONRoles.CurrentRoles
            _indexCurRole = JSONRoles.CurrentRoles.IndexOf(currentRole);
            JSONRoles.CurrentRoles.RemoveAt(_indexCurRole);

            //Create the new JSON file with CurrentRoles
            JSONRoles.CreateRoleJSONWithRolesList(JSONRoles.CurrentRoles, _fileName);
        }
        else //GameSettings.Language == "En"
        {
            //Delete currentRole from JSONRoles.CurrentRoles
            _indexCurRole = GetIndexFromRoleInRoleList(JSONRoles.CurrentRolesEN, currentRole);

            JSONRoles.CurrentRolesEN.RemoveAt(_indexCurRole);

            //Create the new JSON file with CurrentRoles
            JSONRoles.CreateRoleJSONWithRolesList(JSONRoles.CurrentRolesEN, _fileName);
        }
        //close settings panel
        CloseRoleSettingsPanel();

        //refresh display list
        GameObject.Find("RoleListManager").GetComponent<FillRoleList>().UpdateList();
    }

    /// <summary>
    /// Give the index of a role in a list, returns -1 if it's not in the List
    /// </summary>
    /// <param name="_roleList"></param>
    /// <param name="_role"></param>
    /// <returns></returns>
    public int GetIndexFromRoleInRoleList(List<Role> _roleList, Role _role)
    {
        for (int i = 0; i < _roleList.Count; i++)
        {
            if (Role.RoleEquals(_role,_roleList[i]))
            {
                return i;
            }
        }
        return -1;
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

    public void addSelectHoldAttract()
    {
        addHoldAttractButtonText.color = Color.green;
        addHoldEnviButtonText.color = Color.black;
        addHoldFluidButtonText.color = Color.black;

        addHoldAttractIsPressed = true;
        addHoldEnviIsPressed = false;
        addHoldFluidIsPressed = false;
    }

    public void addSelectHoldEnvi()
    {
        addHoldAttractButtonText.color = Color.black;
        addHoldEnviButtonText.color = Color.green;
        addHoldFluidButtonText.color = Color.black;

        addHoldAttractIsPressed = false;
        addHoldEnviIsPressed = true;
        addHoldFluidIsPressed = false;
    }

    public void addSelectHoldFluid()
    {
        addHoldAttractButtonText.color = Color.black;
        addHoldEnviButtonText.color = Color.black;
        addHoldFluidButtonText.color = Color.green;

        addHoldAttractIsPressed = false;
        addHoldEnviIsPressed = false;
        addHoldFluidIsPressed = true;
    }

    public void addSelectImproveAttract()
    {
        addImproveAttractButtonText.color = Color.green;
        addImproveEnviButtonText.color = Color.black;
        addImproveFluidButtonText.color = Color.black;

        addImproveAttractIsPressed = true;
        addImproveEnviIsPressed = false;
        addImproveFluidIsPressed = false;
    }

    public void addSelectImproveEnvi()
    {
        addImproveAttractButtonText.color = Color.black;
        addImproveEnviButtonText.color = Color.green;
        addImproveFluidButtonText.color = Color.black;

        addImproveAttractIsPressed = false;
        addImproveEnviIsPressed = true;
        addImproveFluidIsPressed = false;
    }

    public void addSelectImproveFluid()
    {
        addImproveAttractButtonText.color = Color.black;
        addImproveEnviButtonText.color = Color.black;
        addImproveFluidButtonText.color = Color.green;

        addImproveAttractIsPressed = false;
        addImproveEnviIsPressed = false;
        addImproveFluidIsPressed = true;
    }
}
