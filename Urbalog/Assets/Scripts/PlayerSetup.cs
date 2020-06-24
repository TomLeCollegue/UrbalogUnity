using Mirror;
using System;
using System.Collections;
using System.Dynamic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[RequireComponent(typeof(Player))]
public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    Behaviour[] componentsToDisable;

    void Start()
    {
        // rename the Local Player
        if (isLocalPlayer)
        {
            transform.name = "playerLocal";
        }
    }
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void OnDisable()
    {
        Player _player = GetComponent<Player>();
        Debug.Log("remove");
        GameManager.singleton.UnRegisterPlayer(_player.ID);

    }

    public override void OnStartClient()
    {
        base.OnStartClient();
        string _netID = GetComponent<NetworkIdentity>().netId.ToString();
        Player _player = GetComponent<Player>();
        GameManager.singleton.RegisterPlayer(_player);

        //assigne to the local player his name and ID
        _player.ID = _netID;
        if (isLocalPlayer)
        {
            string namePlayer = GameObject.Find("NetworkManager").GetComponent<HostGame>().playerName;
            CmdSendInfoPlayer(_netID, namePlayer);
        }
        CmdGetRoleForPlayer(); 
        CmdSendActualGameManager(); 
    }

    #region getGameManager Fonction
    [Command]
    public void CmdSendActualGameManager()
    {
        RpcGetActualGameManager(GetbyteGameManager(GameManager.singleton.game));
        Debug.Log("try to send Game to players");

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
        Game _gameReceived = ByteArrayToObject(bytes);
        GameManager.singleton.game = _gameReceived;
        Debug.Log("Received Game from Server");
        GameObject.Find("PlayerViewManager").GetComponent<FillPlayerView>().isAlreadyUpdated = false;
    }
    #endregion


    #region DistribRole
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
        if (player.role != null)
        {
            return;
        }
        player.role = (Role)ByteArrayToObject2(arrByte);
    }

    #endregion


    #region SendInfoOfPlayer   CmdSendInfoPlayer(string id, string namePlayer)  RpcGetInfoOfPlayer(string _id, string _namePlayer)

    [Command]
    public void CmdSendInfoPlayer(string id, string namePlayer)
    {
        GameManager gameManager = GameManager.singleton;
        for (int i = 0; i < gameManager.players.Count; i++)
        {
            if (gameManager.players[i].ID.Equals(id))
            {
                gameManager.players[i].namePlayer = namePlayer;
            }
        }
        //GameObject.Find("ListPlayerManager").GetComponent<FillListPlayer>().UpdateList();
    }
    #endregion

    [Command]
    public void CmdChangeBoolNextTurn(string _id)
    {
        Debug.Log("nextTurn fonction command");
        GameManager gameManager = GameManager.singleton;
        for (int i = 0; i < gameManager.players.Count; i++)
        {
            Debug.Log("nextTurn Boucle " + i);
            if (gameManager.players[i].ID.Equals(_id))
            {
                Debug.Log("nextTurn Boucle " + i + " Trouvé" );
                gameManager.players[i].nextTurn = !gameManager.players[i].nextTurn;
            }
        }
    }



    #region Fonction Serialization      GetbyteFromObject()    ByteArrayToObject2()
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
    #endregion
}

