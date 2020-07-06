using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingSettingItem : MonoBehaviour
{
    public Building building;
    public TextMeshProUGUI buildingName;

    

    public Building ReturnBuildingFromJson()
    {
        Building[] _buildingList = JSONBuildings.loadBuildingsFromJSON("/buildings.json");

        Building _building = _buildingList[PopulateBuildingsSettingsElement.buildingNumber];
        PopulateBuildingsSettingsElement.buildingNumber++;
        return _building;
    }



    // Start is called before the first frame update
    void Start()
    {
        if (building != null)
        {
            building = ReturnBuildingFromJson();
            buildingName.text = building.name;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
