using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchGameManager : MonoBehaviour
{

    /// <summary>
    /// Launch the game, even if we changed scenes.
    /// </summary>
    public void CreateRoom()
    {
        GameObject.Find("NetworkManager").GetComponent<HostGame>().CreateRoom();
    }


    public void ChangeIP(string _ip)
    {
        GameObject.Find("NetworkManager").GetComponent<HostGame>().SetIP(_ip);
    }

    public void ChangeName(string _name)
    {
        GameObject.Find("NetworkManager").GetComponent<HostGame>().SetPlayerName(_name);
    }

    public void ChangePort(string _port)
    {
        GameObject.Find("NetworkManager").GetComponent<HostGame>().SetPort(_port);
    }

    public void JoinGame()
    {
        GameObject.Find("NetworkManager").GetComponent<HostGame>().JoinGame();
    }

    public void DiscoverServer()
    {
        
        GameObject.Find("NetworkManager").GetComponent<HostGame>().Discover();
    }

}
