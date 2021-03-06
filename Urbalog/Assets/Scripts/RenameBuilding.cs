﻿using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RenameBuilding : NetworkBehaviour
{
    public TextMeshProUGUI BuildingName;
    public Building building;
    public GameObject LogistiqueButton;
    public TextMeshProUGUI LogistiqueScore;
    
    
    [SyncVar]
    public string NameBuilding;

    private void Start()
    {
        BuildingName.text = NameBuilding;
        building = searchthebuilding();
    }

    public void Rename(Building _building)
    {
        NameBuilding = _building.name;
        BuildingName.text = NameBuilding;
        building = _building;
    }

    public Building searchthebuilding()
    {
        List<Building> buildings = GameManager.singleton.game.DeckBuildings;
        for (int i = 0; i < buildings.Count; i++)
        {
            if (buildings[i].name.Equals(NameBuilding))
            {
                return buildings[i];
            }
        }
        return buildings[0];
    }

    public void DisplayBuildingInfo()
    {
        Debug.Log("Building "  + NameBuilding);
        GameObject.Find("PlayerViewManager").GetComponent<PopUpBuildingDisplay>().DisplayPopUp(building);
    }


    public void DisplayLogisticBuildingInfo()
    {
        Debug.Log("Building " + NameBuilding);
        GameObject.Find("PlayerViewManager").GetComponent<PopUpBuildingDisplay>().DisplayPopUp(building);
    }



    public void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("EndGame"))
        {
            LogistiqueButton.SetActive(true);
            LogistiqueScore.text = building.logisticScore.ToString();
        }
    }
}
