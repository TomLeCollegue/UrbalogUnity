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
    public Transform SpawnPoste;
    public Transform SpawnBikeRoad;
    public Transform SpawnBorneVelo;
    public Transform SpawnPetitMagasin;

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
            GameObject building = (GameObject)Instantiate(bikeRoad, SpawnBikeRoad.position, SpawnBikeRoad.rotation);
            building.GetComponent<RenameBuilding>().Rename(_building);
            NetworkServer.Spawn(building);
            Buildings.Add(building);
        }
        else if (_building.name.Equals("Borne vélo"))
        {
            GameObject building = (GameObject)Instantiate(BorneVelo, SpawnBorneVelo.position, SpawnBorneVelo.rotation);
            building.GetComponent<RenameBuilding>().Rename(_building);
            NetworkServer.Spawn(building);
            Buildings.Add(building);
        }
        else if (_building.name.Equals("Poste"))
        {
            GameObject building = (GameObject)Instantiate(Poste, SpawnPoste.position, SpawnPoste.rotation);
            building.GetComponent<RenameBuilding>().Rename(_building);
            NetworkServer.Spawn(building);
            Buildings.Add(building);
        }
        else if (_building.name.Equals("Petit magasin"))
        {
            GameObject building = (GameObject)Instantiate(petitMagasin, SpawnPetitMagasin.position, SpawnPetitMagasin.rotation);
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
