using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class displayPlayerName : MonoBehaviour 
{
    
    public GameObject player1;
    public TextMeshProUGUI player1text;

    public GameObject player2;
    public TextMeshProUGUI player2text;

    public GameObject player3;
    public TextMeshProUGUI player3text;

    public GameObject player4;
    public TextMeshProUGUI player4text;

    public GameObject player5;
    public TextMeshProUGUI player5text;


    // Update is called once per frame
    void Update()
    {
        player1text.text = GameManager.singleton.players[0].namePlayer;
        player2text.text = GameManager.singleton.players[1].namePlayer;
        player3text.text = GameManager.singleton.players[2].namePlayer;
        player4text.text = GameManager.singleton.players[3].namePlayer;
        player5text.text = GameManager.singleton.players[4].namePlayer;

    }

    private void Start()
    {
        player1.SetActive(false);
        player2.SetActive(false);
        player3.SetActive(false);
        player4.SetActive(false);
        player5.SetActive(false);
    }

    public void DisplayPlayer1()
    {
        player1.SetActive(true);
    }
    public void DisplayPlayer2()
    {
        player2.SetActive(true);
    }
    public void DisplayPlayer3()
    {
        player3.SetActive(true);
    }
    public void DisplayPlayer4()
    {
        player4.SetActive(true);
    }
    public void DisplayPlayer5()
    {
        player5.SetActive(true);
    }

    public void DismissPlayer1()
    {
        player1.SetActive(false);
    }
    public void DismissPlayer2()
    {
        player2.SetActive(false);
    }
    public void DismissPlayer3()
    {
        player3.SetActive(false);
    }
    public void DismissPlayer4()
    {
        player4.SetActive(false);
    }
    public void DismissPlayer5()
    {
        player5.SetActive(false);
    }




}
