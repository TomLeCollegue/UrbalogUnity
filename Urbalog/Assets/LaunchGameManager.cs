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

    public void ChangeSurname(string _surname)
    {
        GameObject.Find("NetworkManager").GetComponent<HostGame>().SetPlayerSurname(_surname);
    }

    public void HandleGenderInputData(int _value)
    {
        if (_value == 0)
        {
            GameObject.Find("NetworkManager").GetComponent<HostGame>().SetGender("Homme");
        }
        if (_value == 1)
        {
            GameObject.Find("NetworkManager").GetComponent<HostGame>().SetGender("Femme");
        }
        if (_value == 2)
        {
            GameObject.Find("NetworkManager").GetComponent<HostGame>().SetGender("Ni l'un ni l'autre");
        }
    }

    public void ChangeAge(string _age)
    {
        GameObject.Find("NetworkManager").GetComponent<HostGame>().SetAge(_age);
    }
    public void HandleAgeInputData(int _value)
    {
        if (_value == 0)
        {
            GameObject.Find("NetworkManager").GetComponent<HostGame>().SetGender("Homme");
        }
        if (_value == 1)
        {
            GameObject.Find("NetworkManager").GetComponent<HostGame>().SetGender("Femme");
        }
        if (_value == 2)
        {
            GameObject.Find("NetworkManager").GetComponent<HostGame>().SetGender("Ni l'un ni l'autre");
        }
    }

    public void ChangeZipcode(string _zipcode)
    {
        GameObject.Find("NetworkManager").GetComponent<HostGame>().SetZipcode(_zipcode);
    }

    public void ChangeCompany(string _company)
    {
        GameObject.Find("NetworkManager").GetComponent<HostGame>().SetCompany(_company);
    }
    public void ChangeJobStatus(string _jobStatus)
    {
        GameObject.Find("NetworkManager").GetComponent<HostGame>().SetAge(_jobStatus);
    }
    public void ChangeField(string _field)
    {
        GameObject.Find("NetworkManager").GetComponent<HostGame>().SetField(_field);
    }


    public void ChangePort(string _port)
    {
        GameObject.Find("NetworkManager").GetComponent<HostGame>().SetPort(_port);
    }

    public void JoinGame()
    {
        GameObject.Find("NetworkManager").GetComponent<HostGame>().JoinGame();
    }

}
