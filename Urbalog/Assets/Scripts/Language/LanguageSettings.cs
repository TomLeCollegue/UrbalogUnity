using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSettings : MonoBehaviour
{
    [Space(10)]
    #region main menu
    public TextMeshProUGUI SettingsTitle;
    public TextMeshProUGUI BuildingsMenuButton;
    public TextMeshProUGUI RolesMenuButton;
    public TextMeshProUGUI TimeMenuButton;
    public TextMeshProUGUI ServerPlayerToggleText;
    public TextMeshProUGUI CentralTabletToggleText;
    public TextMeshProUGUI CentralTabletWarning;
    #endregion

    [Space(10)]
    #region buildings settings
    public TextMeshProUGUI BuildingsMenuTitle;
    public TextMeshProUGUI NbBuildingsToEndGameText;
    public TextMeshProUGUI ConfirmButton;
    public TextMeshProUGUI BuildingsListButton;
    public TextMeshProUGUI NbBuildingsPerTurnText;
    #endregion

    [Space(10)]
    #region timer settings
    public TextMeshProUGUI TurnTimeLimitText;
    public Text TurnTimeLimitToggle;

    public TextMeshProUGUI GameTimeLimitText;
    public Text GameTimeLimitToggle;
    #endregion

    [Space(10)]
    #region Role Settings
    public TextMeshProUGUI AddRoleButton;
    public TextMeshProUGUI ResetRolesButton;
    public TextMeshProUGUI DeleteRoleButton;
    public TextMeshProUGUI ApplyChangesRoleButton;
    public TextMeshProUGUI AddNewRoleInJSONButton;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        FillMainMenu();
        FillTimerMenu();
        FillBuildingsMenu();
        FillRoleMenu();
    }

    private void FillRoleMenu()
    {
        AddRoleButton.text = Language.ADD_ROLE_BUTTON;
        ResetRolesButton.text = Language.RESET_ROLES_BUTTON;
        DeleteRoleButton.text = Language.DELETE_ROLE_BUTTON;
        ApplyChangesRoleButton.text = Language.APPLY_CHANGES_ROLE_BUTTON;
        AddNewRoleInJSONButton.text = Language.ADD_ROLE_IN_JSON_BUTTON;
    }

    private void FillBuildingsMenu()
    {
        BuildingsMenuTitle.text = Language.BUILDING_MENU_BUTTON;   
        NbBuildingsToEndGameText.text = Language.BUILDINGSTOEND_TEXT;
        ConfirmButton.text = Language.CONFIRM_NBBUILDINGS_BUTTON;
        BuildingsListButton.text = Language.BUILDINGS_LIST_BUTTON;
        NbBuildingsPerTurnText.text = Language.BUILDINGSPERTURN_TEXT;
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
        SettingsTitle.text = Language.SETTINGS_TITLE;
        BuildingsMenuButton.text = Language.BUILDING_MENU_BUTTON;
        RolesMenuButton.text = Language.ROLES_MENU_BUTTON;
        TimeMenuButton.text = Language.TIME_MENU_BUTTON;
        ServerPlayerToggleText.text = Language.SERVER_TOGGLE_TEXT;
        CentralTabletToggleText.text = Language.CENTRAL_TABLET_TOGGLE;
        CentralTabletWarning.text = Language.CENTRAL_TABLET_WARNING;
    }

}
