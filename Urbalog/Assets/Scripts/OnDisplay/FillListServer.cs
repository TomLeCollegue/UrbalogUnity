using Mirror.Discovery;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillListServer : MonoBehaviour
{
    public GameObject ServerItem;
    public Transform listHolder;
    public List<GameObject> ServerItemInList = new List<GameObject>();



    public void UpdateList()
    {
        DestroyList();
        Dictionary<long, ServerResponse> discoveredServers = GameObject.Find("NetworkManager").GetComponent<NetworkDiscoveryHUD>().GetListServer();
        foreach (ServerResponse info in discoveredServers.Values)
            SpawnServerItem(info.EndPoint.Address.ToString());
                

    }
    public void SpawnServerItem(string ip)
    {
        GameObject Item = Instantiate(ServerItem, listHolder);
        Item.GetComponent<RenameServeur>().RenameItem(ip);

        ServerItemInList.Add(Item);
    }

    void DestroyList()
    {
        for (int i = 0; i < ServerItemInList.Count; i++)
        {
            Destroy(ServerItemInList[i]);
        }
        ServerItemInList.Clear();
    }
}
