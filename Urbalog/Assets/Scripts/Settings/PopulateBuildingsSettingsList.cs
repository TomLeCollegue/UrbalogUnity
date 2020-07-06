using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateBuildingsSettingsList : MonoBehaviour
{
    public Transform targetTransform;
    public PopulateBuildingsSettingsElement itemDisplay;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init()
    {
        Building[] _buildingList = JSONBuildings.loadBuildingsFromJSON("/buildings.json");
        for (int i = 0; i < _buildingList.Length; i++)
        {
            PopulateBuildingsSettingsElement _elementDisplay = Instantiate(itemDisplay);
            _elementDisplay.transform.SetParent(targetTransform, false);
        }
    }
}
