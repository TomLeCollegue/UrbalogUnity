using System;
using System.Collections;
using System.Collections.Generic;
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

    public Building currentBuilding;


    #region buildingSettingsPanel
    public GameObject panel;

    public TextMeshProUGUI buildingName; //public TextMeshProUGUI buildingInput;
    //public TextMeshProUGUI descriptionPlaceholder; public TextMeshProUGUI descriptionInput;

    //public TextMeshProUGUI ecoPlaceholder; public TextMeshProUGUI ecoInput;
    //public TextMeshProUGUI socPlaceholder; public TextMeshProUGUI socInput;
    //public TextMeshProUGUI poliPlaceholder; public TextMeshProUGUI poliInput;

    //public TextMeshProUGUI enviPlaceholder; public TextMeshProUGUI enviInput;
    //public TextMeshProUGUI fluidPlaceholder; public TextMeshProUGUI fluidInput;
    //public TextMeshProUGUI attractPlaceholder; public TextMeshProUGUI attractInput;
    //public TextMeshProUGUI logisticPlaceholder; public TextMeshProUGUI logiInput;

    //public TextMeshProUGUI logisticDescriptionPlaceholder; public TextMeshProUGUI logiDescriptionInput;

    //testing with input field attributes instead of textMeshPro

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
    }
    public void DisplaySettingsMenu()
    {
        BuildingsListPanel.SetActive(false);
        TimeLimitPanel.SetActive(false);
        MainSettingsMenu.SetActive(true);
        BuildingsSettingsMenu.SetActive(false);
        //nbBuildingsMaxPerTurnPlaceholder.text = GameSettings.nbBuildingsPerTurn.ToString();
    }

    public void DisplayBuildingsList()
    {
        TimeLimitPanel.SetActive(false);
        BuildingsListPanel.SetActive(true);
        MainSettingsMenu.SetActive(false);
        BuildingsSettingsMenu.SetActive(false);
    }

    public void DisplayTimeLimitPanel()
    {
        TimeLimitPanel.SetActive(true);
        BuildingsListPanel.SetActive(false);
        MainSettingsMenu.SetActive(false);
        BuildingsSettingsMenu.SetActive(false);
        timerPlaceholder.text = GameSettings.TurnTimeMax.ToString();
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
            buildingName.text = _building.name;

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
    /// When button validate is pressed, the building is saved and we return to buildingsList view
    /// </summary>
    public void ChangeBuildingSettings()
    {
        Building[] _buildings = JSONBuildings.loadBuildingsFromJSON("/buildings.json");

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

        displayList.destroyListe();
        displayList.Init();



        //NextTurnButton.NumberBuildingsToEnd = Convert.ToInt16(_NumBuilding);
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
        string _buildingName = buildingName.text;
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

}
