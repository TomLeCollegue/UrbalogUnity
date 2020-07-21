using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static float TurnTimeMax = 60f;

    public static bool isTimerActive = false;

    public static int nbBuildingsPerTurn = 2;

    public void ChangeTimePerTurn(string _time)
    {
        //NextTurnButton.NumberBuildingsToEnd = Convert.ToInt16(_NumBuilding);
        TurnTimeMax = Convert.ToInt16(_time);
    }

    public void ToggleTimer(bool _isTimerActive)
    {
        isTimerActive = _isTimerActive;
    }

    public void ChangerNbBuildingsMaxPerTurn(string _nbMax)
    {
        nbBuildingsPerTurn = Convert.ToInt16(_nbMax);
    }


}
