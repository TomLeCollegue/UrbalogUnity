using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static float TurnTimeMax;
    public static bool isTimerActive;
    public static int nbBuildingsPerTurn;
    public static string Language;
    public static bool Warmup = false;

    public void ChangeTimePerTurn(string _time)
    {
        //NextTurnButton.NumberBuildingsToEnd = Convert.ToInt16(_NumBuilding);
        TurnTimeMax = Convert.ToInt16(_time);
        PlayerPrefs.SetFloat("TurnTimeMax", TurnTimeMax);
    }

    public void ToggleTimer(bool _isTimerActive)
    {
        isTimerActive = _isTimerActive;
        int boolInt = isTimerActive ? 1 : 0;
        PlayerPrefs.SetInt("isTimerActive", boolInt);
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
