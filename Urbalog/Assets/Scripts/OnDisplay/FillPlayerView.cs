using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

/// <summary>
/// FillsPlayerView with all the informations about the current state of the game.
/// </summary>
public class FillPlayerView : MonoBehaviour
{
    #region Colors
    Color urbaGrey = new Color(0.58f, 0.63f, 0.71f);
    Color urbaGreen = new Color(0.56f, 0.68f, 0.32f);
    Color urbaRed = new Color(0.83f, 0.19f, 0.11f);
    Color urbaBlue = new Color(0.0f,0.3f,0.9f);
    Color resourceFrameLightGreen = new Color(0.47f,0.73f,0.42f);
    Color resourceFrameLightGrey = new Color(1f, 1f, 1f);
    Color buildingNameGreen = new Color(0.00f, 1.00f, 0.22f);
    Color NameBuildingNotFinanced = new Color(0.1764706f , 0.1686275f, 0.2470588f);
    Color ResourcesTextNotFinanced = new Color(0.2745098f, 0.2705882f, 0.3372549f);

    
    Color Green2 = new Color(0.686f, 0.792f, 0.549f);
    Color GreenInsideBuilding = new Color(0.854f, 0.905f, 0.788f);
    Color RedInsideBuilding = new Color(0.976f, 0.698f, 0.713f);

    Color GreenBorderBuilding = new Color(0.525f, 0.690f, 0.298f);
    Color RedBorderBuilding = new Color(0.925f, 0f, 0.062f);

    Color GreyInsideBuilding = new Color(0.917f, 0.952f, 0.964f);
    Color GreyBorderBuilding = new Color(0.717f, 0.741f, 0.768f);
    //yael green border 0.525, 0.690, 0.298
    //yael green inside 0.854, 0.905, 0.788

    //yael red border 0.925, 0, 0.062
    //yael red inside 0.976, 0.698, 0.713

    //yael grey border 0.717, 0.741, 0.768
    //yael grey inside 0.917, 0.952, 0.964

    #endregion
    #region Buildings
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

    public Image PoliticalFrameBuilding1;
    public Image EcoFrameBuilding1;
    public Image SocialFrameBuilding1;

    public TextMeshProUGUI buildingName1;

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

    public Image PoliticalFrameBuilding2;
    public Image EcoFrameBuilding2;
    public Image SocialFrameBuilding2;

    public TextMeshProUGUI buildingName2;

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

    public Image PoliticalFrameBuilding3;
    public Image EcoFrameBuilding3;
    public Image SocialFrameBuilding3;

    public TextMeshProUGUI buildingName3;

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

    public Image PoliticalFrameBuilding4;
    public Image EcoFrameBuilding4;
    public Image SocialFrameBuilding4;

    public TextMeshProUGUI buildingName4;


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

    public Image PoliticalFrameBuilding5;
    public Image EcoFrameBuilding5;
    public Image SocialFrameBuilding5;

    public TextMeshProUGUI buildingName5;


    #endregion

    [Space(10)]
    [Header("Turn Number")]
    public TextMeshProUGUI turnNumberText;
    #region Role
    [Space(10)]
    [Header("Role")]
    public TextMeshProUGUI NameRole;
    public TextMeshProUGUI NombreRessource1;
    public TextMeshProUGUI NombreRessource2;
    public TextMeshProUGUI ScorePlayer;

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



    public Image ressource1Market;
    public Image ressource2Market;
    public Image improveMarket;
    public Image holdMarket;
    public TextMeshProUGUI ressource1MarketText;
    public TextMeshProUGUI ressource2MarketText;

    public Image PicRole;
    public Sprite Commercant;
    public Sprite Transport;
    public Sprite Mairie;
    public Sprite Habitant;
    public Sprite TransportPublic;

    public TextMeshProUGUI NamePlayer;






    #endregion

    [Space(10)]
    [Header("Bet Panel")]
    #region BetBuilding
    public TextMeshProUGUI BetNameBuilding;
    public TextMeshProUGUI BetNameBuilding2;
    public TextMeshProUGUI BetDescBuilding;
    public TextMeshProUGUI ressource1;
    public TextMeshProUGUI ressource2;
    public TextMeshProUGUI attractScore;
    public TextMeshProUGUI EnviScore;
    public TextMeshProUGUI FluidScore;
    public Image AttractImageBuilding;
    public Image EnviImageBuilding;
    public Image FluidImageBuilding;
    public Image ressource1image;
    public Image ressource2image;
    #endregion

    [Space(10)]
    [Header("When Building is financed")]
    #region FullBuildingFrame
    public Image Building1FullBorder;
    public Image Building1FullInside;
    public Image Building2FullBorder;
    public Image Building2FullInside;
    public Image Building3FullBorder;
    public Image Building3FullInside;
    public Image Building4FullBorder;
    public Image Building4FullInside;
    public Image Building5FullBorder;
    public Image Building5FullInside;
    #endregion

    //For the actions that needs to be updated only once a turn
    public bool isAlreadyUpdated = false;


    // Update is called once per frame
    void Update()
    {
        FillPLayerViewInfo();
        ShowWherePlayerLocalBet();
        SetResourceFramesInGreenWhenCompleted();
        //SetBuildingNameInGreenWhenFinanced(); 
        //probably not useful anymore because we color the resources frame when building is financed

        ColorBuildingsWhenFinanced();

        ScorePlayer.text = "Score :" + GameObject.Find("playerLocal").GetComponent<Player>().scorePlayer;
        ColorImpact();
        FillBuildingsImpact();
        turnNumberText.text = "Num Tour : " + GameManager.singleton.game.turnNumber.ToString();

        //is needed only once a turn
        if (!isAlreadyUpdated)
        {
            isAlreadyUpdated = true;
        }

        FillBetPanel();
    }

    /// <summary>
    /// Color the buildings depending if they are financed and if there are too many buildings financed
    /// </summary>
    public void ColorBuildingsWhenFinanced()
    {
        Game _game = GameManager.singleton.game;
        BetControl _betControl = GameObject.Find("playerLocal").GetComponent<BetControl>();
        //check if the number of buildings financed is greater than the max allowed per turn
        if (tooManyBuildingsFinanced(_betControl.NbBuildingsFinanced()) || NextTurnButton.NbBuildingFinancedTooHighForEndGame())
        /*ou (le nombre de bâtiments financés 
        * + le nombre de bâtiments construits 
        > nbBuildingsMaxGame*/
        {
            ColorFinancedBuildingsBorder(RedBorderBuilding, _betControl, _game);
            ColorFinancedBuildingsInside(RedInsideBuilding, _betControl, _game);
        }
        else //not too many buildings so you want it in green
        {
            ColorFinancedBuildingsBorder(GreenBorderBuilding, _betControl, _game);
            ColorFinancedBuildingsInside(GreenInsideBuilding, _betControl, _game);
        }
    }

    /// <summary>
    /// checks if there is too many buildings financed for a given turn
    /// (not counting the end of the game)
    /// </summary>
    /// <param name="_nbBuildingsFinanced"></param>
    /// <returns>true if too much buildings</returns>
    public static bool tooManyBuildingsFinanced(int _nbBuildingsFinanced)
    {
        int _numberMaxAllowedPerTurn = GameSettings.nbBuildingsPerTurn; //will be changed when settings menu is created
        return (_nbBuildingsFinanced > _numberMaxAllowedPerTurn);
    }

    /// <summary>
    /// colors the buildings inside with a Color when they are financed.
    /// gets it back to defaut color if not financed
    /// </summary>
    /// <param name="_color"></param>
    /// <param name="_betControl"></param>
    /// <param name="_game"></param>
    private void ColorFinancedBuildingsInside(Color _color, BetControl _betControl, Game _game)
    {
        Color _defaultInsideColor = GreyInsideBuilding;

        //Building1
        if (_betControl.IsFinanced(_game.Market[0]))
        {
            Building1FullInside.GetComponent<Image>().color = _color;
        }
        else
        {
            Building1FullInside.GetComponent<Image>().color = _defaultInsideColor;
        }
        //Building2
        if (_betControl.IsFinanced(_game.Market[1]))
        {
            Building2FullInside.GetComponent<Image>().color = _color;
        }
        else
        {
            Building2FullInside.GetComponent<Image>().color = _defaultInsideColor;
        }
        //Building3
        if (_betControl.IsFinanced(_game.Market[2]))
        {
            Building3FullInside.GetComponent<Image>().color = _color;
        }
        else
        {
            Building3FullInside.GetComponent<Image>().color = _defaultInsideColor;
        }
        //Building4
        if (_betControl.IsFinanced(_game.Market[3]))
        {
            Building4FullInside.GetComponent<Image>().color = _color;
        }
        else
        {
            Building4FullInside.GetComponent<Image>().color = _defaultInsideColor;
        }
        //Building5
        if (_betControl.IsFinanced(_game.Market[4]))
        {
            Building5FullInside.GetComponent<Image>().color = _color;
        }
        else
        {
            Building5FullInside.GetComponent<Image>().color = _defaultInsideColor;
        }

    }

    /// <summary>
    /// colors the buildings border with a Color when they are financed.
    /// gets it back to defaut color if not financed
    /// </summary>
    /// <param name="_color"></param>
    private void ColorFinancedBuildingsBorder(Color _color, BetControl _betControl, Game _game)
    {
        /*0.5803922
        0.627451
        0.7098039*/
        Color _defaultBorderColor = GreyBorderBuilding;

        //Building1
        if (_betControl.IsFinanced(_game.Market[0]))
        {
            Building1FullBorder.GetComponent<Image>().color = _color;
        }
        else
        {
            Building1FullBorder.GetComponent<Image>().color = _defaultBorderColor;
        }
        //Building2
        if (_betControl.IsFinanced(_game.Market[1]))
        {
            Building2FullBorder.GetComponent<Image>().color = _color;
        }
        else
        {
            Building2FullBorder.GetComponent<Image>().color = _defaultBorderColor;
        }
        //Building3
        if (_betControl.IsFinanced(_game.Market[2]))
        {
            Building3FullBorder.GetComponent<Image>().color = _color;
        }
        else
        {
            Building3FullBorder.GetComponent<Image>().color = _defaultBorderColor;
        }
        //Building4
        if (_betControl.IsFinanced(_game.Market[3]))
        {
            Building4FullBorder.GetComponent<Image>().color = _color;
        }
        else
        {
            Building4FullBorder.GetComponent<Image>().color = _defaultBorderColor;
        }
        //Building5
        if (_betControl.IsFinanced(_game.Market[4]))
        {
            Building5FullBorder.GetComponent<Image>().color = _color;
        }
        else
        {
            Building5FullBorder.GetComponent<Image>().color = _defaultBorderColor;
        }


    }




    /// <summary>
    /// It Fills all player view, from buildings names, buildings scores and finance, also calls the <see cref="FillRole"/>
    /// method.
    /// It is called once a frame.
    /// </summary>
    /// <remarks>Does not fill buildings impact, see <see cref="FillBuildingsImpact"/></remarks>
    private void FillPLayerViewInfo()
    {
        Game _game = GameManager.singleton.game;

        //Building1
        PoliticalBuilding1.text = _game.Market[0].FinancePolitical + "/" + _game.Market[0].Political;
        EcoBuilding1.text = _game.Market[0].FinanceEconomical + "/" + _game.Market[0].Economical;
        SocialBuilding1.text = _game.Market[0].FinanceSocial + "/" + _game.Market[0].Social;

        //Building2
        PoliticalBuilding2.text = _game.Market[1].FinancePolitical + "/" + _game.Market[1].Political;
        EcoBuilding2.text = _game.Market[1].FinanceEconomical + "/" + _game.Market[1].Economical;
        SocialBuilding2.text = _game.Market[1].FinanceSocial + "/" + _game.Market[1].Social;

        //Building3
        PoliticalBuilding3.text = _game.Market[2].FinancePolitical + "/" + _game.Market[2].Political;
        EcoBuilding3.text = _game.Market[2].FinanceEconomical + "/" + _game.Market[2].Economical;
        SocialBuilding3.text = _game.Market[2].FinanceSocial + "/" + _game.Market[2].Social;

        //Building4
        PoliticalBuilding4.text = _game.Market[3].FinancePolitical + "/" + _game.Market[3].Political;
        EcoBuilding4.text = _game.Market[3].FinanceEconomical + "/" + _game.Market[3].Economical;
        SocialBuilding4.text = _game.Market[3].FinanceSocial + "/" + _game.Market[3].Social;

        //Building5
        PoliticalBuilding5.text = _game.Market[4].FinancePolitical + "/" + _game.Market[4].Political;
        EcoBuilding5.text = _game.Market[4].FinanceEconomical + "/" + _game.Market[4].Economical;
        SocialBuilding5.text = _game.Market[4].FinanceSocial + "/" + _game.Market[4].Social;


        FillRole();
    }

    /// <summary>
    /// Fills the playerView with the buildings impact and name
    /// </summary>
    /// <remarks>Is not done once a frame to improve performance</remarks>
    private void FillBuildingsImpact()
    {
        Game _game = GameManager.singleton.game;

        //Building1
        AttractBuilding1.text = _game.Market[0].attractScore.ToString();
        FluidBuilding1.text = _game.Market[0].fluidScore.ToString();
        EnviBuilding1.text = _game.Market[0].enviScore.ToString();
        building1Button.text = _game.Market[0].name;

        //Building2
        AttractBuilding2.text = _game.Market[1].attractScore.ToString();
        FluidBuilding2.text = _game.Market[1].fluidScore.ToString();
        EnviBuilding2.text = _game.Market[1].enviScore.ToString();
        building2Button.text = _game.Market[1].name;

        //Building3
        AttractBuilding3.text = _game.Market[2].attractScore.ToString();
        FluidBuilding3.text = _game.Market[2].fluidScore.ToString();
        EnviBuilding3.text = _game.Market[2].enviScore.ToString();
        building3Button.text = _game.Market[2].name;

        //Building4
        AttractBuilding4.text = _game.Market[3].attractScore.ToString();
        FluidBuilding4.text = _game.Market[3].fluidScore.ToString();
        EnviBuilding4.text = _game.Market[3].enviScore.ToString();
        building4Button.text = _game.Market[3].name;

        //Building5
        AttractBuilding5.text = _game.Market[4].attractScore.ToString();
        FluidBuilding5.text = _game.Market[4].fluidScore.ToString();
        EnviBuilding5.text = _game.Market[4].enviScore.ToString();
        building5Button.text = _game.Market[4].name;



    }

    

    /// <summary>
    /// It checks the player role and changes informations that are written on the player card accordingly.
    /// Does it for the ressources (because they change when a bet is done) and for the objectives sprites.
    /// TODO: The sprites don't need to be called once a frame
    /// </summary>
    private void FillRole()
    {
        Role role = GameObject.Find("playerLocal").GetComponent<Player>().role;
        NameRole.text = role.nameRole;
        NamePlayer.text = GameObject.Find("playerLocal").GetComponent<Player>().namePlayer;

        if (role.nameRole.Equals("Habitant"))
        {
            PicRole.GetComponent<Image>().sprite = Habitant;
        }
        else if (role.nameRole.Equals("Transporteur"))
        {
            PicRole.GetComponent<Image>().sprite = Transport;
        }
        else if (role.nameRole.Equals("Collectivité Locale"))
        {
            PicRole.GetComponent<Image>().sprite = Mairie;
        }
        else if (role.nameRole.Equals("Commerçant"))
        {
            PicRole.GetComponent<Image>().sprite = Commercant;

        }
        else
        {
            PicRole.GetComponent<Image>().sprite = TransportPublic;
        }


        


        #region Ressources
        if (role.ressource1.Equals("Economical"))
        {
            NombreRessource1.text = role.ressourceEconomical.ToString();
            ressource1MarketText.text = role.ressourceEconomical.ToString();

            ressource1Img.GetComponent<Image>().sprite = EcoImage;
            ressource1betImage.GetComponent<Image>().sprite = EcoImage;
            ressource1Market.GetComponent<Image>().sprite = EcoImage;

        }
        else if (role.ressource1.Equals("Political"))
        {
            NombreRessource1.text = role.ressourcePolitical.ToString();
            ressource1MarketText.text = role.ressourcePolitical.ToString();
            ressource1Img.GetComponent<Image>().sprite = PoliImage;
            ressource1betImage.GetComponent<Image>().sprite = PoliImage;
            ressource1Market.GetComponent<Image>().sprite = PoliImage;
        }
        else
        {
            NombreRessource1.text = role.ressourceSocial.ToString();
            ressource1MarketText.text = role.ressourceSocial.ToString();

            ressource1Img.GetComponent<Image>().sprite = SocialImage;
            ressource1betImage.GetComponent<Image>().sprite = SocialImage;
            ressource1Market.GetComponent<Image>().sprite = SocialImage;
        }

        if (role.ressource2.Equals("Economical"))
        {
            NombreRessource2.text = role.ressourceEconomical.ToString();
            ressource2MarketText.text = role.ressourceEconomical.ToString();
            ressource2Img.GetComponent<Image>().sprite = EcoImage;
            ressource2betImage.GetComponent<Image>().sprite = EcoImage;
            ressource2Market.GetComponent<Image>().sprite = EcoImage;
        }
        else if (role.ressource2.Equals("Political"))
        {
            NombreRessource2.text = role.ressourcePolitical.ToString();
            ressource2MarketText.text = role.ressourcePolitical.ToString();
            ressource2Img.GetComponent<Image>().sprite = PoliImage;
            ressource2betImage.GetComponent<Image>().sprite = PoliImage;
            ressource2Market.GetComponent<Image>().sprite = PoliImage;
        }
        else
        {
            NombreRessource2.text = role.ressourceSocial.ToString();
            ressource2MarketText.text = role.ressourceSocial.ToString();
            ressource2Img.GetComponent<Image>().sprite = SocialImage;
            ressource2betImage.GetComponent<Image>().sprite = SocialImage;
            ressource2Market.GetComponent<Image>().sprite = SocialImage;
        }

        #endregion

        #region Objectifs
        if (role.hold.Equals("Fluidity"))
        {
            holdImage.GetComponent<Image>().sprite = FluidImage;
            holdMarket.GetComponent<Image>().sprite = FluidImage;
        }
        else if (role.hold.Equals("Attractiveness"))
        {
            holdImage.GetComponent<Image>().sprite = AttractImage;
            holdMarket.GetComponent<Image>().sprite = AttractImage;
        }
        else
        {
            holdImage.GetComponent<Image>().sprite = EnviImage;
            holdMarket.GetComponent<Image>().sprite = EnviImage;
        }

        if (role.improve.Equals("Fluidity"))
        {
            improveImage.GetComponent<Image>().sprite = FluidImage;
            improveMarket.GetComponent<Image>().sprite = FluidImage;
        }
        else if (role.improve.Equals("Attractiveness"))
        {
            improveImage.GetComponent<Image>().sprite = AttractImage;
            improveMarket.GetComponent<Image>().sprite = AttractImage;
        }
        else
        {
            improveImage.GetComponent<Image>().sprite = EnviImage;
            improveMarket.GetComponent<Image>().sprite = EnviImage;
        }
        #endregion
    }


    /// <summary>
    /// Checks every building impact scores and color the impact sprite depending if it is a
    /// negative impact or positive impact
    /// </summary>
    /// <remarks>coloring in red if negative, in black if 0 and in green if positive</remarks>
    private void ColorImpact()
    {
        Game game = GameManager.singleton.game;

        //Attract
            //building1
        if (game.Market[0].attractScore < 0)
        {
            AttractBuilding1Image.GetComponent<Image>().color = urbaRed;
        }
        else if (game.Market[0].attractScore == 0)
        {
            AttractBuilding1Image.GetComponent<Image>().color = urbaGrey;
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
            AttractBuilding2Image.GetComponent<Image>().color = urbaGrey;
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
            AttractBuilding3Image.GetComponent<Image>().color = urbaGrey;
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
            AttractBuilding4Image.GetComponent<Image>().color = urbaGrey;
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
            AttractBuilding5Image.GetComponent<Image>().color = urbaGrey;
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
            EnviBuilding1Image.GetComponent<Image>().color = urbaGrey;
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
            EnviBuilding2Image.GetComponent<Image>().color = urbaGrey;
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
            EnviBuilding3Image.GetComponent<Image>().color = urbaGrey;
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
            EnviBuilding4Image.GetComponent<Image>().color = urbaGrey;
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
            EnviBuilding5Image.GetComponent<Image>().color = urbaGrey;
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
            fluidBuilding1Image.GetComponent<Image>().color = urbaGrey;
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
            fluidBuilding2Image.GetComponent<Image>().color = urbaGrey;
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
            fluidBuilding3Image.GetComponent<Image>().color = urbaGrey;
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
            fluidBuilding4Image.GetComponent<Image>().color = urbaGrey;
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
            fluidBuilding5Image.GetComponent<Image>().color = urbaGrey;
        }
        else
        {
            fluidBuilding5Image.GetComponent<Image>().color = urbaGreen;
        }

    }


    public void UpdateTurn()
    {
        Debug.Log("Update Turn:" + GameManager.singleton.game.turnNumber.ToString());
        isAlreadyUpdated = false;
    }

    /// <summary>
    /// For each text, shows on which building and on which resource the playerLocal bets with a blue color.
    /// </summary>
    public void ShowWherePlayerLocalBet()
    {
        BetControl _betControl = GameObject.Find("playerLocal").GetComponent<BetControl>();
        Role _role = GameObject.Find("playerLocal").GetComponent<Player>().role;

        int _building = 0;

        //Building1
        //Political
        if (_betControl.FindIndexFromResource("Political", _role) != -1)
        {
            if (IsBet(_betControl,"Political",_role, _building))
            {
                PoliticalBuilding1.color = urbaBlue;
            }
            else
            {
                PoliticalBuilding1.color = ResourcesTextNotFinanced;
            }
        }

        //Economical
        if (_betControl.FindIndexFromResource("Economical", _role) != -1)
        {
            if (IsBet(_betControl, "Economical", _role, _building))
            {
                EcoBuilding1.color = urbaBlue;
            }
            else
            {
                EcoBuilding1.color = ResourcesTextNotFinanced;
            }
        }

        //Social
        if (_betControl.FindIndexFromResource("Social", _role) != -1)
        {
            if (IsBet(_betControl, "Social", _role, _building))
            {
                SocialBuilding1.color = urbaBlue;
            }
            else
            {
                SocialBuilding1.color = ResourcesTextNotFinanced;
            }
        }

        //Building2
        //Political
        if (_betControl.FindIndexFromResource("Political", _role) != -1)
        {
            if (IsBet(_betControl, "Political", _role, _building+1))
            {
                PoliticalBuilding2.color = urbaBlue;
            }
            else
            {
                PoliticalBuilding2.color = ResourcesTextNotFinanced;
            }
        }

        //Economical
        if (_betControl.FindIndexFromResource("Economical", _role) != -1)
        {
            if (IsBet(_betControl, "Economical", _role, _building+1))
            {
                EcoBuilding2.color = urbaBlue;
            }
            else
            {
                EcoBuilding2.color = ResourcesTextNotFinanced;
            }
        }

        //Social
        if (_betControl.FindIndexFromResource("Social", _role) != -1)
        {
            if (IsBet(_betControl, "Social", _role, _building+1))
            {
                SocialBuilding2.color = urbaBlue;
            }
            else
            {
                SocialBuilding2.color = ResourcesTextNotFinanced;
            }
        }

        //Building3
        //Political
        if (_betControl.FindIndexFromResource("Political", _role) != -1)
        {
            if (IsBet(_betControl, "Political", _role, _building + 2))
            {
                PoliticalBuilding3.color = urbaBlue;
            }
            else
            {
                PoliticalBuilding3.color = ResourcesTextNotFinanced;
            }
        }

        //Economical
        if (_betControl.FindIndexFromResource("Economical", _role) != -1)
        {
            if (IsBet(_betControl, "Economical", _role, _building + 2))
            {
                EcoBuilding3.color = urbaBlue;
            }
            else
            {
                EcoBuilding3.color = ResourcesTextNotFinanced;
            }
        }

        //Social
        if (_betControl.FindIndexFromResource("Social", _role) != -1)
        {
            if (IsBet(_betControl, "Social", _role, _building + 2))
            {
                SocialBuilding3.color = urbaBlue;
            }
            else
            {
                SocialBuilding3.color = ResourcesTextNotFinanced;
            }
        }

        //Building4
        //Political
        if (_betControl.FindIndexFromResource("Political", _role) != -1)
        {
            if (IsBet(_betControl, "Political", _role, _building + 3))
            {
                PoliticalBuilding4.color = urbaBlue;
            }
            else
            {
                PoliticalBuilding4.color = ResourcesTextNotFinanced;
            }
        }

        //Economical
        if (_betControl.FindIndexFromResource("Economical", _role) != -1)
        {
            if (IsBet(_betControl, "Economical", _role, _building + 3))
            {
                EcoBuilding4.color = urbaBlue;
            }
            else
            {
                EcoBuilding4.color = ResourcesTextNotFinanced;
            }
        }

        //Social
        if (_betControl.FindIndexFromResource("Social", _role) != -1)
        {
            if (IsBet(_betControl, "Social", _role, _building + 3))
            {
                SocialBuilding4.color = urbaBlue;
            }
            else
            {
                SocialBuilding4.color = ResourcesTextNotFinanced;
            }
        }

        //Building5
        //Political
        if (_betControl.FindIndexFromResource("Political", _role) != -1)
        {
            if (IsBet(_betControl, "Political", _role, _building + 4))
            {
                PoliticalBuilding5.color = urbaBlue;
            }
            else
            {
                PoliticalBuilding5.color = ResourcesTextNotFinanced;
            }
        }

        //Economical
        if (_betControl.FindIndexFromResource("Economical", _role) != -1)
        {
            if (IsBet(_betControl, "Economical", _role, _building + 4))
            {
                EcoBuilding5.color = urbaBlue;
            }
            else
            {
                EcoBuilding5.color = ResourcesTextNotFinanced;
            }
        }

        //Social
        if (_betControl.FindIndexFromResource("Social", _role) != -1)
        {
            if (IsBet(_betControl, "Social", _role, _building + 4))
            {
                SocialBuilding5.color = urbaBlue;
            }
            else
            {
                SocialBuilding5.color = ResourcesTextNotFinanced;
            }
        }


    }

    /// <summary>
    /// Tells if playerLocal has some resources bet on the building
    /// </summary>
    /// <param name="_betControl">so we can have playerBets</param>
    /// <param name="_resource">"Economical", "Political" or "Social"</param>
    /// <param name="_role">so we can know which are the resources the player can use</param>
    /// <param name="_building">the building we want to know if it is bet by the player</param>
    /// <returns></returns>
    public bool IsBet(BetControl _betControl, string _resource, Role _role, int _building)
    {
        bool _res;
        if (_betControl.FindIndexFromResource(_resource, _role) > -1)
        {
            //TODO: vérifier player bet et renvoyer true si > 0
            if (_betControl.playerBets[_building, _betControl.FindIndexFromResource(_resource, _role)] > 0)
            {
                _res = true;
            }
            else
            {
                _res = false;
            }
        }
        else
        {
            _res = false;
        }
        return _res;
    }


    /// <summary>
    /// When a resource on a building is fully completed, its layout is in green.
    /// But if a building is fully financed, then it's transparent.
    /// </summary>
    public void SetResourceFramesInGreenWhenCompleted()
    {
        Game _game = GameManager.singleton.game;
        BetControl _betControl = GameObject.Find("playerLocal").GetComponent<BetControl>();

        Color _transparent = new Color(0f, 0f, 0f, 0f);

        //Building1
        
        if (_betControl.IsFinanced(_game.Market[0])) //the buildings is fully financed
        {
            PoliticalFrameBuilding1.GetComponent<Image>().color = _transparent;
            EcoFrameBuilding1.GetComponent<Image>().color = _transparent;
            SocialFrameBuilding1.GetComponent<Image>().color = _transparent;
        }
        else
        {
            //Political
            if (_betControl.ResourceIsCompleted(_game.Market[0].FinancePolitical, _game.Market[0].Political ))
            {
                PoliticalFrameBuilding1.GetComponent<Image>().color = Green2;
            }
            else
            {
                PoliticalFrameBuilding1.GetComponent<Image>().color = _transparent;
            }

            //Economical
            if (_betControl.ResourceIsCompleted(_game.Market[0].FinanceEconomical, _game.Market[0].Economical))
            {
                EcoFrameBuilding1.GetComponent<Image>().color = Green2;
            }
            else
            {
                EcoFrameBuilding1.GetComponent<Image>().color = _transparent;
            }

            //Social
            if (_betControl.ResourceIsCompleted(_game.Market[0].FinanceSocial, _game.Market[0].Social))
            {
                SocialFrameBuilding1.GetComponent<Image>().color = Green2;
            }
            else
            {
                SocialFrameBuilding1.GetComponent<Image>().color = _transparent;
            }
        }

        //Building2
        if (_betControl.IsFinanced(_game.Market[1]))
        {
            PoliticalFrameBuilding2.GetComponent<Image>().color = _transparent;
            EcoFrameBuilding2.GetComponent<Image>().color = _transparent;
            SocialFrameBuilding2.GetComponent<Image>().color = _transparent;
        }
        else
        {
            //Political
            if (_betControl.ResourceIsCompleted(_game.Market[1].FinancePolitical, _game.Market[1].Political))
            {
                PoliticalFrameBuilding2.GetComponent<Image>().color = Green2;
            }
            else
            {
                PoliticalFrameBuilding2.GetComponent<Image>().color = _transparent;
            }

            //Economical
            if (_betControl.ResourceIsCompleted(_game.Market[1].FinanceEconomical, _game.Market[1].Economical))
            {
                EcoFrameBuilding2.GetComponent<Image>().color = Green2;
            }
            else
            {
                EcoFrameBuilding2.GetComponent<Image>().color = _transparent;
            }

            //Social
            if (_betControl.ResourceIsCompleted(_game.Market[1].FinanceSocial, _game.Market[1].Social))
            {
                SocialFrameBuilding2.GetComponent<Image>().color = Green2;
            }
            else
            {
                SocialFrameBuilding2.GetComponent<Image>().color = _transparent;
            }
        }

        //Building3
        if (_betControl.IsFinanced(_game.Market[2]))
        {
            PoliticalFrameBuilding3.GetComponent<Image>().color = _transparent;
            EcoFrameBuilding3.GetComponent<Image>().color = _transparent;
            SocialFrameBuilding3.GetComponent<Image>().color = _transparent;
        }
        else
        {
            //Political
            if (_betControl.ResourceIsCompleted(_game.Market[2].FinancePolitical, _game.Market[2].Political))
            {
                PoliticalFrameBuilding3.GetComponent<Image>().color = Green2;
            }
            else
            {
                PoliticalFrameBuilding3.GetComponent<Image>().color = _transparent;
            }

            //Economical
            if (_betControl.ResourceIsCompleted(_game.Market[2].FinanceEconomical, _game.Market[2].Economical))
            {
                EcoFrameBuilding3.GetComponent<Image>().color = Green2;
            }
            else
            {
                EcoFrameBuilding3.GetComponent<Image>().color = _transparent;
            }

            //Social
            if (_betControl.ResourceIsCompleted(_game.Market[2].FinanceSocial, _game.Market[2].Social))
            {
                SocialFrameBuilding3.GetComponent<Image>().color = Green2;
            }
            else
            {
                SocialFrameBuilding3.GetComponent<Image>().color = _transparent;
            }
        }

        //Building4
        if (_betControl.IsFinanced(_game.Market[3]))
        {
            PoliticalFrameBuilding4.GetComponent<Image>().color = _transparent;
            EcoFrameBuilding4.GetComponent<Image>().color = _transparent;
            SocialFrameBuilding4.GetComponent<Image>().color = _transparent;
        }
        else
        {
            //Political
            if (_betControl.ResourceIsCompleted(_game.Market[3].FinancePolitical, _game.Market[3].Political))
            {
                PoliticalFrameBuilding4.GetComponent<Image>().color = Green2;
            }
            else
            {
                PoliticalFrameBuilding4.GetComponent<Image>().color = _transparent;
            }

            //Economical
            if (_betControl.ResourceIsCompleted(_game.Market[3].FinanceEconomical, _game.Market[3].Economical))
            {
                EcoFrameBuilding4.GetComponent<Image>().color = Green2;
            }
            else
            {
                EcoFrameBuilding4.GetComponent<Image>().color = _transparent;
            }

            //Social
            if (_betControl.ResourceIsCompleted(_game.Market[3].FinanceSocial, _game.Market[3].Social))
            {
                SocialFrameBuilding4.GetComponent<Image>().color = Green2;
            }
            else
            {
                SocialFrameBuilding4.GetComponent<Image>().color = _transparent;
            }
        }

        //Building5
        if (_betControl.IsFinanced(_game.Market[4]))
        {
            PoliticalFrameBuilding5.GetComponent<Image>().color = _transparent;
            EcoFrameBuilding5.GetComponent<Image>().color = _transparent;
            SocialFrameBuilding5.GetComponent<Image>().color = _transparent;
        }
        else
        {
            //Political
            if (_betControl.ResourceIsCompleted(_game.Market[4].FinancePolitical, _game.Market[4].Political))
            {
                PoliticalFrameBuilding5.GetComponent<Image>().color = Green2;
            }
            else
            {
                PoliticalFrameBuilding5.GetComponent<Image>().color = _transparent;
            }

            //Economical
            if (_betControl.ResourceIsCompleted(_game.Market[4].FinanceEconomical, _game.Market[4].Economical))
            {
                EcoFrameBuilding5.GetComponent<Image>().color = Green2;
            }
            else
            {
                EcoFrameBuilding5.GetComponent<Image>().color = _transparent;
            }

            //Social
            if (_betControl.ResourceIsCompleted(_game.Market[4].FinanceSocial, _game.Market[4].Social))
            {
                SocialFrameBuilding5.GetComponent<Image>().color = Green2;
            }
            else
            {
                SocialFrameBuilding5.GetComponent<Image>().color = _transparent;
            }
        }


    }

    /// <summary>
    /// Sets the name of the building in green if it is financed
    /// </summary>
    public void SetBuildingNameInGreenWhenFinanced()
    {
        Game _game = GameManager.singleton.game;
        BetControl _betControl = GameObject.Find("playerLocal").GetComponent<BetControl>();

        //Building1
        if (_betControl.IsFinanced(_game.Market[0]))
        {
            buildingName1.color = buildingNameGreen;
        }
        else
        {
            buildingName1.color = NameBuildingNotFinanced;
        }

        //Building2
        if (_betControl.IsFinanced(_game.Market[1]))
        {
            buildingName2.color = buildingNameGreen;
        }
        else
        {
            buildingName2.color = NameBuildingNotFinanced;
        }

        //Building3
        if (_betControl.IsFinanced(_game.Market[2]))
        {
            buildingName3.color = buildingNameGreen;
        }
        else
        {
            buildingName3.color = NameBuildingNotFinanced;
        }

        //Building4
        if (_betControl.IsFinanced(_game.Market[3]))
        {
            buildingName4.color = buildingNameGreen;
        }
        else
        {
            buildingName4.color = NameBuildingNotFinanced;
        }

        //Building5
        if (_betControl.IsFinanced(_game.Market[4]))
        {
            buildingName5.color = buildingNameGreen;
        }
        else
        {
            buildingName5.color = NameBuildingNotFinanced;
        }

    }


    /// <summary>
    /// Fills the panel where the player can bet on a given building
    /// </summary>
    public void FillBetPanel()
    {
        BetControl _betControl = GameObject.Find("playerLocal").GetComponent<BetControl>();
        Building _building = GameManager.singleton.game.Market[_betControl.numBuildingBet];
        Role _role = GameObject.Find("playerLocal").GetComponent<Player>().role;
        BetNameBuilding.text = _building.name;
        BetNameBuilding2.text = _building.name;
        BetDescBuilding.text = _building.description;
        attractScore.text = _building.attractScore.ToString();
        EnviScore.text = _building.enviScore.ToString();
        FluidScore.text = _building.fluidScore.ToString();

        #region Finance
        //TODO: blue text when player bet on it
        //regarder le bet du player dans playerBets[numBuilding,ressource]
        //Si >0 ==> texte en bleu
        //Sinon texte en gris
        if (_role.ressource1.Equals("Economical"))
        {
            ressource1.text = _building.FinanceEconomical + "/" + _building.Economical;
            ressource1image.GetComponent<Image>().sprite = EcoImage;
            ColorResourceOnBetPanel(ressource1,_betControl,_building, _role, _role.ressource1);
        }
        else if (_role.ressource1.Equals("Political"))
        {
            ressource1.text = _building.FinancePolitical + "/" + _building.Political;
            ressource1image.GetComponent<Image>().sprite = PoliImage;
            ColorResourceOnBetPanel(ressource1, _betControl, _building, _role, _role.ressource1);
        }
        else
        {
            ressource1.text = _building.FinanceSocial + "/" + _building.Social;
            ressource1image.GetComponent<Image>().sprite = SocialImage;
            ColorResourceOnBetPanel(ressource1, _betControl, _building, _role, _role.ressource1);
        }
        if (_role.ressource2.Equals("Economical"))
        {
            ressource2.text = _building.FinanceEconomical + "/" + _building.Economical;
            ressource2image.GetComponent<Image>().sprite = EcoImage;
            ColorResourceOnBetPanel(ressource2, _betControl, _building, _role, _role.ressource2);
        }
        else if (_role.ressource2.Equals("Political"))
        {
            ressource2.text = _building.FinancePolitical + "/" + _building.Political;
            ressource2image.GetComponent<Image>().sprite = PoliImage;
            ColorResourceOnBetPanel(ressource2, _betControl, _building, _role, _role.ressource2);
        }
        else
        {
            ressource2.text = _building.FinanceSocial + "/" + _building.Social;
            ressource2image.GetComponent<Image>().sprite = SocialImage;
            ColorResourceOnBetPanel(ressource2, _betControl, _building, _role, _role.ressource2);
        }
        #endregion
        if (_building.attractScore < 0)
        {
            AttractImageBuilding.GetComponent<Image>().color = urbaRed;
            attractScore.color = urbaRed;
        }
        else if (_building.attractScore == 0)
        {
            AttractImageBuilding.GetComponent<Image>().color = urbaGrey;
            attractScore.color = urbaGrey;
        }
        else
        {
            AttractImageBuilding.GetComponent<Image>().color = urbaGreen;
            attractScore.color = urbaGreen;
        }
        if (_building.fluidScore < 0)
        {
            FluidImageBuilding.GetComponent<Image>().color = urbaRed;
            FluidScore.color = urbaRed;
        }
        else if (_building.fluidScore == 0)
        {
            FluidImageBuilding.GetComponent<Image>().color = urbaGrey;
            FluidScore.color = urbaGrey;
        }
        else
        {
            FluidImageBuilding.GetComponent<Image>().color = urbaGreen;
            FluidScore.color = urbaGreen;
        }
        if (_building.enviScore < 0)
        {
            EnviImageBuilding.GetComponent<Image>().color = urbaRed;
            EnviScore.color = urbaRed;
        }
        else if (_building.enviScore == 0)
        {
            EnviImageBuilding.GetComponent<Image>().color = urbaGrey;
            EnviScore.color = urbaGrey;
        }
        else
        {
            EnviImageBuilding.GetComponent<Image>().color = urbaGreen;
            EnviScore.color = urbaGreen;
        }

    }

    private void ColorResourceOnBetPanel(TextMeshProUGUI _ressourceText, BetControl _betControl, Building _building, Role _role, string _resourceInRole)
    {
        //TODO: blue text when player bet on it
        //regarder le bet du player dans playerBets[numBuilding,index de la ressource dans playerBets]
        //Si >0 ==> texte en bleu
        //Sinon texte en gris
        int _indexResource = _betControl.FindIndexFromResource(_resourceInRole,_role);
        //_betControl.FindIndexFromResource(_resource, _role)
        if (_indexResource == -1)
        {
            _ressourceText.color = urbaGrey;
        }
        else
        {
            if (_betControl.playerBets[_betControl.numBuildingBet,_indexResource] > 0)
            {
                _ressourceText.color = urbaBlue;
            }
            else
            {
                _ressourceText.color = urbaGrey;
            }
        }
    }
}
