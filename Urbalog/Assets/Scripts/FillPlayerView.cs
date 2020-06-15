using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FillPlayerView : MonoBehaviour
{

    #region Building1
    public TextMeshProUGUI building1Button;
    public TextMeshProUGUI PoliticalBuilding1;
    public TextMeshProUGUI EcoBuilding1;
    public TextMeshProUGUI SocialBuilding1;
    public TextMeshProUGUI AttractBuilding1;
    public TextMeshProUGUI EnviBuilding1;
    public TextMeshProUGUI FluidBuilding1;

    #endregion

    #region Role
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



    // Update is called once per frame
    void Update()
    {
        FillPLayerViewInfo();
    }


    private void FillPLayerViewInfo()
    {
        Game game = GameManager.singleton.game;
        PoliticalBuilding1.text = game.Market[1].FinancePolitical + "/" + game.Market[1].Political;
        EcoBuilding1.text = game.Market[1].FinanceEconomical + "/" + game.Market[1].Economical;
        SocialBuilding1.text = game.Market[1].FinanceSocial + "/" + game.Market[1].Social;
        AttractBuilding1.text = game.Market[1].attractScore.ToString();
        FluidBuilding1.text = game.Market[1].fluidScore.ToString();
        EnviBuilding1.text = game.Market[1].enviScore.ToString();
        building1Button.text = game.Market[1].name;

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
}
