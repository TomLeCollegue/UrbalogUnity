using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public float currentTurnTime = GameSettings.TurnTimeMax;
    public float turnTimeMax = GameSettings.TurnTimeMax;

    public bool alreadyStarted = false;

    public TextMeshProUGUI turnTimerText;


    public void StartTimer()
    {
        if (!alreadyStarted)
        {
            currentTurnTime = GameSettings.TurnTimeMax;
            alreadyStarted = true;
        }
    }

    public void DecreaseTime()
    {
        currentTurnTime -= 1 * Time.deltaTime;

        if (currentTurnTime <= 0)
        {
            currentTurnTime = 0;
        }
    }

    private void Awake()
    {
        if (GameSettings.isTimerActive)
        {
            currentTurnTime = GameSettings.TurnTimeMax;
        }
    }

    private void Update()
    {
        if (alreadyStarted && GameSettings.isTimerActive)
        {
            DecreaseTime();
            turnTimerText.text = "Temps : "+currentTurnTime.ToString("0");
        }
        else
        {
            turnTimerText.text = "";
        }
        if (currentTurnTime <= 20f)
        {
            turnTimerText.color = Color.red;
        }
        else
        {
            turnTimerText.color = Color.black;
        }
    }



}
