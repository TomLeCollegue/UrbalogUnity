using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RenameBuilding : NetworkBehaviour
{
    public TextMeshProUGUI BuildingName;

    [SyncVar]
    public string NameBuilding;

    private void Start()
    {
        BuildingName.text = NameBuilding;
    }

    public void Rename(string Name)
    {
        NameBuilding = Name;
        BuildingName.text = NameBuilding;
    }
}
