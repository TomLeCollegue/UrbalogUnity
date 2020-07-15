using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public TextMeshProUGUI descriptionPlaceholder; public TextMeshProUGUI descriptionInput;

    public TextMeshProUGUI ecoPlaceholder; public TextMeshProUGUI ecoInput;
    public TextMeshProUGUI socPlaceholder; public TextMeshProUGUI socInput;
    public TextMeshProUGUI poliPlaceholder; public TextMeshProUGUI poliInput;

    public TextMeshProUGUI enviPlaceholder; public TextMeshProUGUI enviInput;
    public TextMeshProUGUI fluidPlaceholder; public TextMeshProUGUI fluidInput;
    public TextMeshProUGUI attractPlaceholder; public TextMeshProUGUI attractInput;
    public TextMeshProUGUI logisticPlaceholder; public TextMeshProUGUI logiInput;

    public TextMeshProUGUI logisticDescriptionPlaceholder; public TextMeshProUGUI logiDescriptionInput;

    #endregion

    public TextMeshProUGUI timerPlaceholder;



    public void GoToSettingsScene()
    {
        SceneManager.LoadScene("SettingsScene");
    }

    public void GoBackToLobby()
    {
        SceneManager.LoadScene("LobbyRework");
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
            descriptionPlaceholder.text = _building.description;
            
            ecoPlaceholder.text = _building.Economical.ToString();
            socPlaceholder.text = _building.Social.ToString();
            poliPlaceholder.text = _building.Political.ToString();

            enviPlaceholder.text = _building.enviScore.ToString();
            fluidPlaceholder.text = _building.fluidScore.ToString();
            attractPlaceholder.text = _building.attractScore.ToString();
            logisticPlaceholder.text = _building.logisticScore.ToString();
            
            logisticDescriptionPlaceholder.text = _building.logisticDescription;
        }
        currentBuilding = _building;
    }


    /// <summary>
    /// When button validate is pressed, the building is saved and we return to buildingsList view
    /// </summary>
    /// <param name="_descBuilding"></param>
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
        string _buildingDescription;

        int _buildingEco;
        int _buildingSoc;
        int _buildingPoli;

        int _buildingEnvi;
        int _buildingFluid;
        int _buildingAttract;
        int _buildingLogi;

        string _buildingLogiDescription;

        //Description
        if (descriptionPlaceholder.text != descriptionInput.text && descriptionInput.text != "")
        {
            _buildingDescription = descriptionInput.text;
        }
        else
        {
            _buildingDescription = descriptionPlaceholder.text;
        }

        //eco
        if (ecoPlaceholder.text != ecoInput.text && ecoInput.text != "")
        {
            _buildingEco = Convert.ToInt16(ecoInput);
        }
        else
        {
            _buildingEco = Convert.ToInt16(ecoPlaceholder);
        }

        //social
        if (socPlaceholder.text != socInput.text && socInput.text != "")
        {
            _buildingSoc = Convert.ToInt16(socInput);
        }
        else
        {
            _buildingSoc = Convert.ToInt16(socPlaceholder);
        }

        //poli
        if (poliPlaceholder.text != poliInput.text && poliInput.text != "")
        {
            _buildingPoli = Convert.ToInt16(poliInput);
        }
        else
        {
            _buildingPoli = Convert.ToInt16(poliPlaceholder);
        }

        //Envi
        if (enviPlaceholder.text != enviInput.text && enviInput.text != "")
        {
            _buildingEnvi = Convert.ToInt16(enviInput);
        }
        else
        {
            _buildingEnvi = Convert.ToInt16(enviPlaceholder);
        }

        //Fluid
        if (fluidPlaceholder.text != fluidInput.text && fluidInput.text != "")
        {
            _buildingFluid = Convert.ToInt16(fluidInput);
        }
        else
        {
            _buildingFluid = Convert.ToInt16(fluidPlaceholder);
        }

        //Attract
        if (attractPlaceholder.text != attractInput.text && attractInput.text != "")
        {
            _buildingAttract = Convert.ToInt16(attractInput);
        }
        else
        {
            _buildingAttract = Convert.ToInt16(attractPlaceholder);
        }

        //Logi
        if (logisticPlaceholder.text != logiInput.text && logiInput.text != "")
        {
            _buildingLogi = Convert.ToInt16(logiInput);
        }
        else
        {
            _buildingLogi = Convert.ToInt16(logisticPlaceholder);
        }

        //logisticDesction
        if (logisticDescriptionPlaceholder.text != logiDescriptionInput.text && logiDescriptionInput.text != "")
        {
            _buildingLogiDescription = logiDescriptionInput.text;
        }
        else
        {
            _buildingLogiDescription = logisticDescriptionPlaceholder.text;
        }

        Building _res = new Building(_buildingName,_buildingDescription,_buildingEco,_buildingSoc,_buildingPoli,_buildingEnvi
            ,_buildingFluid, _buildingAttract, _buildingLogi, _buildingLogiDescription);

        return _res;
    }

}
