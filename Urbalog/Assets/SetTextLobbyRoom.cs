using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetTextLobbyRoom : MonoBehaviour
{
    public TextMeshProUGUI LobbyRoomName;

    private void Start()
    {
        uint port = GameObject.Find("NetworkManager").GetComponent<TelepathyTransport>().port;
        if (port == 7777)
        {
            LobbyRoomName.text = "Table 1";
        }
        else if (port == 7778)
        {
            LobbyRoomName.text = "Table 2";
        }
        else if (port == 7779)
        {
            LobbyRoomName.text = "Table 3";
        }
        else if (port == 7776)
        {
            LobbyRoomName.text = "Table 4";
        }
        else
        {
            LobbyRoomName.text = "Table 5";
        }
    }
}
