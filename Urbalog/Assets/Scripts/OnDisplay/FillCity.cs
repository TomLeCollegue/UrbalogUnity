using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillCity : NetworkBehaviour
{
    [SerializeField]
    private Transform[] SpawnPoints;
    public GameObject Building;

    //Stocl la liste des buildings contruits sur la map
    [SerializeField]
    private List<GameObject> Buildings = new List<GameObject>();

    private void Update()
    {

        //Test Spawn Buildings
        /*if (isServer)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Spawn("CDU", SpawnPoints[2]);
            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                Spawn("Poste de Relevage", SpawnPoints[3]);
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                DestroyBuildings();
            }


        }*/
    }


    public void SpawnBuildingsBuilt()
    {
        DestroyBuildings();
        Game _game = GameManager.singleton.game;

        for (int i = 0; i < _game.BuildingsBuilt.Count; i++)
        {
            Spawn(_game.BuildingsBuilt[i].name, SpawnPoints[i]);
        }
    }

    
    public void Spawn(string NameBuilding, Transform spawnPoint)
    {
        GameObject building = (GameObject)Instantiate(Building, spawnPoint.position, spawnPoint.rotation);
        building.GetComponent<RenameBuilding>().Rename(NameBuilding);
        NetworkServer.Spawn(building);
        Buildings.Add(building);
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
