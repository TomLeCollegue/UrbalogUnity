using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NamePlayerInList : MonoBehaviour
{
    public TextMeshProUGUI namePlayer;

    public void Rename(string _name)
    {
        namePlayer.text = _name;
    }

}
