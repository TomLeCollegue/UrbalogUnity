using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LanguagePlayer : MonoBehaviour
{
    public GameObject Role;
    public TextMeshProUGUI Center_City;
    public TextMeshProUGUI Market;
    public TextMeshProUGUI Ressources_Text;
    public TextMeshProUGUI ObJective_text;
    public TextMeshProUGUI Hold;
    public TextMeshProUGUI Improve;
    public TextMeshProUGUI text_objectives;
    public TextMeshProUGUI turn;
    public TextMeshProUGUI time_left_text;
    
    public TextMeshProUGUI Score_player;
    public TextMeshProUGUI Score_city;
    public TextMeshProUGUI turn_city;
    public TextMeshProUGUI role_button;
    public TextMeshProUGUI next_turn_button_city;
    public TextMeshProUGUI titleCity;


    public TextMeshProUGUI role_button_market;
    public TextMeshProUGUI next_turn_button;
    public TextMeshProUGUI resources_market;
    public TextMeshProUGUI objectif_market;

    public TextMeshProUGUI envi;
    public TextMeshProUGUI fluid;
    public TextMeshProUGUI attract;


    public TextMeshProUGUI Bravo;
    public TextMeshProUGUI TextPopUpWin;
    public TextMeshProUGUI TextPopUpLose;
    public TextMeshProUGUI Dommage;

    //Game Timer PopUp
    public TextMeshProUGUI GameTimerWarningTitle;
    public TextMeshProUGUI GameTimerEndTitle;
    public TextMeshProUGUI GameTimerEndText;




    public void FillGameTimerPopUps()
    {
        GameTimerWarningTitle.text = Language.GAME_TIMER_WARNING_POPUP_TITLE;
        GameTimerEndTitle.text = Language.GAME_TIMER_END_POPUP_TITLE;
        GameTimerEndText.text = Language.GAME_TIMER_END_POPUP_TEXT;
    }

    public void FillMarket()
    {
        role_button_market.text = Language.ROLE;
        next_turn_button.text = Language.NEXT_TURN;
        resources_market.text = Language.RESOURCES;
        objectif_market.text = Language.OBJECTIF;
    }

    
    void Start()
    {
        FillRole();
        FillCity();
        FillMarket();
        FillPopUpBuilding();
        PopUp();
        FillGameTimerPopUps();
    }



    public void FillRole()
    {
        Center_City.text = Language.CENTER_CITY;
        Market.text = Language.MARKET;
        Ressources_Text.text = Language.RESOURCES;
        ObJective_text.text = Language.OBJECTIF;
        Hold.text = Language.HOLD;
        Improve.text = Language.IMPROVE;
        text_objectives.text = Language.TEXT_OBJECTIVE;
        turn.text = Language.TURNS + "0";
        time_left_text.text = Language.TIMER_TURN;
    }

    public void FillCity()
    {
        Score_player.text = Language.SCORE_PLAYER;
        Score_city.text = Language.SCORE_CITY;
        role_button.text = Language.ROLE;
        turn_city.text = Language.TURNS + GameManager.singleton.game.turnNumber;
        next_turn_button_city.text = Language.NEXT_TURN;
        titleCity.text = Language.CITY;
    }

    public void FillPopUpBuilding()
    {
        envi.text = Language.ENVI;
        fluid.text = Language.FLUID;
        attract.text = Language.ATTRACT;
    }

    public void PopUp()
    {
        Bravo.text = Language.BRAVO;
        Dommage.text = Language.DOMMAGE;
        TextPopUpWin.text = Language.TEXT_WIN;
        TextPopUpLose.text = Language.TEXT_LOSE;
    }

    public void ChangeCityTitle()
    {
        Debug.Log("ChangeCityTitle");
        titleCity.text = Language.END_WARMUP;
    }

}
