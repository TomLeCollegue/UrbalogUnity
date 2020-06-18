using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CityScoreButton : MonoBehaviour
{
    public GameObject Panel;

    public TextMeshProUGUI Attract;
    public TextMeshProUGUI Envi;
    public TextMeshProUGUI Fluid;

    //public Button NextTurnButton;
    public void OpenPanel()
    {
        if (Panel != null)
        {
            Panel.SetActive(true);
            UpdateCityScorePanel();
        }
    }

    public void ClosePanel()
    {
        if (Panel != null)
        {
            Panel.SetActive(false);
        }
    }

    /// <summary>
    /// Opens the panel if closed and opens it if closed
    /// </summary>
    public void TogglePanel()
    {
        bool _isActive = Panel.activeSelf;

        Panel.SetActive(!_isActive);
        if (!_isActive)
        {
            UpdateCityScorePanel();
        }
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

    }

}
