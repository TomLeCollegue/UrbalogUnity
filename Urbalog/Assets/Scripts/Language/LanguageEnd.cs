using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LanguageEnd : MonoBehaviour
{
    public TextMeshProUGUI Score_player;
    public TextMeshProUGUI Score_city;
    public TextMeshProUGUI titleCity;

    public TextMeshProUGUI Bravo;
    public TextMeshProUGUI TextPopUpWin;
    public TextMeshProUGUI TextPopUpLose;
    public TextMeshProUGUI Dommage;
    // Start is called before the first frame update

    private void Start()
    {
        FillCity();
        PopUp();
    }
    public void FillCity()
    {
        Score_player.text = Language.SCORE_PLAYER;
        Score_city.text = Language.SCORE_CITY;
        titleCity.text = Language.END_GAME_TITLE;
    }

    public void PopUp()
    {
        Bravo.text = Language.BRAVO;
        Dommage.text = Language.DOMMAGE;
        TextPopUpWin.text = Language.TEXT_WIN;
        TextPopUpLose.text = Language.TEXT_LOSE;
    }

}
