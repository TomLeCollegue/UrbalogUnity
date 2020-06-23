using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// FillsPlayerView with all the informations about the current state of the game.
/// </summary>
public class FillPlayerView : MonoBehaviour
{
    #region Colors
    Color urbaGreen = new Color(0.1f, 0.3f, 0.0f);
    Color urbaRed = new Color(0.6f, 0.0f, 0.0f);
    Color urbaBlue = new Color(0.0f,0.3f,0.9f);
    Color resourceFrameLightGreen = new Color(0.47f,0.73f,0.42f);
    Color resourceFrameLightGrey = new Color(0.68f, 0.68f, 0.68f);
    Color buildingNameGreen = new Color(0.00f, 1.00f, 0.22f);
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

    //For the actions that needs to be updated only once a turn
    public bool isAlreadyUpdated = false;


    // Update is called once per frame
    void Update()
    {
        FillPLayerViewInfo();
        ShowWherePlayerLocalBet();
        SetResourceFramesInGreenWhenCompleted();
        SetBuildingNameInGreenWhenFinanced();

        //is needed only once a turn
        if (!isAlreadyUpdated)
        {
            ColorImpact();
            FillBuildingsImpact();
            turnNumberText.text = "Num Tour : " + GameManager.singleton.game.turnNumber.ToString();
            isAlreadyUpdated = true;
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
                PoliticalBuilding1.color = Color.black;
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
                EcoBuilding1.color = Color.black;
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
                SocialBuilding1.color = Color.black;
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
                PoliticalBuilding2.color = Color.black;
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
                EcoBuilding2.color = Color.black;
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
                SocialBuilding2.color = Color.black;
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
                PoliticalBuilding3.color = Color.black;
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
                EcoBuilding3.color = Color.black;
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
                SocialBuilding3.color = Color.black;
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
                PoliticalBuilding4.color = Color.black;
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
                EcoBuilding4.color = Color.black;
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
                SocialBuilding4.color = Color.black;
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
                PoliticalBuilding5.color = Color.black;
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
                EcoBuilding5.color = Color.black;
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
                SocialBuilding5.color = Color.black;
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
    /// </summary>
    public void SetResourceFramesInGreenWhenCompleted()
    {
        //fluidBuilding3Image.GetComponent<Image>().color = Color.black;
        Game _game = GameManager.singleton.game;
        BetControl _betControl = GameObject.Find("playerLocal").GetComponent<BetControl>();

        //Building1
        //Political
        if (_betControl.ResourceIsCompleted(_game.Market[0].FinancePolitical, _game.Market[0].Political ))
        {
            PoliticalFrameBuilding1.GetComponent<Image>().color = resourceFrameLightGreen;
        }
        else
        {
            PoliticalFrameBuilding1.GetComponent<Image>().color = resourceFrameLightGrey;
        }

        //Economical
        if (_betControl.ResourceIsCompleted(_game.Market[0].FinanceEconomical, _game.Market[0].Economical))
        {
            EcoFrameBuilding1.GetComponent<Image>().color = resourceFrameLightGreen;
        }
        else
        {
            EcoFrameBuilding1.GetComponent<Image>().color = resourceFrameLightGrey;
        }

        //Social
        if (_betControl.ResourceIsCompleted(_game.Market[0].FinanceSocial, _game.Market[0].Social))
        {
            SocialFrameBuilding1.GetComponent<Image>().color = resourceFrameLightGreen;
        }
        else
        {
            SocialFrameBuilding1.GetComponent<Image>().color = resourceFrameLightGrey;
        }

        //Building2
        //Political
        if (_betControl.ResourceIsCompleted(_game.Market[1].FinancePolitical, _game.Market[1].Political))
        {
            PoliticalFrameBuilding2.GetComponent<Image>().color = resourceFrameLightGreen;
        }
        else
        {
            PoliticalFrameBuilding2.GetComponent<Image>().color = resourceFrameLightGrey;
        }

        //Economical
        if (_betControl.ResourceIsCompleted(_game.Market[1].FinanceEconomical, _game.Market[1].Economical))
        {
            EcoFrameBuilding2.GetComponent<Image>().color = resourceFrameLightGreen;
        }
        else
        {
            EcoFrameBuilding2.GetComponent<Image>().color = resourceFrameLightGrey;
        }

        //Social
        if (_betControl.ResourceIsCompleted(_game.Market[1].FinanceSocial, _game.Market[1].Social))
        {
            SocialFrameBuilding2.GetComponent<Image>().color = resourceFrameLightGreen;
        }
        else
        {
            SocialFrameBuilding2.GetComponent<Image>().color = resourceFrameLightGrey;
        }

        //Building3
        //Political
        if (_betControl.ResourceIsCompleted(_game.Market[2].FinancePolitical, _game.Market[2].Political))
        {
            PoliticalFrameBuilding3.GetComponent<Image>().color = resourceFrameLightGreen;
        }
        else
        {
            PoliticalFrameBuilding3.GetComponent<Image>().color = resourceFrameLightGrey;
        }

        //Economical
        if (_betControl.ResourceIsCompleted(_game.Market[2].FinanceEconomical, _game.Market[2].Economical))
        {
            EcoFrameBuilding3.GetComponent<Image>().color = resourceFrameLightGreen;
        }
        else
        {
            EcoFrameBuilding3.GetComponent<Image>().color = resourceFrameLightGrey;
        }

        //Social
        if (_betControl.ResourceIsCompleted(_game.Market[2].FinanceSocial, _game.Market[2].Social))
        {
            SocialFrameBuilding3.GetComponent<Image>().color = resourceFrameLightGreen;
        }
        else
        {
            SocialFrameBuilding3.GetComponent<Image>().color = resourceFrameLightGrey;
        }

        //Building4
        //Political
        if (_betControl.ResourceIsCompleted(_game.Market[3].FinancePolitical, _game.Market[3].Political))
        {
            PoliticalFrameBuilding4.GetComponent<Image>().color = resourceFrameLightGreen;
        }
        else
        {
            PoliticalFrameBuilding4.GetComponent<Image>().color = resourceFrameLightGrey;
        }

        //Economical
        if (_betControl.ResourceIsCompleted(_game.Market[3].FinanceEconomical, _game.Market[3].Economical))
        {
            EcoFrameBuilding4.GetComponent<Image>().color = resourceFrameLightGreen;
        }
        else
        {
            EcoFrameBuilding4.GetComponent<Image>().color = resourceFrameLightGrey;
        }

        //Social
        if (_betControl.ResourceIsCompleted(_game.Market[3].FinanceSocial, _game.Market[3].Social))
        {
            SocialFrameBuilding4.GetComponent<Image>().color = resourceFrameLightGreen;
        }
        else
        {
            SocialFrameBuilding4.GetComponent<Image>().color = resourceFrameLightGrey;
        }

        //Building5
        //Political
        if (_betControl.ResourceIsCompleted(_game.Market[4].FinancePolitical, _game.Market[4].Political))
        {
            PoliticalFrameBuilding5.GetComponent<Image>().color = resourceFrameLightGreen;
        }
        else
        {
            PoliticalFrameBuilding5.GetComponent<Image>().color = resourceFrameLightGrey;
        }

        //Economical
        if (_betControl.ResourceIsCompleted(_game.Market[4].FinanceEconomical, _game.Market[4].Economical))
        {
            EcoFrameBuilding5.GetComponent<Image>().color = resourceFrameLightGreen;
        }
        else
        {
            EcoFrameBuilding5.GetComponent<Image>().color = resourceFrameLightGrey;
        }

        //Social
        if (_betControl.ResourceIsCompleted(_game.Market[4].FinanceSocial, _game.Market[4].Social))
        {
            SocialFrameBuilding5.GetComponent<Image>().color = resourceFrameLightGreen;
        }
        else
        {
            SocialFrameBuilding5.GetComponent<Image>().color = resourceFrameLightGrey;
        }


    }


    public void SetBuildingNameInGreenWhenFinanced()
    {
        Game _game = GameManager.singleton.game;
        BetControl _betControl = GameObject.Find("playerLocal").GetComponent<BetControl>();

        //Building1
        if (_betControl.isFinanced(_game.Market[0]))
        {
            buildingName1.color = buildingNameGreen;
        }
        else
        {
            buildingName1.color = Color.white;
        }

        //Building2
        if (_betControl.isFinanced(_game.Market[1]))
        {
            buildingName2.color = buildingNameGreen;
        }
        else
        {
            buildingName2.color = Color.white;
        }

        //Building3
        if (_betControl.isFinanced(_game.Market[2]))
        {
            buildingName3.color = buildingNameGreen;
        }
        else
        {
            buildingName3.color = Color.white;
        }

        //Building4
        if (_betControl.isFinanced(_game.Market[3]))
        {
            buildingName4.color = buildingNameGreen;
        }
        else
        {
            buildingName4.color = Color.white;
        }

        //Building5
        if (_betControl.isFinanced(_game.Market[4]))
        {
            buildingName5.color = buildingNameGreen;
        }
        else
        {
            buildingName5.color = Color.white;
        }

    }
}
