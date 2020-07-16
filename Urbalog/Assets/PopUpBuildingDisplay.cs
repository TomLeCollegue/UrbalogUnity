using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUpBuildingDisplay : MonoBehaviour
{
    public GameObject PopUp;
    public TextMeshProUGUI nameBuilding;
    public TextMeshProUGUI descBuilding;
    public TextMeshProUGUI scoreAttract;
    public TextMeshProUGUI scoreEnvi;
    public TextMeshProUGUI scoreFluid;

    public Image Attract;
    public Image Envi;
    public Image Fluid;

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
        descBuilding.text = building.description;
        scoreAttract.text = building.attractScore.ToString();
        scoreEnvi.text = building.enviScore.ToString();
        scoreFluid.text = building.fluidScore.ToString();


        ColorScore(building);
    }

    private void ColorScore(Building building)
    {
        if(building.attractScore < 0)
        {
            Attract.color = urbaRed;
        }
        else if((building.attractScore == 0))
        {
            Attract.color = urbaGrey;
        }
        else
        {
            Attract.color = urbaGreen;
        }

        if (building.fluidScore < 0)
        {
            Fluid.color = urbaRed;
        }
        else if ((building.fluidScore == 0))
        {
            Fluid.color = urbaGrey;
        }
        else
        {
            Fluid.color = urbaGreen;
        }

        if (building.enviScore < 0)
        {
            Envi.color = urbaRed;
        }
        else if ((building.enviScore == 0))
        {
            Envi.color = urbaGrey;
        }
        else
        {
            Envi.color = urbaGreen;
        }
    }

    public void DismissPopUP()
    {
        PopUp.SetActive(false);
    }


}
