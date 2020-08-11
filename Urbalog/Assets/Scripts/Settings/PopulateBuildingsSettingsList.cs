using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PopulateBuildingsSettingsList : MonoBehaviour
{
    public Transform targetTransform;
    //public PopulateBuildingsSettingsElement itemDisplay;    
    public GameObject itemDisplay;

    //public List<PopulateBuildingsSettingsElement> liste = new List<PopulateBuildingsSettingsElement>(); 
    public List<GameObject> liste = new List<GameObject>(); 

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Loads the buildings in the JSON file and display them in the building display list
    /// </summary>
    public void Init()
    {
        PopulateBuildingsSettingsElement.buildingNumber = 0;
        Building[] _buildingList;
        if (GameSettings.Language == "Fr")
        {
            _buildingList = JSONBuildings.loadBuildingsFromJSON("/buildings.json");
        }
        else //(GameSettings.Language == "En")
        {
            _buildingList = JSONBuildings.loadBuildingsFromJSON("/buildingsEN.json");
        }
        //Building[] _buildingList = JSONBuildings.loadBuildingsFromJSON(Directory.GetCurrentDirectory() + "\\Assets\\buildings.json");
        for (int i = 0; i < _buildingList.Length; i++)
        {
            GameObject _elementDisplay = Instantiate(itemDisplay, targetTransform);
            liste.Add(_elementDisplay);
            //_elementDisplay.transform.SetParent(targetTransform, false);
        }
    }

    /// <summary>
    /// Deletes the buildings that are in the buildings settings list
    /// </summary>
    public void destroyListe()
    {
        for (int i = 0; i < liste.Count; i++)
        {
            Destroy(liste[i]);
        }
        liste.Clear();
    }

}
