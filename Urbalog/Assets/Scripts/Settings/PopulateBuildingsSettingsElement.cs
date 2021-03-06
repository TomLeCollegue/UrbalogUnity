﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class PopulateBuildingsSettingsElement : MonoBehaviour
{
    public TextMeshProUGUI textname;
    public TextMeshProUGUI buildingDescription;
    public TextMeshProUGUI ecoNumberText;
    public TextMeshProUGUI socNumberText;
    public TextMeshProUGUI polNumberText;
    public TextMeshProUGUI envNumberText;
    public TextMeshProUGUI fluNumberText;
    public TextMeshProUGUI attNumberText;
    public TextMeshProUGUI logNumberText;

    public TextMeshProUGUI logisticDescription;


    public Building building;

    public static int buildingNumber = 0;


    private void Start()
    {
        Init();
    }

    public void Init()
    {
        building = ReturnBuildingFromJson();
        if (textname != null)
        {
            textname.text = building.name;
            buildingDescription.text = building.description;
            ecoNumberText.text = building.Economical.ToString();
            socNumberText.text = building.Social.ToString();
            polNumberText.text = building.Political.ToString();
            envNumberText.text = building.enviScore.ToString();
            fluNumberText.text = building.fluidScore.ToString();
            attNumberText.text = building.attractScore.ToString();
            logNumberText.text = building.logisticScore.ToString();
            logisticDescription.text = building.logisticDescription;
        }
    }

    public Building ReturnBuildingFromJson()
    {
        Building[] _buildingList;
        if (GameSettings.Language == "Fr")
        {
            _buildingList = JSONBuildings.loadBuildingsFromJSON("/buildings.json");
        }
        else //GameSettings.Language == "En"
        {
            _buildingList = JSONBuildings.loadBuildingsFromJSON("/buildingsEN.json");
        }
        Building _building = _buildingList[buildingNumber];
        if (buildingNumber<_buildingList.Length-1)
        {
            buildingNumber++;
        }
        return _building;
    }

    /// <summary>
    /// Opens the building settings panel
    /// </summary>
    public void OpenPanelBuilding()
    {
        GameObject.Find("SettingsMenuManager").GetComponent<SettingsMenu>().OpenBuildingSettingsPanel(building);
    }

    /// <summary>
    /// If changes are made, they are saved in buildings.json
    /// </summary>
    public void SaveSettingsOnBuilding()
    {
        GameObject.Find("SettingsMenuManager").GetComponent<SettingsMenu>().ChangeBuildingSettings();
    }



}
