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

    public TextMeshProUGUI AddBuildingButton;
    public TextMeshProUGUI ResetBuildingsButton;
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

    [Space(10)]
    #region Modify Role Panel
    public TextMeshProUGUI ModObjectiveTitle;
    
    public TextMeshProUGUI ModHoldTitle;
    public TextMeshProUGUI ModImproveTitle;

    public TextMeshProUGUI ModHoldAttractButton;
    public TextMeshProUGUI ModHoldEnviButton;
    public TextMeshProUGUI ModHoldFluidButton;    
    
    public TextMeshProUGUI ModImproveAttractButton;
    public TextMeshProUGUI ModImproveEnviButton;
    public TextMeshProUGUI ModImproveFluidButton;
    
    public TextMeshProUGUI ModResourceTitle;
    
    public TextMeshProUGUI ModPoliTitle;
    public TextMeshProUGUI ModEcoTitle;
    public TextMeshProUGUI ModSocialTitle;

    public TextMeshProUGUI ModResourceWarning;

    public TextMeshProUGUI ModDeleteRole;
    public TextMeshProUGUI ModApplyChangesRole;
    #endregion

    [Space(10)]
    #region Add Role Panel
    public TextMeshProUGUI AddObjectiveTitle;

    public TextMeshProUGUI AddHoldTitle;
    public TextMeshProUGUI AddImproveTitle;

    public TextMeshProUGUI AddHoldAttractButton;
    public TextMeshProUGUI AddHoldEnviButton;
    public TextMeshProUGUI AddHoldFluidButton;

    public TextMeshProUGUI AddImproveAttractButton;
    public TextMeshProUGUI AddImproveEnviButton;
    public TextMeshProUGUI AddImproveFluidButton;

    public TextMeshProUGUI AddResourceTitle;

    public TextMeshProUGUI AddPoliTitle;
    public TextMeshProUGUI AddEcoTitle;
    public TextMeshProUGUI AddSocialTitle;

    public TextMeshProUGUI AddResourceWarning;

    public TextMeshProUGUI AddRoleButtonValidate;
    #endregion

    [Space(10)]
    #region Modify Building Panel
    public TextMeshProUGUI MBDescriptionTitle;

    public TextMeshProUGUI MBCostTitle;

    public TextMeshProUGUI MBEcoTitle;
    public TextMeshProUGUI MBSocialTitle;
    public TextMeshProUGUI MBPoliticalTitle;

    public TextMeshProUGUI MBEffectTitle;

    public TextMeshProUGUI MBEnviTitle;
    public TextMeshProUGUI MBFluidTitle;
    public TextMeshProUGUI MBAttractTitle;
    public TextMeshProUGUI MBLogisticTitle;
    
    public TextMeshProUGUI MBLogisticDescription;

    public TextMeshProUGUI MBDelete;
    public TextMeshProUGUI MBApplyChanges;
    #endregion

    [Space(10)]
    #region Add Building Panel
    public TextMeshProUGUI ABDescriptionTitle;

    public TextMeshProUGUI ABCostTitle;

    public TextMeshProUGUI ABEcoTitle;
    public TextMeshProUGUI ABSocialTitle;
    public TextMeshProUGUI ABPoliticalTitle;

    public TextMeshProUGUI ABEffectTitle;

    public TextMeshProUGUI ABEnviTitle;
    public TextMeshProUGUI ABFluidTitle;
    public TextMeshProUGUI ABAttractTitle;
    public TextMeshProUGUI ABLogisticTitle;
    
    public TextMeshProUGUI ABLogisticDescription;

    public TextMeshProUGUI ABWarning; //Only ones to change in language
    public TextMeshProUGUI ABAddButton; //Only ones to change in language

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        FillMainMenu();
        FillTimerMenu();
        FillBuildingsMenu();
        FillRoleMenu();
        FillModifyRolePanel();
        FillAddRolePanel();
        FillModifyBuildingPanel();
        FillAddBuildingPanel();
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

        //In building List
        AddBuildingButton.text = Language.ADD_BUILDING_BUTTON;
        ResetBuildingsButton.text = Language.RESET_BUILDINGS_BUTTON;
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

    private void FillModifyRolePanel()
    {
        ModObjectiveTitle.text = Language.MOD_OBJ_TITLE;

        ModHoldTitle.text = Language.MOD_HOLD_TITLE;
        ModImproveTitle.text = Language.MOD_IMPROVE_TITLE;

        ModHoldAttractButton.text = Language.MOD_HOLD_ATTRACT_BUTTON;
        ModHoldEnviButton.text = Language.MOD_HOLD_ENVI_BUTTON;
        ModHoldFluidButton.text = Language.MOD_HOLD_FLUID_BUTTON;

        ModImproveAttractButton.text = Language.MOD_IMPROVE_ATTRACT_BUTTON;
        ModImproveEnviButton.text = Language.MOD_IMPROVE_ENVI_BUTTON;
        ModImproveFluidButton.text = Language.MOD_IMPROVE_FLUID_BUTTON;

        ModResourceTitle.text = Language.MOD_RESOURCE_TITLE;

        ModPoliTitle.text = Language.MOD_POLI_TITLE;
        ModEcoTitle.text = Language.MOD_ECO_TITLE;
        ModSocialTitle.text = Language.MOD_SOCIAL_TITLE;

        ModResourceWarning.text = Language.MOD_RES_WARNING;

        ModDeleteRole.text = Language.MOD_DELETE_ROLE;
        ModApplyChangesRole.text = Language.MOD_APPLY_CHANGES_ROLE;
    }

    private void FillAddRolePanel()
    {
        AddObjectiveTitle.text = Language.ADD_OBJ_TITLE;

        AddHoldTitle.text = Language.ADD_HOLD_TITLE;
        AddImproveTitle.text = Language.ADD_IMPROVE_TITLE;

        AddHoldAttractButton.text = Language.ADD_HOLD_ATTRACT_BUTTON;
        AddHoldEnviButton.text = Language.ADD_HOLD_ENVI_BUTTON;
        AddHoldFluidButton.text = Language.ADD_HOLD_FLUID_BUTTON;

        AddImproveAttractButton.text = Language.ADD_IMPROVE_ATTRACT_BUTTON;
        AddImproveEnviButton.text = Language.ADD_IMPROVE_ENVI_BUTTON;
        AddImproveFluidButton.text = Language.ADD_IMPROVE_FLUID_BUTTON;

        AddResourceTitle.text = Language.ADD_RESOURCE_TITLE;

        AddPoliTitle.text = Language.ADD_POLI_TITLE;
        AddEcoTitle.text = Language.ADD_ECO_TITLE;
        AddSocialTitle.text = Language.ADD_SOCIAL_TITLE;

        AddResourceWarning.text = Language.ADD_RES_WARNING;

        AddRoleButtonValidate.text = Language.ADD_ROLE_BUTTON_VALIDATE;
    }

    private void FillModifyBuildingPanel()
    {
        MBDescriptionTitle.text = Language.MB_DESCRIPTION_TITLE;

        MBCostTitle.text = Language.MB_COST_TITLE;

        MBEcoTitle.text = Language.MB_ECO_TITLE;
        MBSocialTitle.text = Language.MB_SOCIAL_TITLE;
        MBPoliticalTitle.text = Language.MB_POLI_TITLE;

        MBEffectTitle.text = Language.MB_EFFECT_TITLE;

        MBEnviTitle.text = Language.MB_ENVI_TITLE;
        MBFluidTitle.text = Language.MB_FLUID_TITLE;
        MBAttractTitle.text = Language.MB_ATTRACT_TITLE;
        MBLogisticTitle.text = Language.MB_LOGISTIC_TITLE;

        MBLogisticDescription.text = Language.MB_LOGISTIC_DESCRIPTION;

        MBDelete.text = Language.MB_DELETE;
        MBApplyChanges.text = Language.MB_APPLY_CHANGES;
    }

    private void FillAddBuildingPanel()
    {
        ABDescriptionTitle.text = Language.MB_DESCRIPTION_TITLE;

        ABCostTitle.text = Language.MB_COST_TITLE;

        ABEcoTitle.text = Language.MB_ECO_TITLE;
        ABSocialTitle.text = Language.MB_SOCIAL_TITLE;
        ABPoliticalTitle.text = Language.MB_POLI_TITLE;

        ABEffectTitle.text = Language.MB_EFFECT_TITLE;

        ABEnviTitle.text = Language.MB_ENVI_TITLE;
        ABFluidTitle.text = Language.MB_FLUID_TITLE;
        ABAttractTitle.text = Language.MB_ATTRACT_TITLE;
        ABLogisticTitle.text = Language.MB_LOGISTIC_TITLE;

        ABLogisticDescription.text = Language.MB_LOGISTIC_DESCRIPTION;

        ABWarning.text = Language.AB_WARNING;
        ABAddButton.text = Language.AB_ADD_BUTTON;
    }
}
