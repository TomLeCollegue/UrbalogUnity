using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LanguageMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject PlayerMenu;
    public GameObject AdminMenu;

    public TextMeshProUGUI Joueur;
    public TextMeshProUGUI Admin;

    public TextMeshProUGUI Join_Game_Text;
    public TextMeshProUGUI Join_Game_Button;
    public TextMeshProUGUI Serveurs;

    public TextMeshProUGUI Host_a_Game;
    public TextMeshProUGUI CreateGame;
    public TextMeshProUGUI Pseudo;

    void Update()
    {
        if (MainMenu.activeSelf)
        {
            FillTextMainMenu();
        }
        if (PlayerMenu.activeSelf)
        {
            FillTextPlayer();
        }
        if (AdminMenu.activeSelf)
        {
            FillTextAdmin();
        }
    }

    void FillTextMainMenu()
    {
        Joueur.text = Language.JOUEUR;
        Admin.text = Language.ADMIN;
    }

    void FillTextPlayer()
    {
        Join_Game_Text.text = Language.JOIN_GAME;
        Join_Game_Button.text = Language.JOIN_GAME;
        Serveurs.text = Language.SERVEURS;
    }


    void FillTextAdmin()
    {
        Host_a_Game.text = Language.HOST_GAME;
        CreateGame.text = Language.CREATE_GAME;
        Pseudo.text = Language.PSEUDO;
    }


    public void ChangeLanguage(string lang)
    {
        if (lang.Equals("Fr"))
        {
            Language.ChangeLanguage("Fr");
            
        }
        if (lang.Equals("En"))
        {
            Language.ChangeLanguage("En");
        }
        else
        {
            return;
        }
    }
}
