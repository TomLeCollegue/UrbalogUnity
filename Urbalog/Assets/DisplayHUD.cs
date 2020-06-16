using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayHUD : NetworkBehaviour
{
    public NetworkManagerHUD hud;
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "LobbyRoom" )
        {
            hud.showGUI = true;
        }
        else
        {
            hud.showGUI = false;
        }


        if (isServer)
        {
            hud.showGUI = true;
        }
    }
}
