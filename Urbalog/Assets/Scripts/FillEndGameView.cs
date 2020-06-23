﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FillEndGameView : MonoBehaviour
{
    public Transform buildingsContainer;
    public Transform buildingsTemplate;
    public TextMeshProUGUI AttractCity;
    public TextMeshProUGUI EnviCity;
    public TextMeshProUGUI FluidCity;

    // Start is called before the first frame update
    void Start()
    {
        FillEndGameScoreInfo();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    //awake is initialized after all objects are initialized
    private void Awake()
    {
        buildingsContainer = transform.Find("BuildingEntryContainer");
        buildingsTemplate = buildingsContainer.Find("BuildingEntryTemplate");

        buildingsTemplate.gameObject.SetActive(false);

        for(int i = 0; i <= 5; i++)
        {
            Transform entryTransform = Instantiate(buildingsTemplate, buildingsContainer);
            entryTransform.gameObject.SetActive(true);
            entryTransform.Find("NameEntry").GetComponent<Text>().text = GameManager.singleton.game.BuildingsBuilt[i].name;
            entryTransform.Find("DescriptionEntry").GetComponent<Text>().text = GameManager.singleton.game.BuildingsBuilt[i].description;
        }
    }

    private void FillEndGameScoreInfo()
    {
        Game _game = GameManager.singleton.game;

        AttractCity.text = _game.cityAttractiveness.ToString();
        EnviCity.text = _game.cityEnvironment.ToString();
        FluidCity.text = _game.cityFluidity.ToString();

    }
}
