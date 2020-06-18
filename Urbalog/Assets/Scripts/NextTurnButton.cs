using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NextTurnButton : MonoBehaviour
{
    public GameObject Panel;

    public TextMeshProUGUI turnNumberText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Goes in BetControl so the city score is updated for all players
    /// </summary>
    public void UpdateCityScore()
    {
        BetControl _betControl = GameObject.Find("playerLocal").GetComponent<BetControl>();
        _betControl.CmdUpdateCityScore();
    }

    /// <summary>
    /// When NextTurn button is clicked, the cityScorePanel is closed
    /// </summary>
    public void CloseCityScorePanel()
    {
        Panel.SetActive(false);
    }

    /// <summary>
    /// Each turn, the turn number update on the playerView scene
    /// </summary>
    public void UpdateTurnNumber()
    {
        Game _game = GameManager.singleton.game;

        turnNumberText.text = "N° Tour : " + _game.turnNumber.ToString();
    }




}
