using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Language
{
    #region MainMenu
        public static string FR_JOUEUR = "JOUEUR";
        public static string EN_JOUEUR = "PLAYER";
    
        public static string FR_ADMIN = "ADMINISTRATEUR";
        public static string EN_ADMIN = "Administrator";

        public static string FR_JOIN_GAME = "Rejoindre une partie";
        public static string EN_JOIN_GAME = "Join a Game";

        public static string FR_SERVEURS = "Serveurs";
        public static string EN_SERVEURS = "Servers";

        public static string FR_HOST_GAME = "Héberger une partie";
        public static string EN_HOST_GAME = "Host a game";
    
        public static string FR_CREATE_GAME = "Créer la partie";
        public static string EN_CREATE_GAME = "Create the game";

        public static string FR_PSEUDO = "Votre pseudo";
        public static string EN_PSEUDO = "Your pseudo";
    #endregion
    #region PlayerView
        public static string FR_OBJECTIF = "OBJECTIF";
        public static string EN_OBJECTIVES = "OBJECTIVES";

        public static string FR_HOLD = "Maintenir";
        public static string EN_HOLD = "Hold";

        public static string FR_IMPROVE = "Améliorer";
        public static string EN_IMPROVE = "Improve";

        public static string FR_TEXT_OBJECTIVE = "Vous marquez un point quand ces deux conditions sont satisfaites";
        public static string EN_TEXT_OBJECTIVE = "You get a point when those two conditions are satisfied";

        public static string FR_CENTER_CITY = "Centre ville";
        public static string EN_CENTER_CITY = "City center";

        public static string FR_MARKET = "Marché";
        public static string EN_MARKET = "Market";

        public static string FR_RESOURCES = "Ressources";
        public static string EN_RESOURCES = "Resources";

        public static string FR_TURNS = "Tours : ";
        public static string EN_TURNS = "Turns : ";

        public static string FR_CITY = "La ville";
        public static string EN_CITY = "City";

        public static string FR_SCORE_PLAYER = "Score joueurs";
        public static string EN_SCORE_PLAYER = "PLAYERS SCORE";

        public static string FR_SCORE_CITY = "Score ville";
        public static string EN_SCORE_CITY = "City Score";

        public static string FR_ROLE = "Rôle";
        public static string EN_ROLE = "Role";

        public static string FR_NEXT_TURN = "Tour suivant";
        public static string EN_NEXT_TURN = "Next turn";

        public static string FR_ATTRACT = "Attractivité";
        public static string EN_ATTRACT = "Attractivity";

        public static string FR_ENVI = "Environnement";
        public static string EN_ENVI = "Environment";

        public static string FR_FLUID = "Fluidité";
        public static string EN_FLUID = "Fluidity";

    #endregion
    #region EndGame
        public static string FR_END_GAME_TITLE = "Bilan logistique de la ville";
        public static string EN_END_GAME_TITLE = "City's Logistic report";

        public static string FR_END = "Fin";
        public static string EN_END = "End";
    #endregion

    #region MainMenu
    public static string JOUEUR = "JOUEUR";
    public static string ADMIN = "ADMINISTRATEUR";
    public static string JOIN_GAME = "Rejoindre une partie";
    public static string SERVEURS = "Serveurs";
    public static string HOST_GAME = "Héberger une partie";
    public static string CREATE_GAME = "Créer la partie";
    public static string PSEUDO = "Votre pseudo";
    #endregion
    #region PlayerView
    public static string OBJECTIF = "OBJECTIF"; 
    public static string HOLD = "Maintenir";
    public static string IMPROVE = "Améliorer";
    public static string TEXT_OBJECTIVE = "Vous marquez un point quand ces deux conditions sont satisfaites";
    public static string CENTER_CITY = "Centre ville";
    public static string MARKET = "Marché";
    public static string RESOURCES = "Ressources";
    public static string TURNS = "Tours : ";
    public static string CITY = "La ville";
    public static string SCORE_PLAYER = "Score joueurs";
    public static string SCORE_CITY = "Score ville";
    public static string ROLE = "Rôle";
    public static string NEXT_TURN = "Tour suivant";
    public static string ATTRACT = "Attractivité";
    public static string ENVI = "Environnement";
    public static string FLUID = "Fluidité";
 
    #endregion
    #region EndGame
    public static string END_GAME_TITLE = "Bilan logistique de la ville";
    public static string END = "Fin";

    #endregion


    public void ChangeLanguage(string language)
    {
        if (language.Equals("French"))
        {
            JOUEUR = FR_JOUEUR;
            ADMIN = FR_ADMIN;
            JOIN_GAME = FR_JOIN_GAME;
            SERVEURS = FR_SERVEURS;
            HOST_GAME = FR_HOST_GAME;
            CREATE_GAME = FR_CREATE_GAME;
            PSEUDO = FR_PSEUDO;
            OBJECTIF = FR_OBJECTIF;
            HOLD = FR_HOLD;
            IMPROVE = FR_IMPROVE;
            TEXT_OBJECTIVE = FR_TEXT_OBJECTIVE;
            CENTER_CITY = FR_CENTER_CITY;
            MARKET = FR_MARKET;
            RESOURCES = FR_RESOURCES;
            TURNS = FR_TURNS;
            CITY = FR_CITY;
            SCORE_PLAYER = FR_SCORE_PLAYER;
            SCORE_CITY = FR_SCORE_CITY;
            ROLE = FR_ROLE;
            NEXT_TURN = FR_NEXT_TURN;
            ATTRACT = FR_ATTRACT;
            ENVI = FR_ENVI;
            FLUID = FR_FLUID;
            END_GAME_TITLE = FR_END_GAME_TITLE;
            END = FR_END;
        }
        if (language.Equals("English"))
        {
            JOUEUR = EN_JOUEUR;
            ADMIN = EN_ADMIN;
            JOIN_GAME = EN_JOIN_GAME;
            SERVEURS = EN_SERVEURS;
            HOST_GAME = EN_HOST_GAME;
            CREATE_GAME = EN_CREATE_GAME;
            PSEUDO = EN_PSEUDO;
            OBJECTIF = EN_OBJECTIVES;
            HOLD = EN_HOLD;
            IMPROVE = EN_IMPROVE;
            TEXT_OBJECTIVE = EN_TEXT_OBJECTIVE;
            CENTER_CITY = EN_CENTER_CITY;
            MARKET = EN_MARKET;
            RESOURCES = EN_RESOURCES;
            TURNS = EN_TURNS;
            CITY = EN_CITY;
            SCORE_PLAYER = EN_SCORE_PLAYER;
            SCORE_CITY = EN_SCORE_CITY;
            ROLE = EN_ROLE;
            NEXT_TURN = EN_NEXT_TURN;
            ATTRACT = EN_ATTRACT;
            ENVI = EN_ENVI;
            FLUID = EN_FLUID;
            END_GAME_TITLE = EN_END_GAME_TITLE;
            END = EN_END;


        }
    }
}
