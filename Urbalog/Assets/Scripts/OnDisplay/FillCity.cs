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
