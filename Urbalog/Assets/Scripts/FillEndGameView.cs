using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FillEndGameView : MonoBehaviour
{
    public Transform buildingsContainer;
    public Transform buildingsTemplate;
    public TextMeshProUGUI AttractCity;
    public TextMeshProUGUI EnviCity;
    public TextMeshProUGUI FluidCity;
    public TextMeshProUGUI LogisticCity;
    public TextMeshProUGUI SentenceLogistic;

    // Start is called before the first frame update
    void Start()
    {
        FillEndGameScoreInfo();
        test();
    }


    //awake is initialized after all objects are initialized
    private void test()
    {
        /*buildingsContainer = transform.Find("BuildingEntryContainer");
        buildingsTemplate = buildingsContainer.Find("BuildingEntryTemplate");*/

        buildingsTemplate.gameObject.SetActive(false);

        for(int i = 0; i < GameManager.singleton.game.BuildingsBuilt.Count; i++)
        {
            Transform entryTransform = Instantiate(buildingsTemplate, buildingsContainer);
            entryTransform.gameObject.SetActive(true);
            entryTransform.Find("NameEntry").GetComponent<Text>().text = GameManager.singleton.game.BuildingsBuilt[i].name;
            entryTransform.Find("DescriptionEntry").GetComponent<Text>().text = GameManager.singleton.game.BuildingsBuilt[i].description;
        }
    }

    private void FillEndGameScoreInfo()
    {
        Game _game = GameManager.singleton.game;

        AttractCity.text = _game.cityAttractiveness.ToString();
        EnviCity.text = _game.cityEnvironment.ToString();
        FluidCity.text = _game.cityFluidity.ToString();
        LogisticCity.text = _game.cityLogistic.ToString();
        LogisticSentence();

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
            SentenceLogistic.text = "D'un point de vue logistique, l'organisation de votre ville est à revoir.";
        }
        else if ((LogisticScore > 0) && (LogisticScore <= 2))
        {
            SentenceLogistic.text = "D'un point de vue logistique, l'organisation de votre ville est à revoir.";
        }
        else
        {
            SentenceLogistic.text = "Le transport de marchandises se fait très facilement dans votre ville.";
        }

    }
}
