using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static float TurnTimeMax = 60f;

    public static bool isTimerActive = false;

    public void ChangeTimePerTurn(string _time)
    {
        //NextTurnButton.NumberBuildingsToEnd = Convert.ToInt16(_NumBuilding);
        TurnTimeMax = Convert.ToInt16(_time);
    }

    public void ToggleTimer(bool _isTimerActive)
    {
        isTimerActive = _isTimerActive;
    }



}
