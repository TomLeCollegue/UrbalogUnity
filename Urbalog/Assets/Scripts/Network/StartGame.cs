using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : NetworkBehaviour
{
    public void CallChangeScene()
    {
            CmdChangeScene();
    }

    /// <summary>
    /// Changes gameScene to begin the game.
    /// </summary>
    [Server]
    void CmdChangeScene()
    {
        NetworkManager.singleton.ServerChangeScene("DragDropScene");
    }


     public void LogInit()
    {
        LogManager logManager = LogManager.singleton;
        logManager.GetPlayers();
        logManager.NewTurn();
        logManager.GetDeckBuilding();

        
    }


}
