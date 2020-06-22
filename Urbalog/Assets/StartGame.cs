﻿using Mirror;
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
        NetworkManager.singleton.ServerChangeScene("PlayerView");
    }


}
