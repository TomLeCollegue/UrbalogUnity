using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBegginParty : NetworkBehaviour
{
    public GameObject button;
    void Start()
    {
        Debug.Log("DisplayButton");

        if (!isServer)
        {
            button.SetActive(false);
            Debug.Log("NOTDisplayButton");
        }
    }

    
}
