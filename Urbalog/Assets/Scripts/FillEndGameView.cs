using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FillEndGameView : MonoBehaviour
{
    public TextMeshProUGUI AttractCity;
    public TextMeshProUGUI EnviCity;
    public TextMeshProUGUI FluidCity;

    // Start is called before the first frame update
    void Start()
    {
        FillEndGameScoreInfo();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void FillEndGameScoreInfo()
    {
        Game _game = GameManager.singleton.game;

        AttractCity.text = _game.cityAttractiveness.ToString();
        EnviCity.text = _game.cityEnvironment.ToString();
        FluidCity.text = _game.cityFluidity.ToString();

    }
}
