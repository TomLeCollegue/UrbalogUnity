using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LanguageMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject PlayerMenu;
    public GameObject AdminMenu;

    public TextMeshProUGUI Joueur;
    public TextMeshProUGUI Admin;

    public TextMeshProUGUI Join_Game_Text;
    public TextMeshProUGUI Join_Game_Button;
    public TextMeshProUGUI Serveurs;

    public TextMeshProUGUI Host_a_Game;
    public TextMeshProUGUI CreateGame;
    public TextMeshProUGUI Pseudo;

    public TextMeshProUGUI Previous1;
    public TextMeshProUGUI Previous2;
    public TextMeshProUGUI Previous3;
    public TextMeshProUGUI Next1;
    public TextMeshProUGUI Next2;
    public TextMeshProUGUI Next3;
    public TextMeshProUGUI Pass;
    public TextMeshProUGUI nameForm;
    public TextMeshProUGUI firstname;
    public TextMeshProUGUI gender;
    public TextMeshProUGUI age;
    public TextMeshProUGUI residence;
    public TextMeshProUGUI company;
    public TextMeshProUGUI status;
    public TextMeshProUGUI activity;

    public TextMeshProUGUI WarmUpButton;

    //Form placeholder
    //p1
    public TextMeshProUGUI name_placeholder;
    public TextMeshProUGUI firstName_placeholder;
    //p2
    public TextMeshProUGUI place_residence_placeholder;
    public TextMeshProUGUI company_placeholder;

    //chose label for placeholders
    public TextMeshProUGUI choose_placeholder_label_gender;
    public TextMeshProUGUI choose_placeholder_label_age;
    public TextMeshProUGUI choose_placeholder_label_activity_status;
    public TextMeshProUGUI choose_placeholder_label_activity_field;

    public TMP_Dropdown genreDropdown;
    public TMP_Dropdown ageDropdown;
    public TMP_Dropdown activityStatusDropdown;
    public TMP_Dropdown activityFieldDropdown;

    void FillForm()
    {
        Previous1.text = Language.PREVIOUS;
        Previous2.text = Language.PREVIOUS;
        Previous3.text = Language.PREVIOUS ;
        Next1.text = Language.NEXT ;
        Next2.text = Language.NEXT ;
        Next3.text = Language.NEXT ;
        Pass.text = Language.PASS ;
        nameForm.text = Language.NAME ;
        firstname.text = Language.FIRSTNAME ;
        gender.text = Language.SEXE ;
        age.text = Language.AGE ;
        residence.text = Language.PLACE_RESIDENCE ;
        company.text = Language.COMPANY ;
        status.text = Language.ACT_STATUS ;
        activity.text = Language.ACTIVITY ;

        //Form Placeholder
        //p1
        name_placeholder.text = Language.NAME_PLACEHOLDER;
        firstName_placeholder.text = Language.FIRSTNAME_PLACEHOLDER;
        //p2
        place_residence_placeholder.text = Language.PLACE_RESIDENCE_PLACEHOLDER;
        company_placeholder.text = Language.COMPANY_PLACEHOLDER;

        FillDropdownGender();
        FillDropdownAge();
        FillDropdownActivityStatus();
        FillDropdownActivityField();

    }

    private void FillDropdownActivityField()
    {
        choose_placeholder_label_activity_field.text = Language.CHOOSE_DROPDOWN_LABEL;
        List<string> _activity_field_list = new List<string>
        {
            Language.CHOOSE_DROPDOWN,Language.ACTIVITY_FIELD_OPT1,Language.ACTIVITY_FIELD_OPT2,
            Language.ACTIVITY_FIELD_OPT3,Language.ACTIVITY_FIELD_OPT4,Language.ACTIVITY_FIELD_OPT5,
            Language.ACTIVITY_FIELD_OPT6,Language.ACTIVITY_FIELD_OPT7,Language.ACTIVITY_FIELD_OPT8,
            Language.ACTIVITY_FIELD_OPT9,Language.ACTIVITY_FIELD_OPT10,Language.ACTIVITY_FIELD_OPT11,
            Language.ACTIVITY_FIELD_OPT12,Language.ACTIVITY_FIELD_OPT13,Language.ACTIVITY_FIELD_OPT14
        };
        var _activity_field_dropdown = activityFieldDropdown.GetComponent<TMP_Dropdown>();
        _activity_field_dropdown.options.Clear();
        foreach (string _option in _activity_field_list)
        {
            _activity_field_dropdown.options.Add(new TMP_Dropdown.OptionData(_option));
        }
    }

    private void FillDropdownActivityStatus()
    {
        choose_placeholder_label_activity_status.text = Language.CHOOSE_DROPDOWN_LABEL;
        List<string> _activity_list = new List<string>
        {
            Language.CHOOSE_DROPDOWN,Language.ACTIVITY_STATUS_OPT1,
            Language.ACTIVITY_STATUS_OPT2,Language.ACTIVITY_STATUS_OPT3,
            Language.ACTIVITY_STATUS_OPT4,Language.ACTIVITY_STATUS_OPT5
        };
        var _activity_dropdown = activityStatusDropdown.GetComponent<TMP_Dropdown>();
        _activity_dropdown.options.Clear();
        foreach(string _option in _activity_list)
        {
            _activity_dropdown.options.Add(new TMP_Dropdown.OptionData(_option));
        }
    }

    private void FillDropdownAge()
    {
        // age dropdown
        //label
        choose_placeholder_label_age.text = Language.CHOOSE_DROPDOWN_LABEL;
        //options
        List<string> _age_list = new List<string> { Language.CHOOSE_DROPDOWN, Language.AGE_DROPDOWN_OPT1, Language.AGE_DROPDOWN_OPT2, Language.AGE_DROPDOWN_OPT3, Language.AGE_DROPDOWN_OPT4, Language.AGE_DROPDOWN_OPT5, Language.AGE_DROPDOWN_OPT6, Language.AGE_DROPDOWN_OPT7, Language.AGE_DROPDOWN_OPT8 };
        //var age_dropdown = GameObject.Find("AgeDropdownList").GetComponent<TMP_Dropdown>();
        var _age_dropdown = ageDropdown.GetComponent<TMP_Dropdown>();
        _age_dropdown.options.Clear();
        foreach (string _option in _age_list)
        {
            _age_dropdown.options.Add(new TMP_Dropdown.OptionData(_option));
        }
        
    }

    /// <summary>
    /// Fills the dropdowns in the form
    /// </summary>
    private void FillDropdownGender()
    {
        // gender dropdown
        //label
        choose_placeholder_label_gender.text = Language.CHOOSE_DROPDOWN_LABEL;
        //options
        List<string> gender_list = new List<string> { Language.CHOOSE_DROPDOWN, Language.GENDER_DROPDOWN_OPT1, Language.GENDER_DROPDOWN_OPT2, Language.GENDER_DROPDOWN_OPT3 };
        //var gender_dropdown = GameObject.Find("GenderDropdownList").GetComponent<TMP_Dropdown>();
        var gender_dropdown = genreDropdown.GetComponent<TMP_Dropdown>();
        gender_dropdown.options.Clear();
        foreach (string option in gender_list)
        {
            gender_dropdown.options.Add(new TMP_Dropdown.OptionData(option));
        }        
        
    }

    void Update()
    {
        if (MainMenu.activeSelf)
        {
            FillTextMainMenu();
        }
        if (PlayerMenu.activeSelf)
        {
            FillTextPlayer();
        }
        if (AdminMenu.activeSelf)
        {
            FillTextAdmin();
        }
        FillForm();
        
    }

    void FillTextMainMenu()
    {
        Joueur.text = Language.JOUEUR;
        Admin.text = Language.ADMIN;
    }

    void FillTextPlayer()
    {
        Join_Game_Text.text = Language.JOIN_GAME;
        Join_Game_Button.text = Language.JOIN_GAME;
        Serveurs.text = Language.SERVEURS;
    }


    void FillTextAdmin()
    {
        Host_a_Game.text = Language.HOST_GAME;
        CreateGame.text = Language.CREATE_GAME;
        Pseudo.text = Language.PSEUDO;
        WarmUpButton.text = Language.WARMUP_BUTTON ;
    }


    public void ChangeLanguage(string lang)
    {
        if (lang.Equals("Fr"))
        {
            Language.ChangeLanguage("Fr");
            
        }
        if (lang.Equals("En"))
        {
            Language.ChangeLanguage("En");
        }
        else
        {
            return;
        }
    }
}
