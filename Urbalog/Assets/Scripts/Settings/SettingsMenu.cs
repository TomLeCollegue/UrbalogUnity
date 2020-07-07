using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public GameObject MainSettingsMenu;
    public GameObject BuildingsSettingsMenu;
    public GameObject BuildingsListPanel;


    #region buildingSettingsPanel
    public GameObject panel;

    public TextMeshProUGUI buildingName;
    public TextMeshProUGUI descriptionPlaceholder;
    
    public TextMeshProUGUI ecoPlaceholder;
    public TextMeshProUGUI socPlaceholder;
    public TextMeshProUGUI poliPlaceholder;
    
    public TextMeshProUGUI enviPlaceholder;
    public TextMeshProUGUI fluidPlaceholder;
    public TextMeshProUGUI attractPlaceholder;
    public TextMeshProUGUI logisticPlaceholder;
    
    public TextMeshProUGUI logisticDescriptionPlaceholder;

    #endregion



    public void GoToSettingsScene()
    {
        SceneManager.LoadScene("SettingsScene");
    }

    public void GoBackToLobby()
    {
        SceneManager.LoadScene("LobbyRework");
    }

    public void DisplayBuildingsSettingsMenu()
    {
        MainSettingsMenu.SetActive(false);
        BuildingsListPanel.SetActive(false);
        BuildingsSettingsMenu.SetActive(true);
    }
    public void DisplaySettingsMenu()
    {
        BuildingsListPanel.SetActive(false);
        MainSettingsMenu.SetActive(true);
        BuildingsSettingsMenu.SetActive(false);
    }

    public void DisplayBuildingsList()
    {
        BuildingsListPanel.SetActive(true);
        MainSettingsMenu.SetActive(false);
        BuildingsSettingsMenu.SetActive(false);
    }

    /// <summary>
    /// When a building in the buildings list is clicked, a panel opens so we can change its infos
    /// It prints the current infos in the placeholder.
    /// The changed are made only when the validate button is clicked.
    /// </summary>
    public void OpenBuildingSettingsPanel(Building _building)
    {
        if (panel != null)
        {
            panel.SetActive(true);
            buildingName.text = _building.name;
            descriptionPlaceholder.text = _building.description;
            
            ecoPlaceholder.text = _building.Economical.ToString();
            socPlaceholder.text = _building.Social.ToString();
            poliPlaceholder.text = _building.Political.ToString();

            enviPlaceholder.text = _building.enviScore.ToString();
            fluidPlaceholder.text = _building.fluidScore.ToString();
            attractPlaceholder.text = _building.attractScore.ToString();
            logisticPlaceholder.text = _building.logisticScore.ToString();
            
            logisticDescriptionPlaceholder.text = _building.logisticDescription;

        }
    }


    /// <summary>
    /// When som
    /// </summary>
    /// <param name="_descBuilding"></param>
    public void ChangeDescriptionBuilding(string _descBuilding)
    {
        Game _game = GameManager.singleton.game;
        Building[] _buildings = _game.pioche.ToArray();


        //NextTurnButton.NumberBuildingsToEnd = Convert.ToInt16(_NumBuilding);
    }

}
