﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LanguageLobby : MonoBehaviour
{
    public TextMeshProUGUI List_Player;
    public Text Begin_Party;
    
    void Start()
    {
        List_Player.text = Language.LIST_PLAYER;
        Begin_Party.text = Language.BEGIN_PARTY;
    }
}
