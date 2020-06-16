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
    public string namePlayer { get; set; }
    public string ID { get; set; }

    [SerializeField]
    private int num;

    [Command]
    public void CmdChangeNum()
    {
        RpcChangeNum();
    }

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
