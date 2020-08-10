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
        //assign to the local player his name and ID
        if(_player.role == null) 
        {
            _player.ID = _netID;
        }
      
        if (isLocalPlayer)
        {
            Debug.Log("OnstartClinetFonction IsLocalPlayer");
            string namePlayer = GameObject.Find("NetworkManager").GetComponent<HostGame>().playerName;
            string age = GameObject.Find("NetworkManager").GetComponent<HostGame>().age;
            string company = GameObject.Find("NetworkManager").GetComponent<HostGame>().company;
            string gender = GameObject.Find("NetworkManager").GetComponent<HostGame>().gender;
            string playerFamilyName = GameObject.Find("NetworkManager").GetComponent<HostGame>().playerFamilyName;
            string zipcode = GameObject.Find("NetworkManager").GetComponent<HostGame>().zipcode;
            string jobStatus = GameObject.Find("NetworkManager").GetComponent<HostGame>().jobStatus;
            string field = GameObject.Find("NetworkManager").GetComponent<HostGame>().field;
            CmdSendInfoPlayer(_netID, namePlayer, age, company, gender, playerFamilyName, zipcode, jobStatus, field);


        }
        CmdSendRulesToPlayer();
        CmdSendNbBuildingsMax();
        CmdGetRoleForPlayer();
        CmdSendActualGameManager();
        if (isLocalPlayer)
        {
            Invoke("DelayCheckPlayerBackup", 2);
        }
    }

    void DelayCheckPlayerBackup()
    {
        CmdCheckifPlayerExisted(GameObject.Find("NetworkManager").GetComponent<HostGame>().playerName);
    }

    /// <summary>
    /// Sends to all players the number max of buildings they can build in a full game
    /// </summary>
    [Command]
    public void CmdSendNbBuildingsMax()
    {
        RpcGetNbBuildingsMax(NextTurnButton.NumberBuildingsToEnd);
    }

    /// <summary>
    /// each players take from server the number max of buildings they can build in a full game
    /// </summary>
    /// <param name="_numberBuildingsToEnd"></param>
    [ClientRpc]
    public void RpcGetNbBuildingsMax(int _numberBuildingsToEnd)
    {
        NextTurnButton.NumberBuildingsToEnd = _numberBuildingsToEnd;
    }

    /// <summary>
    /// Takes the turnTimeMax and isTimerActive in GameSettings.cs from server and sends it to all players
    /// </summary>
    [Command]
    public void CmdSendRulesToPlayer()
    {
        RpcGetRules(GameSettings.TurnTimeMax, GameSettings.isTimerActive, GameSettings.nbBuildingsPerTurn, GameSettings.CentralTablet, GameSettings.ServeurNonPlayer);
    }

    /// <summary>
    /// All the players take the gamesettings from the server
    /// </summary>
    /// <param name="_turnTimeMax"></param>
    /// <param name="_isTimerActive"></param>
    [ClientRpc]
    public void RpcGetRules(float _turnTimeMax, bool _isTimerActive, int _nbBuildingsPerTurn, bool TabletCentral, bool Serveur)
    {
        GameSettings.TurnTimeMax = _turnTimeMax;
        GameSettings.isTimerActive = _isTimerActive;
        GameSettings.nbBuildingsPerTurn = _nbBuildingsPerTurn;
        GameSettings.CentralTablet = TabletCentral;
        GameSettings.ServeurNonPlayer = Serveur;
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

        //resetTimer
        //TimerManager _timerManager = GameObject.Find("TimerManager").GetComponent<TimerManager>();
        //_timerManager.currentTurnTime = GameSettings.TurnTimeMax;
        //_timerManager.alreadyStarted = false;
    }
    #endregion




    #region DistribRole
    [Command]
    void CmdGetRoleForPlayer()
    {
        int numToSend = GameManager.singleton.NumPlayerForRole;

        Role role = GameManager.singleton.game.Roles[numToSend];
        GameManager.singleton.players[GameManager.singleton.players.Count - 1].nameRole = role.nameRole;
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
    public void CmdSendInfoPlayer(string id, string namePlayer, string age, string compagny, string gender, string playerFamilyName, string zipCode, string jobStatus, string field)
    {
        GameManager gameManager = GameManager.singleton;
        for (int i = 0; i < gameManager.players.Count; i++)
        {
            if (gameManager.players[i].ID.Equals(id))
            {
                gameManager.players[i].namePlayer = namePlayer;
                gameManager.players[i].age = age;
                gameManager.players[i].company = compagny;
                gameManager.players[i].gender = gender;
                gameManager.players[i].playerFamilyName = playerFamilyName;
                gameManager.players[i].zipcode = zipCode;
                gameManager.players[i].jobStatus = jobStatus;
                gameManager.players[i].field = field;
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
                Debug.Log("nextTurn Boucle " + i + " Trouvé");
                gameManager.players[i].nextTurn = !gameManager.players[i].nextTurn;
            }
        }
    }


    #region RecupPlayerIfReco
    [Command]
    public void CmdCheckifPlayerExisted(string namePlayer)
    {
        for (int i = 0; i < GameManager.singleton.playersBackup.Count; i++)
        {
            if (GameManager.singleton.playersBackup[i].namePlayer.Equals(namePlayer, StringComparison.OrdinalIgnoreCase))
            {

                byte[] playerBackupByte = GetbyteFromObject(GameManager.singleton.playersBackup[i]);
                RpcClient(playerBackupByte, namePlayer);
                return;
            }
        }


    }

    [ClientRpc]
    public void RpcClient(byte[] playerBackupByte, string namePlayer)
    {
        Debug.Log("Distribue le role et les infos RPC");
        PlayerBackUp playerBackup = (PlayerBackUp)ByteArrayToObject2(playerBackupByte);
        Debug.Log("Distribue le role et les infos bYTETOarray");
        if (GetComponent<Player>().namePlayer.Equals(namePlayer, StringComparison.OrdinalIgnoreCase))
        {
            Debug.Log("Distribue le role et les infos");
            Player player = GetComponent<Player>();
        
            player.namePlayer = playerBackup.namePlayer;
            player.playerFamilyName = playerBackup.playerFamilyName;
            player.gender = playerBackup.gender;
            player.age = playerBackup.age;
            player.zipcode = playerBackup.company;
            player.jobStatus = playerBackup.jobStatus;
            player.field = playerBackup.field;
            player.nameRole = playerBackup.nameRole;
            //player.ID = playerBackup.ID;
            player.nextTurn = playerBackup.nextTurn;
            player.scorePlayer = playerBackup.scorePlayer;
            player.OldScore = playerBackup.OldScore;
            player.num = playerBackup.num;
            player.role = playerBackup.role;
            player.playerBets = playerBackup.playerBets;
            BetControl betControl = GetComponent<BetControl>();
            betControl.playerBets = playerBackup.playerBets;

        }

        
    }
    #endregion


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

