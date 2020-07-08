using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RenameServeur : MonoBehaviour
{
    public string AdresseServer;
    public TextMeshProUGUI textServer;

    public void RenameItem(string adresseServer)
    {
        AdresseServer = adresseServer;
        textServer.text = adresseServer;
    }

    public void SetServeur()
    {
        NetworkManager.singleton.networkAddress = AdresseServer;
    }
}
