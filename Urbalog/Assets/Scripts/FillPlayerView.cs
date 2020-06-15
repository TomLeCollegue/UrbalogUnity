using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FillPlayerView : MonoBehaviour
{
    public Button building1Button;
    public TextMeshProUGUI PoliticalBuilding1;
    public TextMeshProUGUI EcoBuilding1;
    public TextMeshProUGUI SocialBuilding1;
    public TextMeshProUGUI AttractBuilding1;
    public TextMeshProUGUI EnviBuilding1;
    public TextMeshProUGUI FluidBuilding1;

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


    }
}
