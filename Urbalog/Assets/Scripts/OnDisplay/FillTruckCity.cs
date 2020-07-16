using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class FillTruckCity : NetworkBehaviour
{
    [SerializeField]
    private Transform[] SpawnPoints;
    public GameObject Truck;

    [SerializeField]
    private List<GameObject> Trucks = new List<GameObject>();
    // Start is called before the first frame update
    public void SpawnTrucks()
    {
        DestroyTrucks();

        Shuffle();
        int LogisticScore = GameManager.singleton.game.cityLogistic;
        int nbTruck = 0;
        if (LogisticScore <= -2)
        {
            nbTruck = 6;
        }
        else if ((LogisticScore > -2) && (LogisticScore <= 0))
        {
            nbTruck = 4;
        }
        else if ((LogisticScore > 0) && (LogisticScore <= 2))
        {
            nbTruck = 3;
        }
        else
        {
            nbTruck = 2;
        }

        for (int i = 0; i < nbTruck; i++)
        {
            Spawn(SpawnPoints[i]);
        }
    }

    public void Spawn(Transform spawnPoint)
    {
        GameObject truck = (GameObject)Instantiate(Truck, spawnPoint.position, spawnPoint.rotation);
        NetworkServer.Spawn(truck);
        Trucks.Add(truck);
    }


    public void DestroyTrucks()
    {
        for (int i = 0; i < Trucks.Count; i++)
        {
            Destroy(Trucks[i]);
        }
        Trucks.Clear();
    }

    public void Shuffle()
    {
        Transform tempGO;
        for (int i = 0; i < SpawnPoints.Length; i++)
        {
            int rnd = Random.Range(i, SpawnPoints.Length);
            tempGO = SpawnPoints[rnd];
            SpawnPoints[rnd] = SpawnPoints[i];
            SpawnPoints[i] = tempGO;
        }
    }
}
