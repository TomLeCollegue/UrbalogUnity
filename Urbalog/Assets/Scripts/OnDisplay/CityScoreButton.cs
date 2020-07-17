using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CityScoreButton : MonoBehaviour
{
    public GameObject RoleFrame;
    public GameObject City;
    public GameObject Market;

    public TextMeshProUGUI Attract;
    public TextMeshProUGUI Envi;
    public TextMeshProUGUI Fluid;

    public Image EnviImage;
    public Image AttractImage;
    public Image FluidImage;

    Color urbaGrey = new Color(0.58f, 0.63f, 0.71f);
    Color urbaGreen = new Color(0.56f, 0.68f, 0.32f);
    Color urbaRed = new Color(0.83f, 0.19f, 0.11f);

    //public Button NextTurnButton;
    public void OpenPanel()
    {
        RoleFrame.SetActive(false);
        Market.SetActive(false);
        City.SetActive(true);
        
    }

    public void ClosePanel()
    {
        RoleFrame.SetActive(true);
        Market.SetActive(false);
        City.SetActive(false);
    }

    public void GoToMarket()
    {
        Market.SetActive(true);
        RoleFrame.SetActive(false);
    }

    public void GoToRole()
    {
        Market.SetActive(false);
        RoleFrame.SetActive(true);
    }


    /// <summary>
    /// Refresh city scores on panel when it is opened
    /// </summary>
    public void UpdateCityScorePanel()
    {
        Game _game = GameManager.singleton.game;

        Debug.Log("1CityScorePanel : Attract.text");

        Attract.text = _game.cityAttractiveness.ToString();
        Envi.text = _game.cityEnvironment.ToString();
        Fluid.text = _game.cityFluidity.ToString();
        ColorImpact();
    }

    private void Update()
    {
        UpdateCityScorePanel();
    }

    public void ColorImpact()
    {
        Game game = GameManager.singleton.game;
        if (game.cityAttractiveness < 0)
        {
            AttractImage.color = urbaRed;
        }
        else if (game.cityAttractiveness == 0)
        {
            AttractImage.color = urbaGrey;
        }
        else
        {
            AttractImage.color = urbaGreen;
        }

        if (game.cityEnvironment < 0)
        {
            EnviImage.color = urbaRed;
        }
        else if (game.cityEnvironment == 0)
        {
            EnviImage.color = urbaGrey;
        }
        else
        {
            EnviImage.color = urbaGreen;
        }

        if (game.cityFluidity < 0)
        {
            FluidImage.color = urbaRed;
        }
        else if (game.cityFluidity == 0)
        {
            FluidImage.color = urbaGrey;
        }
        else
        {
            FluidImage.color = urbaGreen;
        }


    }
}
