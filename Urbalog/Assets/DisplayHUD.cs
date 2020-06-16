using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayHUD : MonoBehaviour
{
    public NetworkManagerHUD hud;
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Lobby")
        {
            hud.showGUI = false;
        }
        else
        {
            hud.showGUI = true;
        }
    }
}
