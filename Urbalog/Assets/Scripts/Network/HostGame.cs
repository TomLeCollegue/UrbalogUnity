using Mirror;
using Mirror.Discovery;
using System;
using UnityEngine;

public class HostGame : NetworkBehaviour
{
   
    public string playerName = "nameplayer";
    private NetworkManager networkManager;

    void Start()
    {
        networkManager = NetworkManager.singleton;

    }
    public void SetPlayerName (string _name)
    {
        playerName = _name;
    }
    public void SetIP(string _ip)
    {
        networkManager.networkAddress = _ip;
    }

    public void CreateRoom()
    {
        networkManager.StartHost();
        GetComponent<NetworkDiscovery>().AdvertiseServer();

    }

    public void JoinGame()
    {
        GetComponent<NetworkManager>().StartClient();


    }

    public void SetPort(string _port)
    {
        GetComponent<TelepathyTransport>().port = Convert.ToUInt16(_port);
    }

    public void Discover()
    {
        GetComponent<NetworkDiscovery>().StartDiscovery();
    }

}
