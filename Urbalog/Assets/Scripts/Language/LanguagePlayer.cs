using JetBrains.Annotations;
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


}
