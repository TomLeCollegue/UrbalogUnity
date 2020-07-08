using Mirror;
using Mirror.Discovery;
using System;
using UnityEngine;

public class HostGame : NetworkBehaviour
{
   
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
