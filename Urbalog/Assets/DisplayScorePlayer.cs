using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScorePlayer : MonoBehaviour
{
    public TextMeshProUGUI TextScore1;
    public TextMeshProUGUI TextScore2;
    public TextMeshProUGUI TextScore3;
    public TextMeshProUGUI TextScore4;
    public TextMeshProUGUI TextScore5;
    public TextMeshProUGUI TurnNumber;
    

    public Image ImageScore1;
    public Image ImageScore2;
    public Image ImageScore3;
    public Image ImageScore4;
    public Image ImageScore5;

    public Sprite Commercant;
    public Sprite Transporteur;
    public Sprite TransporteurPublic;
    public Sprite Habitant;
    public Sprite Mairie;

    private void Update()
    {
        TurnNumber.text = "Tour : " + GameManager.singleton.game.turnNumber.ToString();
        Debug.Log("DisplayScore");
        List<Player> Players = GameManager.singleton.players;
        TextScore1.text = Players[0].scorePlayer.ToString();
        Debug.Log("DisplayScore2");
        ImageScore1.GetComponent<Image>().sprite = GetInfoPlayer(Players[0]);
        TextScore2.text = Players[1].scorePlayer.ToString();
        ImageScore2.GetComponent<Image>().sprite = GetInfoPlayer(Players[1]);

        TextScore3.text = Players[2].scorePlayer.ToString();
        ImageScore3.GetComponent<Image>().sprite = GetInfoPlayer(Players[2]);

        TextScore4.text = Players[3].scorePlayer.ToString();
        ImageScore4.GetComponent<Image>().sprite = GetInfoPlayer(Players[3]);

        TextScore5.text = Players[4].scorePlayer.ToString();
        ImageScore5.GetComponent<Image>().sprite = GetInfoPlayer(Players[4]);
    }

    private Sprite GetInfoPlayer(Player player)
    {
        if (player.nameRole.Equals("Habitant"))
        {
            return Habitant;
        }
        else if (player.nameRole.Equals("Transporteur"))
        {
            return Transporteur;
        }
        else if (player.nameRole.Equals("Commerçant"))
        {
            return Commercant;
        }
        else if (player.nameRole.Equals("Collectivité locale"))
        {
            return Mairie;
        }
        else if (player.nameRole.Equals("Opérateur de transport public"))
        {
            return TransporteurPublic;
        }
        else
        {
            return Mairie;
        }

    }
}
