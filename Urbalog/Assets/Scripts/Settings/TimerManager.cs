using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public float currentTurnTime = GameSettings.TurnTimeMax;
    public float turnTimeMax = GameSettings.TurnTimeMax;

    public float currentGameTime = GameSettings.GameTimerMax;
    public float GameTimeMax = GameSettings.GameTimerMax;

    public bool alreadyStarted = false;
    public bool gameTimeAlreadyStarted = false;

    public TextMeshProUGUI turnTimerText;
    public TextMeshProUGUI GameTimerText;

    public GameObject endGameFromGameTimerPanel;

    public GameObject warningForGameTimerPanel;
    public TextMeshProUGUI warningForGameTimerText;

    /// <summary>
    /// Starts the turn timer
    /// </summary>
    public void StartTimer()
    {
        if (!alreadyStarted)
        {
            currentTurnTime = GameSettings.TurnTimeMax;
            alreadyStarted = true;
        }
    }

    /// <summary>
    /// Starts the game timer
    /// </summary>
    public void StartGameTimer()
    {
        if (!gameTimeAlreadyStarted)
        {
            currentGameTime = GameSettings.GameTimerMax;
            //currentGameTime = 15; //TODO: Comment this line
            gameTimeAlreadyStarted = true;
        }
    }

    /// <summary>
    /// Decrease the time for Turn timer
    /// </summary>
    public void DecreaseTime()
    {
        currentTurnTime -= 1 * Time.deltaTime;

        if (currentTurnTime <= 0)
        {
            currentTurnTime = 0;
        }
    }

    /// <summary>
    /// Decrease the time for Game Timer
    /// </summary>
    public void DecreaseGameTimer()
    {
        currentGameTime -= 1 * Time.deltaTime;

        if (currentGameTime <= 0)
        {
            currentGameTime = 0;
        }
    }


    private void Awake()
    {
        if (GameSettings.isTimerActive)
        {
            currentTurnTime = GameSettings.TurnTimeMax;
        }
        if (GameSettings.isGameTimerActive)
        {
            currentGameTime = GameSettings.GameTimerMax;
        }
    }

    private void Update()
    {
        //updating turn timer text
        if (alreadyStarted && GameSettings.isTimerActive)
        {
            DecreaseTime();
            turnTimerText.text = Language.TIMER_TURN +currentTurnTime.ToString("0");
        }
        else
        {
            turnTimerText.text = "";
        }

        //updating game timer text
        if (gameTimeAlreadyStarted && GameSettings.isGameTimerActive)
        {
            DecreaseGameTimer();
            DisplayGameTimer(GameTimerText);

            if (currentGameTime > 299 && currentGameTime < 301) //sets when the timer warning pops up
            {
                DisplayPopUpTimerWarning(5);
            }

            if (currentGameTime > 59 && currentGameTime < 61) //sets when the timer warning pops up
            {
                DisplayPopUpTimerWarning(1);
            }


            if (currentGameTime <= 0)
            {
                //Ces deux lignes commandent la fin de la partie.
                DisplayPopUpEndGameFromTimer();
                GameObject.Find("TurnManager").GetComponent<NextTurnButton>().CmdChangeSceneToEndGame();
                GameObject.Find("TurnManager").GetComponent<NextTurnButton>().EndGameLog();
            }
        }
        else
        {
            GameTimerText.text = "";
        }

        //Applying stuff on turn timer text
        if (currentTurnTime <= 20f)
        {
            turnTimerText.color = Color.red;
        }
        else
        {
            turnTimerText.color = Color.black;
        }
    }

    /// <summary>
    /// Display a pop up for when a certain threshold in timer is reached.
    /// TODO: Faire le panel en question
    /// </summary>
    private void DisplayPopUpTimerWarning(int _intNumberToPrint)
    {
        if (warningForGameTimerPanel != null)
        {
            warningForGameTimerPanel.SetActive(true);
            warningForGameTimerText.text = Language.GAME_TIMER_WARNING_POPUP_TEXT_1 + _intNumberToPrint.ToString() + 
                Language.GAME_TIMER_WARNING_POPUP_TEXT_2;
        }
    }

    /// <summary>
    /// For the cross button in the warning timer panel
    /// </summary>
    public void CloseTimerWarningPopUp()
    {
        if (warningForGameTimerPanel != null)
        {
            warningForGameTimerPanel.SetActive(false);
        }
    }

    /// <summary>
    /// Display a pop up when the game timer hits 0 to explain that the game is over because of the timer
    /// </summary>
    private void DisplayPopUpEndGameFromTimer()
    {
        if (endGameFromGameTimerPanel != null)
        {
            endGameFromGameTimerPanel.SetActive(true);
        }
    }

    /// <summary>
    /// Closes the pop up timer.
    /// </summary>
    public void CloseEndGamePopUpTimer()
    {
        if (endGameFromGameTimerPanel != null)
        {
            endGameFromGameTimerPanel.SetActive(false);
        }
    }

    /// <summary>
    /// Displays the game timer on the role card in a hh:mm:ss format
    /// </summary>
    private void DisplayGameTimer(TextMeshProUGUI _TMPro)
    {
        _TMPro.text = GameTimerToString(currentGameTime);
    }

    /// <summary>
    /// takes a float and puts it into a displayable string
    /// </summary>
    /// <param name="_currentTime"></param>
    /// <returns></returns>
    private string GameTimerToString(float _currentTime)
    {
        int _GameTimeInt = Convert.ToInt32(_currentTime);

        int _hhInt = (_GameTimeInt / 3600);
        int _mnInt = (_GameTimeInt / 60) % 60;
        int _ssInt = (_GameTimeInt % 60);

        string _hh = _hhInt.ToString("00");
        string _mn = _mnInt.ToString("00");
        string _ss = _ssInt.ToString("00");

        string _result;

        if (_hhInt <= 0)
        {
            _result = _mn + ":" + _ss;
        }
        else
        {
            _result = _hh + ":" + _mn + ":" + _ss;
        }

        return _result;
    }

}
