using Mirror;
using UnityEngine;

public class HostGame : NetworkBehaviour
{
    [SerializeField]
    private uint roomSize = 6;

    [SyncVar]
    public string roomName = "En Attente des joueurs";


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
        if(roomName != "" && roomName != null)
        {
            Debug.Log("Creating Room: " + roomName + ", Max player : " + roomSize);
            networkManager.StartHost();

        }
    }

    public void JoinGame()
    {
        GetComponent<NetworkManager>().StartClient();
    }

    public void SetPort(string _port)
    {
        // set port 
    }
}
