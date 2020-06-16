﻿using Mirror;
using System;
using System.Dynamic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;



[RequireComponent(typeof(Player))]
public class PlayerSetup : NetworkBehaviour
{

    [SerializeField]
    Behaviour[] componentsToDisable;


    void Start()
    {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }
        }
        else 
        { transform.name = "playerLocal";}

    }
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public override void OnStartClient()
    {
        base.OnStartClient();
        string _netID = GetComponent<NetworkIdentity>().netId.ToString();
        Player _player = GetComponent<Player>();
        _player.ID = _netID;
        if (isLocalPlayer)
        {
            _player.namePlayer = GameObject.Find("NetworkManager").GetComponent<HostGame>().playerName;
        }
        GameManager.singleton.RegisterPlayer(_player);

        CmdSendActualGameManager();
        CmdGetRoleForPlayer();


    }

    private void OnDisable()
    {
        Player _player = GetComponent<Player>();
        Debug.Log("remove");
        GameManager.singleton.UnRegisterPlayer(_player.ID);

    }


    #region getGameManager Fonction
    [Command]
    void CmdSendActualGameManager()
    {
        RpcGetActualGameManager(GetbyteGameManager(GameManager.singleton.game));

    }
    private byte[] GetbyteGameManager(Game game)
    {
        var formatter = new BinaryFormatter();
        using (var stream = new MemoryStream())
        {
            formatter.Serialize(stream, game);
            return stream.ToArray();
        }
    }

    private Game ByteArrayToObject(byte[] arrBytes)
    {
        MemoryStream memStream = new MemoryStream();
        BinaryFormatter binForm = new BinaryFormatter();
        memStream.Write(arrBytes, 0, arrBytes.Length);
        memStream.Seek(0, SeekOrigin.Begin);
        Game obj = (Game)binForm.Deserialize(memStream);

        return obj;
    }

    [ClientRpc]
    void RpcGetActualGameManager(byte[] bytes)
    {
        Game gameReceived = ByteArrayToObject(bytes);
        GameManager.singleton.game = gameReceived;
        
    }
    #endregion


    #region DistribRole

    private byte[] GetbyteFromObject(System.Object obj)
    {
        var formatter = new BinaryFormatter();
        using (var stream = new MemoryStream())
        {
            formatter.Serialize(stream, obj);
            return stream.ToArray();
        }
    }

    private System.Object ByteArrayToObject2(byte[] arrBytes)
    {
        MemoryStream memStream = new MemoryStream();
        BinaryFormatter binForm = new BinaryFormatter();
        memStream.Write(arrBytes, 0, arrBytes.Length);
        memStream.Seek(0, SeekOrigin.Begin);
        System.Object obj = (System.Object)binForm.Deserialize(memStream);

        return obj;
    }


    [Command]
    void CmdGetRoleForPlayer()
    {
        int numToSend = GameManager.singleton.NumPlayerForRole;

        Role role = GameManager.singleton.game.Roles[numToSend];
        RpcSendRoleForPlayer(GetbyteFromObject(role));
        GameManager.singleton.NumPlayerForRole++;
           
    }

    [ClientRpc]
    void RpcSendRoleForPlayer(byte[] arrByte)
    {
        Player player = GetComponent<Player>();
        if(player.role != null)
        {
            return;
        }
        player.role = (Role)ByteArrayToObject2(arrByte);
    }


    #endregion

}
