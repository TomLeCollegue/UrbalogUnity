using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backupplayerManager : NetworkBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if (isServer)
        {
            BackupPlayers();
        }
    }

    void BackupPlayers()
    {
        for (int i = 0; i < GameManager.singleton.players.Count; i++)
        {
            Player player = GameManager.singleton.players[i];
            GameManager.singleton.playersBackup.Add(new PlayerBackUp(player.role, player.namePlayer, player.playerFamilyName, player.gender, player.age, player.zipcode, player.company, player.jobStatus, player.field, player.nameRole, player.ID, player.nextTurn, player.scorePlayer, player.OldScore, player.num)); ;
        }


        for (int i = 0; i < GameManager.singleton.playersBackup.Count; i++)
        {
            for (int j = 0; j < GameManager.singleton.players.Count; j++)
            {
                if (GameManager.singleton.players[j].namePlayer.Equals(GameManager.singleton.playersBackup[i].namePlayer))
                {
                    Player player = GameManager.singleton.players[j];
                    GameManager.singleton.playersBackup.RemoveAt(i);
                    GameManager.singleton.playersBackup.Add(new PlayerBackUp(player.role, player.namePlayer, player.playerFamilyName, player.gender, player.age, player.zipcode, player.company, player.jobStatus, player.field, player.nameRole, player.ID, player.nextTurn, player.scorePlayer, player.OldScore, player.num));
                }
            }
            
        }

    }


}
