using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FillEndGameView : MonoBehaviour
{
    public TextMeshProUGUI AttractCity;
    public TextMeshProUGUI EnviCity;
    public TextMeshProUGUI FluidCity;
    public TextMeshProUGUI LogisticCity;
    public TextMeshProUGUI SentenceLogistic;

    public Image Envi;
    public Image Attract;
    public Image Fluid;
    public Image Logi;

    Color urbaGrey = new Color(0.58f, 0.63f, 0.71f);
    Color urbaGreen = new Color(0.56f, 0.68f, 0.32f);
    Color urbaRed = new Color(0.83f, 0.19f, 0.11f);

    // Start is called before the first frame update
    void Start()
    {
        FillEndGameScoreInfo();
    }

    private void FillEndGameScoreInfo()
    {
        Game _game = GameManager.singleton.game;

        AttractCity.text = _game.cityAttractiveness.ToString();
        EnviCity.text = _game.cityEnvironment.ToString();
        FluidCity.text = _game.cityFluidity.ToString();
        LogisticCity.text = _game.cityLogistic.ToString();
        LogisticSentence();
        ColorImpact();

    }

    private void LogisticSentence()
    {
        int LogisticScore = GameManager.singleton.game.cityLogistic;

        if(LogisticScore <= -2)
        {
            SentenceLogistic.text = "D'un point de vue logistique, l'organisation de votre ville est à revoir.";
        }
        else if ((LogisticScore > -2) && (LogisticScore <= 0))
        {
            SentenceLogistic.text = "Dans votre ville, les transports de marchandises se font avec quelques difficultés mineures.";
        }
        else if ((LogisticScore > 0) && (LogisticScore <= 2))
        {
            SentenceLogistic.text = "D'un point de vue logistique, votre ville s'en sort plutôt bien, la plupart des livraisons se font sans encombre.";
        }
        else
        {
            SentenceLogistic.text = "Le transport de marchandises se fait très facilement dans votre ville.";
        }

    }


    public void ColorImpact()
    {
        Game game = GameManager.singleton.game;
        if (game.cityAttractiveness < 0)
        {
            Attract.color = urbaRed;
        }
        else if (game.cityAttractiveness == 0)
        {
            Attract.color = urbaGrey;
        }
        else
        {
            Attract.color = urbaGreen;
        }

        if (game.cityEnvironment < 0)
        {
            Envi.color = urbaRed;
        }
        else if (game.cityEnvironment == 0)
        {
            Envi.color = urbaGrey;
        }
        else
        {
            Envi.color = urbaGreen;
        }

        if (game.cityFluidity < 0)
        {
            Fluid.color = urbaRed;
        }
        else if (game.cityFluidity == 0)
        {
            Fluid.color = urbaGrey;
        }
        else
        {
            Fluid.color = urbaGreen;
        }

        if (game.cityLogistic < 0)
        {
            Logi.color = urbaRed;
        }
        else if (game.cityLogistic == 0)
        {
            Logi.color = urbaGrey;
        }
        else
        {
            Logi.color = urbaGreen;
        }


    }
}
