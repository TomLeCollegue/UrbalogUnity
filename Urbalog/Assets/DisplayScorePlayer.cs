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
    public Sprite DefaultPic;

    private void Update()
    {
        int boucle = 0;
        if (GameSettings.ServeurNonPlayer)
        {
            boucle = 1;
        }
        if (GameSettings.CentralTablet)
        {
            boucle = 2;
        }

        if (!SceneManager.GetActiveScene().name.Equals("EndGame"))
        {
        TurnNumber.text = Language.TURNS + GameManager.singleton.game.turnNumber;
        }
        Debug.Log("DisplayScore");
        List<Player> Players = GameManager.singleton.players;
        TextScore1.text = Players[0 + boucle].scorePlayer.ToString();
        Debug.Log("DisplayScore2");
        ImageScore1.GetComponent<Image>().sprite = GetInfoPlayer(Players[0 + boucle]);
        TextScore2.text = Players[1 + boucle].scorePlayer.ToString();
        ImageScore2.GetComponent<Image>().sprite = GetInfoPlayer(Players[1 + boucle]);

        TextScore3.text = Players[2 + boucle].scorePlayer.ToString();
        ImageScore3.GetComponent<Image>().sprite = GetInfoPlayer(Players[2 + boucle]);

        TextScore4.text = Players[3 + boucle].scorePlayer.ToString();
        ImageScore4.GetComponent<Image>().sprite = GetInfoPlayer(Players[3 + boucle]);

        TextScore5.text = Players[4 + boucle].scorePlayer.ToString();
        ImageScore5.GetComponent<Image>().sprite = GetInfoPlayer(Players[4 + boucle]);
        
    }

    private Sprite GetInfoPlayer(Player player)
    {
        if (player.role.roleForSprite.Equals("Habitant"))
        {
            return Habitant;
        }
        else if (player.role.roleForSprite.Equals("Transporteur"))
        {
            return Transporteur;
        }
        else if (player.role.roleForSprite.Equals("Commerçant"))
        {
            return Commercant;
        }
        else if (player.role.roleForSprite.Equals("Collectivité locale"))
        {
            return Mairie;
        }
        else if (player.role.roleForSprite.Equals("Opérateur de transport public"))
        {
            return TransporteurPublic;
        }
        else
        {
            return DefaultPic;
        }

    }
}
