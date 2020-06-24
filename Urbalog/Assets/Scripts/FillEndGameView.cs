using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FillEndGameView : MonoBehaviour
{
    public GameObject buildingsBuiltItem;
    public Transform buildingsListHolder;
    public TextMeshProUGUI AttractCity;
    public TextMeshProUGUI EnviCity;
    public TextMeshProUGUI FluidCity;
    public TextMeshProUGUI LogisticCity;
    public TextMeshProUGUI SentenceLogistic;

    // Start is called before the first frame update
    void Start()
    {
        FillEndGameScoreInfo();
        FillBuildingsBuiltList();
    }


    //awake is initialized after all objects are initialized
    private void FillBuildingsBuiltList()
    {
        for (int i = 0; i < GameManager.singleton.game.BuildingsBuilt.Count; i++)
        {
            SpawnBuildingBuiltItem(GameManager.singleton.game.BuildingsBuilt[i]);
        }
    }
    public void SpawnBuildingBuiltItem(Building _building)
    {
        GameObject Item = Instantiate(buildingsBuiltItem, buildingsListHolder);
        Item.GetComponent<BuildingsBuiltListItem>().RenameBuilding(_building.name);
        Item.GetComponent<BuildingsBuiltListItem>().RenameDescripLog(_building.logisticDescription);
        Item.GetComponent<BuildingsBuiltListItem>().RenameScoreLogstring(_building.logisticScore);

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
