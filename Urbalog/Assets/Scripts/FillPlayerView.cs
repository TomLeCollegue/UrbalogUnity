using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FillPlayerView : MonoBehaviour
{

    Color urbaGreen = new Color(0.1f, 0.3f, 0.0f);
    Color urbaRed = new Color(0.6f, 0.0f, 0.0f);

    #region Building1
    [Space(10)]
    [Header("Building 1")]
    public TextMeshProUGUI building1Button;
    public TextMeshProUGUI PoliticalBuilding1;
    public TextMeshProUGUI EcoBuilding1;
    public TextMeshProUGUI SocialBuilding1;
    public TextMeshProUGUI AttractBuilding1;
    public TextMeshProUGUI EnviBuilding1;
    public TextMeshProUGUI FluidBuilding1;
    
    public Image AttractBuilding1Image;
    public Image EnviBuilding1Image;
    public Image fluidBuilding1Image;

    [Space(10)]
    [Header("Building 2")]
    public TextMeshProUGUI building2Button;
    public TextMeshProUGUI PoliticalBuilding2;
    public TextMeshProUGUI EcoBuilding2;
    public TextMeshProUGUI SocialBuilding2;
    public TextMeshProUGUI AttractBuilding2;
    public TextMeshProUGUI EnviBuilding2;
    public TextMeshProUGUI FluidBuilding2;

    public Image AttractBuilding2Image;
    public Image EnviBuilding2Image;
    public Image fluidBuilding2Image;

    [Space(10)]
    [Header("Building 3")]
    public TextMeshProUGUI building3Button;
    public TextMeshProUGUI PoliticalBuilding3;
    public TextMeshProUGUI EcoBuilding3;
    public TextMeshProUGUI SocialBuilding3;
    public TextMeshProUGUI AttractBuilding3;
    public TextMeshProUGUI EnviBuilding3;
    public TextMeshProUGUI FluidBuilding3;

    public Image AttractBuilding3Image;
    public Image EnviBuilding3Image;
    public Image fluidBuilding3Image;

    [Space(10)]
    [Header("Building 4")]
    public TextMeshProUGUI building4Button;
    public TextMeshProUGUI PoliticalBuilding4;
    public TextMeshProUGUI EcoBuilding4;
    public TextMeshProUGUI SocialBuilding4;
    public TextMeshProUGUI AttractBuilding4;
    public TextMeshProUGUI EnviBuilding4;
    public TextMeshProUGUI FluidBuilding4;

    public Image AttractBuilding4Image;
    public Image EnviBuilding4Image;
    public Image fluidBuilding4Image;

    [Space(10)]
    [Header("Building 5")]
    public TextMeshProUGUI building5Button;
    public TextMeshProUGUI PoliticalBuilding5;
    public TextMeshProUGUI EcoBuilding5;
    public TextMeshProUGUI SocialBuilding5;
    public TextMeshProUGUI AttractBuilding5;
    public TextMeshProUGUI EnviBuilding5;
    public TextMeshProUGUI FluidBuilding5;

    public Image AttractBuilding5Image;
    public Image EnviBuilding5Image;
    public Image fluidBuilding5Image;
    #endregion

    #region Role
    [Space(10)]
    [Header("Role")]
    public TextMeshProUGUI NameRole;
    public TextMeshProUGUI NombreRessource1;
    public TextMeshProUGUI NombreRessource2;

    public Image ressource1Img;
    public Image ressource2Img;
    public Image ressource1betImage;
    public Image ressource2betImage;
    public Image holdImage;
    public Image improveImage;


    public Sprite EcoImage;
    public Sprite PoliImage;
    public Sprite SocialImage;

    public Sprite FluidImage;
    public Sprite AttractImage;
    public Sprite EnviImage;


    #endregion
    public bool isAlreadyUpdated = false;


    // Update is called once per frame
    void Update()
    {
        FillPLayerViewInfo();
        if (!isAlreadyUpdated)
        {
            ColorImpact();
            isAlreadyUpdated = true;
        }

    }


    private void FillPLayerViewInfo()
    {
        Game game = GameManager.singleton.game;
        PoliticalBuilding1.text = game.Market[0].FinancePolitical + "/" + game.Market[0].Political;
        EcoBuilding1.text = game.Market[0].FinanceEconomical + "/" + game.Market[0].Economical;
        SocialBuilding1.text = game.Market[0].FinanceSocial + "/" + game.Market[0].Social;
        AttractBuilding1.text = game.Market[0].attractScore.ToString();
        FluidBuilding1.text = game.Market[0].fluidScore.ToString();
        EnviBuilding1.text = game.Market[0].enviScore.ToString();
        building1Button.text = game.Market[0].name;

        PoliticalBuilding2.text = game.Market[1].FinancePolitical + "/" + game.Market[1].Political;
        EcoBuilding2.text = game.Market[1].FinanceEconomical + "/" + game.Market[1].Economical;
        SocialBuilding2.text = game.Market[1].FinanceSocial + "/" + game.Market[1].Social;
        AttractBuilding2.text = game.Market[1].attractScore.ToString();
        FluidBuilding2.text = game.Market[1].fluidScore.ToString();
        EnviBuilding2.text = game.Market[1].enviScore.ToString();
        building2Button.text = game.Market[1].name;

        PoliticalBuilding3.text = game.Market[2].FinancePolitical + "/" + game.Market[2].Political;
        EcoBuilding3.text = game.Market[2].FinanceEconomical + "/" + game.Market[2].Economical;
        SocialBuilding3.text = game.Market[2].FinanceSocial + "/" + game.Market[2].Social;
        AttractBuilding3.text = game.Market[2].attractScore.ToString();
        FluidBuilding3.text = game.Market[2].fluidScore.ToString();
        EnviBuilding3.text = game.Market[2].enviScore.ToString();
        building3Button.text = game.Market[2].name;

        PoliticalBuilding4.text = game.Market[3].FinancePolitical + "/" + game.Market[3].Political;
        EcoBuilding4.text = game.Market[3].FinanceEconomical + "/" + game.Market[3].Economical;
        SocialBuilding4.text = game.Market[3].FinanceSocial + "/" + game.Market[3].Social;
        AttractBuilding4.text = game.Market[3].attractScore.ToString();
        FluidBuilding4.text = game.Market[3].fluidScore.ToString();
        EnviBuilding4.text = game.Market[3].enviScore.ToString();
        building4Button.text = game.Market[3].name;

        PoliticalBuilding5.text = game.Market[4].FinancePolitical + "/" + game.Market[4].Political;
        EcoBuilding5.text = game.Market[4].FinanceEconomical + "/" + game.Market[4].Economical;
        SocialBuilding5.text = game.Market[4].FinanceSocial + "/" + game.Market[4].Social;
        AttractBuilding5.text = game.Market[4].attractScore.ToString();
        FluidBuilding5.text = game.Market[4].fluidScore.ToString();
        EnviBuilding5.text = game.Market[4].enviScore.ToString();
        building5Button.text = game.Market[4].name;
        FillRole();
    }

    


    private void FillRole()
    {
        Role role = GameObject.Find("playerLocal").GetComponent<Player>().role;
        NameRole.text = role.nameRole;

        #region Ressources
        if (role.ressource1.Equals("Economical"))
        {
            NombreRessource1.text = role.ressourceEconomical.ToString();
            ressource1Img.GetComponent<Image>().sprite = EcoImage;
            ressource1betImage.GetComponent<Image>().sprite = EcoImage;

        }
        else if (role.ressource1.Equals("Political"))
        {
            NombreRessource1.text = role.ressourcePolitical.ToString();
            ressource1Img.GetComponent<Image>().sprite = PoliImage;
            ressource1betImage.GetComponent<Image>().sprite = PoliImage;
        }
        else
        {
            NombreRessource1.text = role.ressourceSocial.ToString();
            ressource1Img.GetComponent<Image>().sprite = SocialImage;
            ressource1betImage.GetComponent<Image>().sprite = SocialImage;
        }

        if (role.ressource2.Equals("Economical"))
        {
            NombreRessource2.text = role.ressourceEconomical.ToString();
            ressource2Img.GetComponent<Image>().sprite = EcoImage;
            ressource2betImage.GetComponent<Image>().sprite = EcoImage;
        }
        else if (role.ressource2.Equals("Political"))
        {
            NombreRessource2.text = role.ressourcePolitical.ToString();
            ressource2Img.GetComponent<Image>().sprite = PoliImage;
            ressource2betImage.GetComponent<Image>().sprite = PoliImage;
        }
        else
        {
            NombreRessource2.text = role.ressourceSocial.ToString();
            ressource2Img.GetComponent<Image>().sprite = SocialImage;
            ressource2betImage.GetComponent<Image>().sprite = SocialImage;
        }

        #endregion

        #region Objectifs
        if (role.hold.Equals("Fluidity"))
        {
            holdImage.GetComponent<Image>().sprite = FluidImage;
        }
        else if (role.hold.Equals("Attractiveness"))
        {
            holdImage.GetComponent<Image>().sprite = AttractImage;
        }
        else
        {
            holdImage.GetComponent<Image>().sprite = EnviImage;
        }

        if (role.improve.Equals("Fluidity"))
        {
            improveImage.GetComponent<Image>().sprite = FluidImage;
        }
        else if (role.improve.Equals("Attractiveness"))
        {
            improveImage.GetComponent<Image>().sprite = AttractImage;
        }
        else
        {
            improveImage.GetComponent<Image>().sprite = EnviImage;
        }
        #endregion
    }

    private void ColorImpact()
    {
        Game game = GameManager.singleton.game;
        Debug.Log("1");

        //Attract
            //building1
        if (game.Market[0].attractScore < 0)
        {
            AttractBuilding1Image.GetComponent<Image>().color = urbaRed;
        }
        else if (game.Market[0].attractScore == 0)
        {
            AttractBuilding1Image.GetComponent<Image>().color = Color.black;
        }
        else
        {
            AttractBuilding1Image.GetComponent<Image>().color = urbaGreen;
        }

            //building2
        if (game.Market[1].attractScore < 0)
        {
            AttractBuilding2Image.GetComponent<Image>().color = urbaRed;
        }
        else if (game.Market[1].attractScore == 0)
        {
            AttractBuilding2Image.GetComponent<Image>().color = Color.black;
        }
        else
        {
            AttractBuilding2Image.GetComponent<Image>().color = urbaGreen;
        }

            //building3
        if (game.Market[2].attractScore < 0)
        {
            AttractBuilding3Image.GetComponent<Image>().color = urbaRed;
        }
        else if (game.Market[2].attractScore == 0)
        {
            AttractBuilding3Image.GetComponent<Image>().color = Color.black;
        }
        else
        {
            AttractBuilding3Image.GetComponent<Image>().color = urbaGreen;
        }

            //building4
        if (game.Market[3].attractScore < 0)
        {
            AttractBuilding4Image.GetComponent<Image>().color = urbaRed;
        }
        else if (game.Market[3].attractScore == 0)
        {
            AttractBuilding4Image.GetComponent<Image>().color = Color.black;
        }
        else
        {
            AttractBuilding4Image.GetComponent<Image>().color = urbaGreen;
        }

            //building5
        if (game.Market[4].attractScore < 0)
        {
            AttractBuilding5Image.GetComponent<Image>().color = urbaRed;
        }
        else if (game.Market[4].attractScore == 0)
        {
            AttractBuilding5Image.GetComponent<Image>().color = Color.black;
        }
        else
        {
            AttractBuilding5Image.GetComponent<Image>().color = urbaGreen;
        }


        //Envi
        //building1
        if (game.Market[0].enviScore < 0)
        {
            EnviBuilding1Image.GetComponent<Image>().color = urbaRed;
        }
        else if (game.Market[0].enviScore == 0)
        {
            EnviBuilding1Image.GetComponent<Image>().color = Color.black;
        }
        else
        {
            EnviBuilding1Image.GetComponent<Image>().color = urbaGreen;
        }

        //building2
        if (game.Market[1].enviScore < 0)
        {
            EnviBuilding2Image.GetComponent<Image>().color = urbaRed;
        }
        else if (game.Market[1].enviScore == 0)
        {
            EnviBuilding2Image.GetComponent<Image>().color = Color.black;
        }
        else
        {
            EnviBuilding2Image.GetComponent<Image>().color = urbaGreen;
        }

        //building3
        if (game.Market[2].enviScore < 0)
        {
            EnviBuilding3Image.GetComponent<Image>().color = urbaRed;
        }
        else if (game.Market[2].enviScore == 0)
        {
            EnviBuilding3Image.GetComponent<Image>().color = Color.black;
        }
        else
        {
            EnviBuilding3Image.GetComponent<Image>().color = urbaGreen;
        }

        //building4
        if (game.Market[3].enviScore < 0)
        {
            EnviBuilding4Image.GetComponent<Image>().color = urbaRed;
        }
        else if (game.Market[3].enviScore == 0)
        {
            EnviBuilding4Image.GetComponent<Image>().color = Color.black;
        }
        else
        {
            EnviBuilding4Image.GetComponent<Image>().color = urbaGreen;
        }

        //building5
        if (game.Market[4].enviScore < 0)
        {
            EnviBuilding5Image.GetComponent<Image>().color = urbaRed;
        }
        else if (game.Market[4].enviScore == 0)
        {
            EnviBuilding5Image.GetComponent<Image>().color = Color.black;
        }
        else
        {
            EnviBuilding5Image.GetComponent<Image>().color = urbaGreen;
        }

        //Fluidity
        //building1
        if (game.Market[0].fluidScore < 0)
        {
            fluidBuilding1Image.GetComponent<Image>().color = urbaRed;
        }
        else if (game.Market[0].fluidScore == 0)
        {
            fluidBuilding1Image.GetComponent<Image>().color = Color.black;
        }
        else
        {
            fluidBuilding1Image.GetComponent<Image>().color = urbaGreen;
        }

        //building2
        if (game.Market[1].fluidScore < 0)
        {
            fluidBuilding2Image.GetComponent<Image>().color = urbaRed;
        }
        else if (game.Market[1].fluidScore == 0)
        {
            fluidBuilding2Image.GetComponent<Image>().color = Color.black;
        }
        else
        {
            fluidBuilding2Image.GetComponent<Image>().color = urbaGreen;
        }

        //building3
        if (game.Market[2].fluidScore < 0)
        {
            fluidBuilding3Image.GetComponent<Image>().color = urbaRed;
        }
        else if (game.Market[2].fluidScore == 0)
        {
            fluidBuilding3Image.GetComponent<Image>().color = Color.black;
        }
        else
        {
            fluidBuilding3Image.GetComponent<Image>().color = urbaGreen;
        }

        //building4
        if (game.Market[3].fluidScore < 0)
        {
            fluidBuilding4Image.GetComponent<Image>().color = urbaRed;
        }
        else if (game.Market[3].fluidScore == 0)
        {
            fluidBuilding4Image.GetComponent<Image>().color = Color.black;
        }
        else
        {
            fluidBuilding4Image.GetComponent<Image>().color = urbaGreen;
        }

        //building5
        if (game.Market[4].fluidScore < 0)
        {
            fluidBuilding5Image.GetComponent<Image>().color = urbaRed;
        }
        else if (game.Market[4].fluidScore == 0)
        {
            fluidBuilding5Image.GetComponent<Image>().color = Color.black;
        }
        else
        {
            fluidBuilding5Image.GetComponent<Image>().color = urbaGreen;
        }


    }


    
}
