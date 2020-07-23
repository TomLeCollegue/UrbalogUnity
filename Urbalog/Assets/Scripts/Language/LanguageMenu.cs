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

    public TextMeshProUGUI Previous1;
    public TextMeshProUGUI Previous2;
    public TextMeshProUGUI Previous3;
    public TextMeshProUGUI Next1;
    public TextMeshProUGUI Next2;
    public TextMeshProUGUI Next3;
    public TextMeshProUGUI Pass;
    public TextMeshProUGUI nameForm;
    public TextMeshProUGUI firstname;
    public TextMeshProUGUI gender;
    public TextMeshProUGUI age;
    public TextMeshProUGUI residence;
    public TextMeshProUGUI compagny;
    public TextMeshProUGUI status;
    public TextMeshProUGUI activity;

    void FillForm()
    {
        Previous1.text = Language.PREVIOUS;
        Previous2.text = Language.PREVIOUS;
        Previous3.text = Language.PREVIOUS ;
        Next1.text = Language.NEXT ;
        Next2.text = Language.NEXT ;
        Next3.text = Language.NEXT ;
        Pass.text = Language.PASS ;
        nameForm.text = Language.NAME ;
        firstname.text = Language.FIRSTNAME ;
        gender.text = Language.SEXE ;
        age.text = Language.AGE ;
        residence.text = Language.PLACE_RESIDENCE ;
        compagny.text = Language.COMPAGNY ;
        status.text = Language.ACT_STATUS ;
        activity.text = Language.ACTIVITY ;
    }
    


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
        FillForm();
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
