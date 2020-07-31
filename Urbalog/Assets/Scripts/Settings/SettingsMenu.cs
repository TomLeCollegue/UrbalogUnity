using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public GameObject MainSettingsMenu;
    public GameObject BuildingsSettingsMenu;
    public GameObject BuildingsListPanel;
    public GameObject TimeLimitPanel;
    public GameObject RolePanel;

    public Building currentBuilding;


    #region buildingSettingsPanel
    public GameObject panel;

    public InputField NameInput;

    public InputField descriptionInput;
    public InputField ecoInput;
    public InputField socInput;
    public InputField poliInput;

    public InputField enviInput;
    public InputField fluidInput;
    public InputField attractInput;

    public InputField logiInput;

    public InputField LogisticDescriptionInput;
    #endregion

    #region addBuildingPanel
    public GameObject addPanel;

    public InputField addNameInput;

    public InputField AddDescriptionInput;
    public InputField AddEcoInput;
    public InputField AddSocInput;
    public InputField AddPoliInput;

    public InputField AddEnviInput;
    public InputField AddFluidInput;
    public InputField AddAttractInput;

    public InputField AddLogiInput;

    public InputField AddLogisticDescriptionInput;

    #endregion

    public TextMeshProUGUI timerPlaceholder;

    public TextMeshProUGUI nbBuildingsMaxPerTurnPlaceholder;

    public PopulateBuildingsSettingsList displayList;

    public void GoToSettingsScene()
    {
        SceneManager.LoadScene("SettingsScene");
    }

    public void GoBackToLobby()
    {
        SceneManager.LoadScene("LobbyRework");
    }

    private void Update()
    {
        nbBuildingsMaxPerTurnPlaceholder.text = GameSettings.nbBuildingsPerTurn.ToString();
    }

    public void DisplayBuildingsSettingsMenu()
    {
        MainSettingsMenu.SetActive(false);
        BuildingsListPanel.SetActive(false);
        TimeLimitPanel.SetActive(false);
        BuildingsSettingsMenu.SetActive(true);
        RolePanel.SetActive(false);
    }
    public void DisplaySettingsMenu()
    {
        BuildingsListPanel.SetActive(false);
        TimeLimitPanel.SetActive(false);
        MainSettingsMenu.SetActive(true);
        BuildingsSettingsMenu.SetActive(false);
        RolePanel.SetActive(false);
        //nbBuildingsMaxPerTurnPlaceholder.text = GameSettings.nbBuildingsPerTurn.ToString();
    }

    public void DisplayBuildingsList()
    {
        TimeLimitPanel.SetActive(false);
        BuildingsListPanel.SetActive(true);
        MainSettingsMenu.SetActive(false);
        BuildingsSettingsMenu.SetActive(false);
        RolePanel.SetActive(false);
    }

    public void DisplayTimeLimitPanel()
    {
        TimeLimitPanel.SetActive(true);
        BuildingsListPanel.SetActive(false);
        MainSettingsMenu.SetActive(false);
        BuildingsSettingsMenu.SetActive(false);
        RolePanel.SetActive(false);
        timerPlaceholder.text = GameSettings.TurnTimeMax.ToString();
    }

    public void DisplayRolePanel()
    {
        TimeLimitPanel.SetActive(false);
        BuildingsListPanel.SetActive(false);
        MainSettingsMenu.SetActive(false);
        BuildingsSettingsMenu.SetActive(false);
        RolePanel.SetActive(true);
    }

    /// <summary>
    /// When a building in the buildings list is clicked, a panel opens so we can change its infos
    /// It prints the current infos in the placeholder.
    /// The changed are made only when the validate button is clicked.
    /// </summary>
    public void OpenBuildingSettingsPanel(Building _building)
    {
        if (panel != null)
        {
            panel.SetActive(true);
            NameInput.text = _building.name;

            descriptionInput.text = _building.description ;
            ecoInput.text = _building.Economical.ToString();
            socInput.text = _building.Social.ToString();
            poliInput.text = _building.Political.ToString();

            enviInput.text = _building.enviScore.ToString();
            fluidInput.text = _building.fluidScore.ToString();
            attractInput.text = _building.attractScore.ToString();

            logiInput.text = _building.logisticScore.ToString();

            LogisticDescriptionInput.text = _building.logisticDescription;
            
        }
        currentBuilding = _building;
    }

    /// <summary>
    /// open the panel to add a building in json
    /// </summary>
    public void OpenAddBuildingPanel()
    {
        if (addPanel != null)
        {
            addPanel.SetActive(true);
        }
    }

    public void CloseAddBuildingPanel()
    {
        addPanel.SetActive(false);
    }


    /// <summary>
    /// When button validate is pressed, the building is saved and we return to buildingsList view
    /// </summary>
    public void ChangeBuildingSettings()
    {
        Building[] _buildings = JSONBuildings.loadBuildingsFromJSON("/buildings.json");
        //Building[] _buildings = JSONBuildings.loadBuildingsFromJSON(Directory.GetCurrentDirectory() + "\\Assets\\buildings.json");

        Building _newBuilding = CreateNewBuildingWithInputFields();

        for (int i = 0; i < _buildings.Length; i++)
        {
            if (_buildings[i].name.Equals(currentBuilding.name))
            {
                _buildings[i] = _newBuilding;
                //savedansJSON (_buildings)
                JSONBuildings.CreateBuildingJSONWithBuildings(_buildings);
            }
        }
        CloseBuildingSettingsPanel();

        RefreshBuildingsList();

        //NextTurnButton.NumberBuildingsToEnd = Convert.ToInt16(_NumBuilding);
    }

    /// <summary>
    /// When called, refreshes the buildings list with values up to date with buildings.json
    /// </summary>
    public void RefreshBuildingsList()
    {
        displayList.destroyListe();
        displayList.Init();
    }

    public void CloseBuildingSettingsPanel()
    {
        panel.SetActive(false);
    }

    /// <summary>
    /// Create new Building that we will save in our JSON
    /// </summary>
    /// <returns></returns>
    private Building CreateNewBuildingWithInputFields()
    {
        string _buildingName = NameInput.text;
        string _buildingDescription = "";

        int _buildingEco = 98;
        int _buildingSoc = 98;
        int _buildingPoli = 98;

        int _buildingEnvi = 98;
        int _buildingFluid = 98;
        int _buildingAttract = 98;
        int _buildingLogi = 98;

        string _buildingLogiDescription = "";

        _buildingDescription = descriptionInput.text;

        _buildingEco = Convert.ToInt16(ecoInput.text);
        _buildingSoc = Convert.ToInt16(socInput.text);
        _buildingPoli = Convert.ToInt16(poliInput.text);
        
        _buildingEnvi = Convert.ToInt16(enviInput.text);
        _buildingFluid = Convert.ToInt16(fluidInput.text);
        _buildingAttract = Convert.ToInt16(attractInput.text);
        
        _buildingLogi = Convert.ToInt16(logiInput.text);

        _buildingLogiDescription = LogisticDescriptionInput.text;

        Building _res = new Building(_buildingName,_buildingDescription,_buildingEco,_buildingSoc,_buildingPoli,_buildingEnvi
            ,_buildingFluid, _buildingAttract, _buildingLogi, _buildingLogiDescription);

        return _res;
    }

    /// <summary>
    /// Very similar to CreateNewBuildingWithInputFields() but does it in the add panel
    /// Return a building with all the informations on AddPanel Input Fields
    /// </summary>
    /// <returns></returns>
    private Building CreateNewBuildingWithInputFieldsInAddPanel()
    {
        string _buildingName = "";
        string _buildingDescription = "";

        int _buildingEco = 0;
        int _buildingSoc = 0;
        int _buildingPoli = 0;

        int _buildingEnvi = 0;
        int _buildingFluid = 0;
        int _buildingAttract = 0;
        int _buildingLogi = 0;

        string _buildingLogiDescription = "";

        _buildingName = addNameInput.text;
        _buildingDescription = AddDescriptionInput.text;

        _buildingEco = Convert.ToInt16(AddEcoInput.text);
        _buildingSoc = Convert.ToInt16(AddSocInput.text);
        _buildingPoli = Convert.ToInt16(AddPoliInput.text);

        _buildingEnvi = Convert.ToInt16(AddEnviInput.text);
        _buildingFluid = Convert.ToInt16(AddFluidInput.text);
        _buildingAttract = Convert.ToInt16(AddAttractInput.text);

        _buildingLogi = Convert.ToInt16(AddLogiInput.text);

        _buildingLogiDescription = AddLogisticDescriptionInput.text;

        Building _res = new Building(_buildingName, _buildingDescription, _buildingEco, _buildingSoc, _buildingPoli, _buildingEnvi
    , _buildingFluid, _buildingAttract, _buildingLogi, _buildingLogiDescription);

        return _res;
    }

    /// <summary>
    /// Resets all the buildings info to the IceBreaker rules in buildings.json and
    /// refreshes the building settings list.
    /// </summary>
    public void ResetBuildingsToDefault()
    {
        JSONBuildings.CreateBuildingsJSONWithDeck(JSONBuildings.DefaultDeck);
        RefreshBuildingsList();
    }

    /// <summary>
    /// Delete the current building when called from json and refreshes the list
    /// </summary>
    public void DeleteBuilding()
    {
        Debug.Log("delete settings menu building " + currentBuilding.name);
        JSONBuildings.DeleteBuildingFromJSON(currentBuilding);
        RefreshBuildingsList();
        CloseBuildingSettingsPanel();
    }

    /// <summary>
    /// takes the information in all "add building panel" inputs and adds the building created in the json file
    /// </summary>
    public void AddBuilding()
    {
        Building _buildingToAdd = CreateNewBuildingWithInputFieldsInAddPanel();
        JSONBuildings.AddInJson(_buildingToAdd);
        RefreshBuildingsList();
        CloseAddBuildingPanel();
    }


}
