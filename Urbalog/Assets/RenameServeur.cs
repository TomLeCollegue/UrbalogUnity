using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RenameServeur : MonoBehaviour
{
    public string AdresseServer;
    public TextMeshProUGUI textServer;
    Color urbaBlack = new Color(0.1764706f, 0.1686275f, 0.2470588f);
    Color urbaGreen = new Color(0.56f, 0.68f, 0.32f);
    public void RenameItem(string adresseServer)
    {
        AdresseServer = adresseServer;
        textServer.text = adresseServer;
    }

    public void SetServeur()
    {
        NetworkManager.singleton.networkAddress = AdresseServer;
    }


    public void Update()
    {
        string adresse = NetworkManager.singleton.networkAddress;
        if (AdresseServer.Equals(adresse))
        {
            textServer.color = urbaGreen;
        }
        else
        {
            textServer.color = urbaBlack;
        }
    }
}
