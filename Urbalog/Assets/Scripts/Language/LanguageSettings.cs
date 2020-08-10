using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSettings : MonoBehaviour
{
    #region main menu
    public TextMeshProUGUI BuildingsMenuButton;
    public TextMeshProUGUI RolesMenuButton;
    public TextMeshProUGUI TimeMenuButton;
    public TextMeshProUGUI DataBaseMenuButton;
    #endregion

    #region timer settings

    public TextMeshProUGUI TurnTimeLimitText;
    public Text TurnTimeLimitToggle;

    public TextMeshProUGUI GameTimeLimitText;
    public Text GameTimeLimitToggle;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        FillMainMenu();
        FillTimerMenu();
    }

    private void FillTimerMenu()
    {
        TurnTimeLimitText.text = Language.TURN_TIMER_TEXT;
        GameTimeLimitText.text = Language.GAME_TIMER_TEXT;

        TurnTimeLimitToggle.text = Language.TURN_TIMER_TOGGLE;
        GameTimeLimitToggle.text = Language.GAME_TIMER_TOGGLE;
    }

    private void FillMainMenu()
    {

        BuildingsMenuButton.text = Language.BUILDING_MENU_BUTTON;
        RolesMenuButton.text = Language.ROLES_MENU_BUTTON;
        TimeMenuButton.text = Language.TIME_MENU_BUTTON;
        DataBaseMenuButton.text = Language.DATABASE_MENU_BUTTON;
    }

}
