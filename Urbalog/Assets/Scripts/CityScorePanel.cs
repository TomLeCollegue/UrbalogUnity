using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CityScorePanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCityScorePanel()
    {
        Game _game = GameManager.singleton.game;

        Debug.Log("1CityScorePanel : Attract.text");
        
        TextMeshProUGUI _Attract = GameObject.Find("AttractCityScoreText").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI _Envi = GameObject.Find("EnviCityScoreText").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI _Fluid = GameObject.Find("FluidCityScoreText").GetComponent<TextMeshProUGUI>();

        _Attract.text = _game.cityAttractiveness.ToString();
        _Envi.text = _game.cityEnvironment.ToString();
        _Fluid.text = _game.cityFluidity.ToString();

        Debug.Log("CityScorePanel : Attract.text" + _Attract.text);

    }

}
