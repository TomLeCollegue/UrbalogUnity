using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillCity : NetworkBehaviour
{
    [SerializeField]
    private Transform[] SpawnPoints;
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

    //Stock la liste des buildings contruits sur la map
    [SerializeField]
    private List<GameObject> Buildings = new List<GameObject>();


    public void SpawnBuildingsBuilt()
    {
        DestroyBuildings();
        Game _game = GameManager.singleton.game;

        for (int i = 0; i < _game.BuildingsBuilt.Count; i++)
        {
            Spawn(_game.BuildingsBuilt[i], SpawnPoints[i]);
        }
    }

    
    public void Spawn(Building _building, Transform spawnPoint)
    {
        if(_building.name.Equals("Piste cyclable"))
        {
            GameObject building = (GameObject)Instantiate(bikeRoad);
            building.GetComponent<RenameBuilding>().Rename(_building);
            NetworkServer.Spawn(building);
            Buildings.Add(building);
        }
        else if (_building.name.Equals("Borne vélo"))
        {
            GameObject building = (GameObject)Instantiate(BorneVelo);
            building.GetComponent<RenameBuilding>().Rename(_building);
            NetworkServer.Spawn(building);
            Buildings.Add(building);
        }
        else if (_building.name.Equals("Poste"))
        {
            GameObject building = (GameObject)Instantiate(Poste);
            building.GetComponent<RenameBuilding>().Rename(_building);
            NetworkServer.Spawn(building);
            Buildings.Add(building);
        }
        else if (_building.name.Equals("Petit magasin"))
        {
            GameObject building = (GameObject)Instantiate(petitMagasin);
            building.GetComponent<RenameBuilding>().Rename(_building);
            NetworkServer.Spawn(building);
            Buildings.Add(building);
        }
        else if (_building.name.Equals("CDU"))
        {
            GameObject building = (GameObject)Instantiate(CDU);
            building.GetComponent<RenameBuilding>().Rename(_building);
            NetworkServer.Spawn(building);
            Buildings.Add(building);
        }
        else if (_building.name.Equals("Banc"))
        {
            GameObject building = (GameObject)Instantiate(banc);
            building.GetComponent<RenameBuilding>().Rename(_building);
            NetworkServer.Spawn(building);
            Buildings.Add(building);
        }
        else if (_building.name.Equals("PAV"))
        {
            GameObject building = (GameObject)Instantiate(PAV);
            building.GetComponent<RenameBuilding>().Rename(_building);
            NetworkServer.Spawn(building);
            Buildings.Add(building);
        }
        else if (_building.name.Equals("Grand magasin"))
        {
            GameObject building = (GameObject)Instantiate(bigMarket);
            building.GetComponent<RenameBuilding>().Rename(_building);
            NetworkServer.Spawn(building);
            Buildings.Add(building);
        }
        else if (_building.name.Equals("Réseau de consignes"))
        {
            GameObject building = (GameObject)Instantiate(consigne);
            building.GetComponent<RenameBuilding>().Rename(_building);
            NetworkServer.Spawn(building);
            Buildings.Add(building);
        }
        else if (_building.name.Equals("Zone végétalisée"))
        {
            GameObject building = (GameObject)Instantiate(garden);
            building.GetComponent<RenameBuilding>().Rename(_building);
            NetworkServer.Spawn(building);
            Buildings.Add(building);
        }
        else if (_building.name.Equals("Stations GAZ GNV"))
        {
            GameObject building = (GameObject)Instantiate(gazStation);
            building.GetComponent<RenameBuilding>().Rename(_building);
            NetworkServer.Spawn(building);
            Buildings.Add(building);
        }
        else if (_building.name.Equals("Zone de rencontre"))
        {
            GameObject building = (GameObject)Instantiate(meeting);
            building.GetComponent<RenameBuilding>().Rename(_building);
            NetworkServer.Spawn(building);
            Buildings.Add(building);
        }
        else if (_building.name.Equals("Aire de livraison"))
        {
            GameObject building = (GameObject)Instantiate(delivery);
            building.GetComponent<RenameBuilding>().Rename(_building);
            NetworkServer.Spawn(building);
            Buildings.Add(building);
        }
        else if (_building.name.Equals("Dispositif anti-bélier"))
        {
            GameObject building = (GameObject)Instantiate(antiram);
            building.GetComponent<RenameBuilding>().Rename(_building);
            NetworkServer.Spawn(building);
            Buildings.Add(building);
        }
        else if (_building.name.Equals("Terrasse"))
        {
            GameObject building = (GameObject)Instantiate(antiram);
            building.GetComponent<RenameBuilding>().Rename(_building);
            NetworkServer.Spawn(building);
            Buildings.Add(building);
        }
        else
        {
            GameObject building = (GameObject)Instantiate(Building, spawnPoint.position, spawnPoint.rotation);
            building.GetComponent<RenameBuilding>().Rename(_building);
            NetworkServer.Spawn(building);
            Buildings.Add(building);
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
