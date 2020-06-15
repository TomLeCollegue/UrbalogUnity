using Mirror;
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


    public override void OnStartClient()
    {
        base.OnStartClient();
        string _netID = GetComponent<NetworkIdentity>().netId.ToString();
        Player _player = GetComponent<Player>();
        _player.ID = _netID;
        GameManager.singleton.RegisterPlayer(_player);

        CmdSendActualGameManager();


    }

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

 

    private void OnDisable()
    {
        Player _player = GetComponent<Player>();
        Debug.Log("remove");
        GameManager.singleton.UnRegisterPlayer(_player.ID);
       
    }
}
