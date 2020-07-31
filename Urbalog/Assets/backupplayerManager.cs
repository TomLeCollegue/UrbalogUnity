using Mirror;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        for (int i = 0; i < GameManager.singleton.playersBackup.Count; i++)
        {
            for (int j = 0; j < GameManager.singleton.players.Count; j++)
            {
                if (GameManager.singleton.players[j].namePlayer.Equals(GameManager.singleton.playersBackup[i].namePlayer) && GameManager.singleton.players[j].role.nameRole.Equals(GameManager.singleton.playersBackup[i].role.nameRole))
                {
                    Player player = GameManager.singleton.players[j];
                    GameManager.singleton.playersBackup[i].role.ressourcePolitical = player.role.ressourcePolitical;
                    GameManager.singleton.playersBackup[i].role.ressourceEconomical = player.role.ressourceEconomical;
                    GameManager.singleton.playersBackup[i].role.ressourceSocial = player.role.ressourceSocial;
                    GameManager.singleton.playersBackup[i].scorePlayer = player.scorePlayer;
                }
            }
            
        }

    }


}
