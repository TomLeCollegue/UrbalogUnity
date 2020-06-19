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
    public string ID;


    [SyncVar]
    public bool nextTurn = false;

    [SerializeField]
    private int num;

    
}
