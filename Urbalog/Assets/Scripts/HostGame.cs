using Mirror;
using UnityEngine;

public class HostGame : MonoBehaviour
{
    [SerializeField]
    private uint roomSize = 6;
    public string roomName = "name";
    private NetworkManager networkManager;

    void Start()
    {
        networkManager = NetworkManager.singleton;

    }
    public void SetRoomName (string _name)
    {
        roomName = _name;
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
        networkManager.StartClient();
    }
}
