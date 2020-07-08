using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public float currentTurnTime = 60f;
    public float turnTimeMax = 60f;

    public bool alreadyStarted = false;

    public TextMeshProUGUI turnTimerText;


    public void StartTimer()
    {
        if (!alreadyStarted)
        {
            currentTurnTime = turnTimeMax;
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
        currentTurnTime = 60f;
    }

    private void Update()
    {
        if (alreadyStarted)
        {
            DecreaseTime();
        }
        turnTimerText.text = currentTurnTime.ToString("0");
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
