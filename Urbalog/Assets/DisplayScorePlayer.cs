using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        int PlayerServeur = 0;
        if (!SceneManager.GetActiveScene().name.Equals("EndGame"))
        {
        TurnNumber.text = Language.TURNS + GameManager.singleton.game.turnNumber;
        }
        Debug.Log("DisplayScore");
        List<Player> Players = GameManager.singleton.players;
        TextScore1.text = Players[0 + PlayerServeur].scorePlayer.ToString();
        Debug.Log("DisplayScore2");
        ImageScore1.GetComponent<Image>().sprite = GetInfoPlayer(Players[0 + PlayerServeur]);
        TextScore2.text = Players[1 + PlayerServeur].scorePlayer.ToString();
        ImageScore2.GetComponent<Image>().sprite = GetInfoPlayer(Players[1 + PlayerServeur]);

        TextScore3.text = Players[2 + PlayerServeur].scorePlayer.ToString();
        ImageScore3.GetComponent<Image>().sprite = GetInfoPlayer(Players[2 + PlayerServeur]);

        TextScore4.text = Players[3 + PlayerServeur].scorePlayer.ToString();
        ImageScore4.GetComponent<Image>().sprite = GetInfoPlayer(Players[3 + PlayerServeur]);

        TextScore5.text = Players[4 + PlayerServeur].scorePlayer.ToString();
        ImageScore5.GetComponent<Image>().sprite = GetInfoPlayer(Players[4 + PlayerServeur]);
        
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
