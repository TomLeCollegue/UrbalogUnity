using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class popUpLogistic : MonoBehaviour
{
    public GameObject PopUp;
    public TextMeshProUGUI nameBuilding;
    public TextMeshProUGUI descBuilding;
    public TextMeshProUGUI LogisticScore;
    public Image Logistic;

    Color urbaGrey = new Color(0.58f, 0.63f, 0.71f);
    Color urbaGreen = new Color(0.56f, 0.68f, 0.32f);
    Color urbaRed = new Color(0.83f, 0.19f, 0.11f);

    public void DisplayPopUp(Building building)
    {
        PopUp.SetActive(true);
        FillInfoBuilding(building);
    }

    private void FillInfoBuilding(Building building)
    {
        nameBuilding.text = building.name;
        descBuilding.text = building.logisticDescription;
        LogisticScore.text = building.logisticScore.ToString();
        ColorScore(building);
    }

    private void ColorScore(Building building)
    {
        if (building.logisticScore < 0)
        {
            Logistic.color = urbaRed;
        }
        else if ((building.logisticScore == 0))
        {
            Logistic.color = urbaGrey;
        }
        else
        {
            Logistic.color = urbaGreen;
        }
    }

    public void DismissPopUP()
    {
        PopUp.SetActive(false);
    }
}
