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
    public void ChangeGender(string _gender)
    {
        GameObject.Find("NetworkManager").GetComponent<HostGame>().SetGender(_gender);
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
            GameObject.Find("NetworkManager").GetComponent<HostGame>().SetAge("Moins de 15 ans");
        }
        if (_value == 1)
        {
            GameObject.Find("NetworkManager").GetComponent<HostGame>().SetAge("de 15 à 18 ans");
        }
        if (_value == 2)
        {
            GameObject.Find("NetworkManager").GetComponent<HostGame>().SetAge("de 19 à 24 ans");
        }
        if (_value == 3)
        {
            GameObject.Find("NetworkManager").GetComponent<HostGame>().SetAge("de 25 à 34 ans");
        }
        if (_value == 4)
        {
            GameObject.Find("NetworkManager").GetComponent<HostGame>().SetAge("de 35 à 44 ans");
        }
        if (_value == 5)
        {
            GameObject.Find("NetworkManager").GetComponent<HostGame>().SetAge("de 45 à 54 ans");
        }
        if (_value == 6)
        {
            GameObject.Find("NetworkManager").GetComponent<HostGame>().SetAge("de 55 à 64 ans");
        }
        if (_value == 7)
        {
            GameObject.Find("NetworkManager").GetComponent<HostGame>().SetAge("65 ans et plus");
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
        GameObject.Find("NetworkManager").GetComponent<HostGame>().SetJobStatus(_jobStatus);
    }

    public void HandleJobStatusInputData(int _value)
    {
        if (_value == 0)
        {
            GameObject.Find("NetworkManager").GetComponent<HostGame>().SetJobStatus("Salarié");
        }
        if (_value == 1)
        {
            GameObject.Find("NetworkManager").GetComponent<HostGame>().SetJobStatus("Indépendant");
        }
        if (_value == 2)
        {
            GameObject.Find("NetworkManager").GetComponent<HostGame>().SetJobStatus("Chômeur");
        }
        if (_value == 3)
        {
            GameObject.Find("NetworkManager").GetComponent<HostGame>().SetJobStatus("Retraité");
        }
        if (_value == 4)
        {
            GameObject.Find("NetworkManager").GetComponent<HostGame>().SetJobStatus("Autres inactifs (dont étudiants)");
        }
    }
    public void ChangeField(string _field)
    {
        GameObject.Find("NetworkManager").GetComponent<HostGame>().SetField(_field);
    }
    public void HandleFieldInputData(int _value)
    {
        if (_value == 0)
        {
            GameObject.Find("NetworkManager").GetComponent<HostGame>().SetAge("Moins de 15 ans");
        }
        if (_value == 1)
        {
            GameObject.Find("NetworkManager").GetComponent<HostGame>().SetAge("de 15 à 18 ans");
        }
        if (_value == 2)
        {
            GameObject.Find("NetworkManager").GetComponent<HostGame>().SetAge("de 19 à 24 ans");
        }
        if (_value == 3)
        {
            GameObject.Find("NetworkManager").GetComponent<HostGame>().SetAge("de 25 à 34 ans");
        }
        if (_value == 4)
        {
            GameObject.Find("NetworkManager").GetComponent<HostGame>().SetAge("de 35 à 44 ans");
        }
        if (_value == 5)
        {
            GameObject.Find("NetworkManager").GetComponent<HostGame>().SetAge("de 45 à 54 ans");
        }
        if (_value == 6)
        {
            GameObject.Find("NetworkManager").GetComponent<HostGame>().SetAge("de 55 à 64 ans");
        }
        if (_value == 7)
        {
            GameObject.Find("NetworkManager").GetComponent<HostGame>().SetAge("65 ans et plus");
        }
        if (_value == 8)
        {
            GameObject.Find("NetworkManager").GetComponent<HostGame>().SetAge("65 ans et plus");
        }
        if (_value == 9)
        {
            GameObject.Find("NetworkManager").GetComponent<HostGame>().SetAge("65 ans et plus");
        }
        if (_value == 10)
        {
            GameObject.Find("NetworkManager").GetComponent<HostGame>().SetAge("65 ans et plus");
        }
        if (_value == 11)
        {
            GameObject.Find("NetworkManager").GetComponent<HostGame>().SetAge("65 ans et plus");
        }
        if (_value == 12)
        {
            GameObject.Find("NetworkManager").GetComponent<HostGame>().SetAge("65 ans et plus");
        }
        if (_value == 13)
        {
            GameObject.Find("NetworkManager").GetComponent<HostGame>().SetAge("65 ans et plus");
        }
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
