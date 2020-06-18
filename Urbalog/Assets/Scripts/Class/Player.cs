using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

[Serializable]
public class Player : NetworkBehaviour
{
    public Role role { get; set; }

    [SerializeField]
    [SyncVar]
    public string namePlayer = "nom";
    public string ID { get; set; }


    [SyncVar]
    public bool nextTurn = false;

    [SerializeField]
    private int num;

    /// <summary>
    /// test function which seems deprecated
    /// TODO: delete this method
    /// </summary>
    [Command]
    public void CmdChangeNum()
    {
        RpcChangeNum();
    }

    /// <summary>
    /// test function which seems deprecated
    /// TODO: delete this method
    /// </summary>
    [ClientRpc]
    public void RpcChangeNum()
    {
        GameManager.singleton.ChangeValueNum();
        num++;
    }
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
