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
        NetworkManager.singleton.ServerChangeScene("PlayerView");
        BackupPlayers();
    }


     public void LogInit()
    {
        LogManager logManager = LogManager.singleton;
        logManager.GetPlayers();
        logManager.NewTurn();
        logManager.GetDeckBuilding();

        
    }


    void BackupPlayers()
    {
        for (int i = 0; i < GameManager.singleton.players.Count; i++)
        {
            Player player = GameManager.singleton.players[i];
            GameManager.singleton.playersBackup.Add(new PlayerBackUp(player.role, player.namePlayer, player.playerFamilyName, player.gender, player.age, player.zipcode, player.company, player.jobStatus, player.field, player.nameRole, player.ID, player.nextTurn, player.scorePlayer,player.OldScore,player.num)); ;
        }

    }


}
