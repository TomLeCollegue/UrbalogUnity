﻿using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillCity : NetworkBehaviour
{
    [SerializeField]
    private Transform[] SpawnPoints; // 3 
    public GameObject Building;
    public GameObject bikeRoad;
    public GameObject Poste;
    public GameObject BorneVelo;
    public GameObject petitMagasin;
    public GameObject CDU;
    public GameObject banc;
    public GameObject PAV;
    public GameObject bigMarket;
    public GameObject consigne;
    public GameObject garden;
    public GameObject gazStation;
    public GameObject terrasse;
    public GameObject meeting;
    public GameObject delivery;
    public GameObject antiram;
    public int nbSpawnPointUsed = 0; 

    //Stock la liste des buildings contruits sur la map
    [SerializeField]
    private List<GameObject> Buildings = new List<GameObject>();


    public void SpawnBuildingsBuilt()
    {
        DestroyBuildings();
        Game _game = GameManager.singleton.game;

        for (int i = 0; i < _game.BuildingsBuilt.Count; i++)
        {
            Spawn(_game.BuildingsBuilt[i]);
        }
    }

    
    public void Spawn(Building _building)
    {
        if(_building.nameForSprite.Equals("Piste cyclable"))
        {
            GameObject building = (GameObject)Instantiate(bikeRoad);
            building.GetComponent<RenameBuilding>().Rename(_building);
            NetworkServer.Spawn(building);
            Buildings.Add(building);
        }
        else if (_building.nameForSprite.Equals("Borne vélo"))
        {
            GameObject building = (GameObject)Instantiate(BorneVelo);
            building.GetComponent<RenameBuilding>().Rename(_building);
            NetworkServer.Spawn(building);
            Buildings.Add(building);
        }
        else if (_building.nameForSprite.Equals("Poste"))
        {
            GameObject building = (GameObject)Instantiate(Poste);
            building.GetComponent<RenameBuilding>().Rename(_building);
            NetworkServer.Spawn(building);
            Buildings.Add(building);
        }
        else if (_building.nameForSprite.Equals("Petit magasin"))
        {
            GameObject building = (GameObject)Instantiate(petitMagasin);
            building.GetComponent<RenameBuilding>().Rename(_building);
            NetworkServer.Spawn(building);
            Buildings.Add(building);
        }
        else if (_building.nameForSprite.Equals("CDU"))
        {
            GameObject building = (GameObject)Instantiate(CDU);
            building.GetComponent<RenameBuilding>().Rename(_building);
            NetworkServer.Spawn(building);
            Buildings.Add(building);
        }
        else if (_building.nameForSprite.Equals("Banc"))
        {
            GameObject building = (GameObject)Instantiate(banc);
            building.GetComponent<RenameBuilding>().Rename(_building);
            NetworkServer.Spawn(building);
            Buildings.Add(building);
        }
        else if (_building.nameForSprite.Equals("PAV"))
        {
            GameObject building = (GameObject)Instantiate(PAV);
            building.GetComponent<RenameBuilding>().Rename(_building);
            NetworkServer.Spawn(building);
            Buildings.Add(building);
        }
        else if (_building.nameForSprite.Equals("Grand magasin"))
        {
            GameObject building = (GameObject)Instantiate(bigMarket);
            building.GetComponent<RenameBuilding>().Rename(_building);
            NetworkServer.Spawn(building);
            Buildings.Add(building);
        }
        else if (_building.nameForSprite.Equals("Réseau de consignes"))
        {
            GameObject building = (GameObject)Instantiate(consigne);
            building.GetComponent<RenameBuilding>().Rename(_building);
            NetworkServer.Spawn(building);
            Buildings.Add(building);
        }
        else if (_building.nameForSprite.Equals("Zone végétalisée"))
        {
            GameObject building = (GameObject)Instantiate(garden);
            building.GetComponent<RenameBuilding>().Rename(_building);
            NetworkServer.Spawn(building);
            Buildings.Add(building);
        }
        else if (_building.nameForSprite.Equals("Stations GAZ GNV"))
        {
            GameObject building = (GameObject)Instantiate(gazStation);
            building.GetComponent<RenameBuilding>().Rename(_building);
            NetworkServer.Spawn(building);
            Buildings.Add(building);
        }
        else if (_building.nameForSprite.Equals("Zone de rencontre"))
        {
            GameObject building = (GameObject)Instantiate(meeting);
            building.GetComponent<RenameBuilding>().Rename(_building);
            NetworkServer.Spawn(building);
            Buildings.Add(building);
        }
        else if (_building.nameForSprite.Equals("Aire de livraison"))
        {
            GameObject building = (GameObject)Instantiate(delivery);
            building.GetComponent<RenameBuilding>().Rename(_building);
            NetworkServer.Spawn(building);
            Buildings.Add(building);
        }
        else if (_building.nameForSprite.Equals("Dispositif anti-bélier"))
        {
            GameObject building = (GameObject)Instantiate(antiram);
            building.GetComponent<RenameBuilding>().Rename(_building);
            NetworkServer.Spawn(building);
            Buildings.Add(building);
        }
        else if (_building.nameForSprite.Equals("Terrasse"))
        {
            GameObject building = (GameObject)Instantiate(terrasse);
            building.GetComponent<RenameBuilding>().Rename(_building);
            NetworkServer.Spawn(building);
            Buildings.Add(building);
        }
        else
        {
            GameObject building = (GameObject)Instantiate(Building, SpawnPoints[nbSpawnPointUsed].position, SpawnPoints[nbSpawnPointUsed].rotation);
            building.GetComponent<RenameBuilding>().Rename(_building);
            NetworkServer.Spawn(building);
            Buildings.Add(building);
            nbSpawnPointUsed++; // We used a spawn point
        }

    }

    public void DestroyBuildings()
    {
        for (int i = 0; i < Buildings.Count; i++)
        {
            Destroy(Buildings[i]);
        }
            Buildings.Clear();
    }


}
