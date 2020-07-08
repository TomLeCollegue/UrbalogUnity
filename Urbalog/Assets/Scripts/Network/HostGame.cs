using Mirror;
using System;
using UnityEngine;

public class HostGame : NetworkBehaviour
{
    [SerializeField]
    private uint roomSize = 6;

    [SyncVar]
    public string roomName = "En Attente des joueurs";


    public string playerName = "nameplayer";
    public string playerSurname = "";
    public string gender = "";
    public string age = "";
    public string zipcode = "";
    public string company = "";
    public string jobStatus = "";
    public string field = "";

    private NetworkManager networkManager;

    void Start()
    {
        networkManager = NetworkManager.singleton;

    }
    public void SetPlayerName (string _name)
    {
        playerName = _name;
    }
    public void SetPlayerSurname(string _surname)
    {
        playerSurname = _surname;
    }

    public void SetGender(string _gender)
    {
        gender = _gender;
    }

    public void SetAge(string _age)
    {
        age = _age;
    }

    public void SetZipcode(string _zipcode)
    {
        zipcode = _zipcode;
    }

    public void SetCompany(string _company)
    {
       company = _company;
    }
    public void SetJobStatus(string _jobStatus)
    {
        jobStatus = _jobStatus;
    }
    public void SetField(string _field)
    {
        field = _field;
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
        GetComponent<TelepathyTransport>().port = Convert.ToUInt16(_port);
    }
}
