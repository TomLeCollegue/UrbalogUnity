﻿using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConnectionDisplayManager : MonoBehaviour
{
    Color urbaBlack = new Color(0.1764706f, 0.1686275f, 0.2470588f);
    Color urbaGreen = new Color(0.56f, 0.68f, 0.32f);
    public TextMeshProUGUI Table1;
    public TextMeshProUGUI Table2;
    public TextMeshProUGUI Table3;
    public TextMeshProUGUI Table4;
    public TextMeshProUGUI Table5;
    public Image Table1I;
    public Image Table2I;
    public Image Table3I;
    public Image Table4I;
    public Image Table5I;
    public Sprite BoutonSecondaire;
    public Sprite GreenBox;


    void Update()
    {
        Table1.color = urbaBlack;
        Table2.color = urbaBlack;
        Table3.color = urbaBlack;
        Table4.color = urbaBlack;
        Table5.color = urbaBlack;
        Table1I.GetComponent<Image>().sprite = BoutonSecondaire;
        Table2I.GetComponent<Image>().sprite = BoutonSecondaire;
        Table3I.GetComponent<Image>().sprite = BoutonSecondaire;
        Table4I.GetComponent<Image>().sprite = BoutonSecondaire;
        Table5I.GetComponent<Image>().sprite = BoutonSecondaire;

        uint port = GameObject.Find("NetworkManager").GetComponent<TelepathyTransport>().port;
        if(port == 7777)
        {
            Table1.color = urbaGreen;
            Table1I.GetComponent<Image>().sprite = GreenBox;
        }
        else if(port == 7778)
        {
            Table2I.GetComponent<Image>().sprite = GreenBox;
            Table2.color = urbaGreen;
        }
        else if (port == 7779)
        {
            Table3I.GetComponent<Image>().sprite = GreenBox;
            Table3.color = urbaGreen;
        }
        else if (port == 7776)
        {
            Table4I.GetComponent<Image>().sprite = GreenBox;
            Table4.color = urbaGreen;
        }
        else
        {
            Table5I.GetComponent<Image>().sprite = GreenBox;
            Table5.color = urbaGreen;
        }
    }
}
