using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSettingsClose : MonoBehaviour
{
    public GameObject panel;

    private PopulateBuildingsSettingsList pop;


    public void CloseBuildingSettingsPanel()
    {
        panel.SetActive(false);
        pop.Init();
    }
}
