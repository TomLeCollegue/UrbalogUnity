using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PopUpBuildingDisplay : MonoBehaviour
{
    public GameObject PopUp;
    public TextMeshProUGUI nameBuilding;
    public TextMeshProUGUI descBuilding;
    public TextMeshProUGUI scoreAttract;
    public TextMeshProUGUI scoreEnvi;
    public TextMeshProUGUI scoreFluid;
    public TextMeshProUGUI scoreLogi;
    public TextMeshProUGUI descLogi;

    public Image BuildingImage; 
    public Image Logi;

    public Sprite Building;
    public Sprite bikeRoad;
    public Sprite Poste;
    public Sprite BorneVelo;
    public Sprite petitMagasin;
    public Sprite CDU;
    public Sprite banc;
    public Sprite PAV;
    public Sprite bigMarket;
    public Sprite consigne;
    public Sprite garden;
    public Sprite gazStation;
    public Sprite terrasse;
    public Sprite meeting;
    public Sprite delivery;
    public Sprite antiram;




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
        FillSprite(building);
    }

    private void FillInfoBuilding(Building building)
    {
        nameBuilding.text = building.name;
        descBuilding.text = building.description;
        scoreAttract.text = building.attractScore.ToString();
        scoreEnvi.text = building.enviScore.ToString();
        scoreFluid.text = building.fluidScore.ToString();

        if (SceneManager.GetActiveScene().name.Equals("EndGame"))
        {
            scoreLogi.text = building.logisticScore.ToString();
            descLogi.text = building.logisticDescription;
        }

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

        if (SceneManager.GetActiveScene().name.Equals("EndGame"))
        {
            if (building.logisticScore < 0)
            {
                Logi.color = urbaRed;
            }
            else if ((building.logisticScore == 0))
            {
                Logi.color = urbaGrey;
            }
            else
            {
                Logi.color = urbaGreen;
            }
        }

        }

        public void DismissPopUP()
    {
        PopUp.SetActive(false);
    }




    public void FillSprite(Building _building)
    {
        if (_building.nameForSprite.Equals("Piste cyclable"))
        {
            BuildingImage.GetComponent<Image>().sprite = bikeRoad;
        }
        else if (_building.nameForSprite.Equals("Borne vélo"))
        {
            BuildingImage.GetComponent<Image>().sprite = BorneVelo;
        }
        else if (_building.nameForSprite.Equals("Poste"))
        {
            BuildingImage.GetComponent<Image>().sprite = Poste;
        }
        else if (_building.nameForSprite.Equals("Petit magasin"))
        {
            BuildingImage.GetComponent<Image>().sprite = petitMagasin;
        }
        else if (_building.nameForSprite.Equals("CDU"))
        {
            BuildingImage.GetComponent<Image>().sprite = CDU;
        }
        else if (_building.nameForSprite.Equals("Banc"))
        {
            BuildingImage.GetComponent<Image>().sprite = banc;
        }
        else if (_building.nameForSprite.Equals("PAV"))
        {
            BuildingImage.GetComponent<Image>().sprite = PAV;
        }
        else if (_building.nameForSprite.Equals("Grand magasin"))
        {
            BuildingImage.GetComponent<Image>().sprite = bigMarket;
        }
        else if (_building.nameForSprite.Equals("Réseau de consignes"))
        {
            BuildingImage.GetComponent<Image>().sprite = consigne;
        }
        else if (_building.nameForSprite.Equals("Zone végétalisée"))
        {
            BuildingImage.GetComponent<Image>().sprite = garden;
        }
        else if (_building.nameForSprite.Equals("Stations GAZ GNV"))
        {
            BuildingImage.GetComponent<Image>().sprite = gazStation;
        }
        else if (_building.nameForSprite.Equals("Zone de rencontre"))
        {
            BuildingImage.GetComponent<Image>().sprite = meeting;
        }
        else if (_building.nameForSprite.Equals("Aire de livraison"))
        {
            BuildingImage.GetComponent<Image>().sprite = delivery;
        }
        else if (_building.nameForSprite.Equals("Dispositif anti-bélier"))
        {
            BuildingImage.GetComponent<Image>().sprite = antiram;
        }
        else if (_building.nameForSprite.Equals("Terrasse"))
        {
            BuildingImage.GetComponent<Image>().sprite = terrasse;
        }
        else
        {
            BuildingImage.GetComponent<Image>().sprite = Building;
        }
    }


}
