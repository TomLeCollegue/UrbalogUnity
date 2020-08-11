using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    public static float TurnTimeMax;
    public static bool isTimerActive;
    public static int nbBuildingsPerTurn;
    public static string Language = "Fr";
    public static bool Warmup = false;

    public static bool ServeurNonPlayer = false;
    public static bool CentralTablet = false;

    public static float GameTimerMax;
    public static bool isGameTimerActive;

    

    public void ChangeTimePerTurn(string _time)
    {
        //NextTurnButton.NumberBuildingsToEnd = Convert.ToInt16(_NumBuilding);
        TurnTimeMax = Convert.ToInt16(_time);
        PlayerPrefs.SetFloat("TurnTimeMax", TurnTimeMax);
        Debug.Log("Test de la save du timer de tour : " + PlayerPrefs.GetFloat("TurnTimeMax"));
    }

    public void ToggleTurnTimer(bool _isTimerActive)
    {
        isTimerActive = _isTimerActive;
        int _boolInt = isTimerActive ? 1 : 0;
        PlayerPrefs.SetInt("isTimerActive", _boolInt);
        //Debug.Log("Test du toggle du timer : " + (PlayerPrefs.GetInt("isTimerActive") == 1));
        Debug.Log("Test du toggle du timer : " + isTimerActive);
    }

    /// <summary>
    /// TODO: checks if it's ok to use playerpref like that
    /// </summary>
    /// <param name="_isGameTimerActive"></param>
    public void ToggleGameTimer(bool _isGameTimerActive)
    {
        isGameTimerActive = _isGameTimerActive;
        int _boolint = isGameTimerActive ? 1 : 0;
        PlayerPrefs.SetInt("isGameTimerActive", _boolint);
        //Debug.Log("Test du toggle du timer : " + (PlayerPrefs.GetInt("isGameTimerActive") == 1));
        Debug.Log("Test du toggle du timer : " + isGameTimerActive);
    }

    /// <summary>
    /// Change game timer value to the one in the input field and saves it in player pref
    /// </summary>
    /// <param name="_gameTime"></param>
    public void ChangeGameTimer(string _gameTime)
    {
        GameTimerMax = Convert.ToInt16(_gameTime) * 60; //*60 so the input works in minutes, not in seconds
        PlayerPrefs.SetFloat("GameTimerMax", GameTimerMax);
        Debug.Log("Test de la save du timer : " + PlayerPrefs.GetFloat("GameTimerMax"));

    }

    public void ToggleServeur(bool _isSeveurJoueur)
    {
        ServeurNonPlayer = _isSeveurJoueur;
        int boolInt = ServeurNonPlayer ? 1 : 0;
        PlayerPrefs.SetInt("ServeurNonPlayer", boolInt);
    }
    public void ToggleTabletteCentral(bool _isTabletCentral)
    {
        ServeurNonPlayer = _isTabletCentral;
        CentralTablet = _isTabletCentral;
        int boolInt = _isTabletCentral ? 1 : 0;
        if (!ServeurNonPlayer && CentralTablet)
        {
            PlayerPrefs.SetInt("ServeurNonPlayer", boolInt);
        }
        PlayerPrefs.SetInt("CentralTablet", boolInt);

    }

    public void ChangerNbBuildingsMaxPerTurn(string _nbMax)
    {
        nbBuildingsPerTurn = Convert.ToInt16(_nbMax);
        PlayerPrefs.SetInt("nbBuildingperTurn", nbBuildingsPerTurn);

    }

    public void ChangeLanguage(string _language)
    {
        Language = _language;
    }


    public void Start()
    {
        TurnTimeMax = PlayerPrefs.GetFloat("TurnTimeMax");
        isTimerActive = PlayerPrefs.GetInt("isTimerActive") == 1;
        nbBuildingsPerTurn = PlayerPrefs.GetInt("nbBuildingperTurn");
        NextTurnButton.NumberBuildingsToEnd = PlayerPrefs.GetInt("BuildingsToEnd");
        GameTimerMax = PlayerPrefs.GetFloat("GameTimerMax");
        isGameTimerActive = PlayerPrefs.GetInt("isGameTimerActive") == 1;
        ServeurNonPlayer = (PlayerPrefs.GetInt("ServeurNonPlayer") == 1) || (PlayerPrefs.GetInt("CentralTablet") == 1);
        CentralTablet = PlayerPrefs.GetInt("CentralTablet") == 1;
    }

    private void Update()
    {
        ServeurNonPlayer = (PlayerPrefs.GetInt("ServeurNonPlayer") == 1) || (PlayerPrefs.GetInt("CentralTablet") == 1);
    }

    public void InitWarmUP()
    {
        TurnTimeMax = 90f;
        isTimerActive = true;
        nbBuildingsPerTurn = 1;
        NextTurnButton.NumberBuildingsToEnd = 2;
        Warmup = true;
    }
}
