using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeNumBuildingsToEnd : MonoBehaviour
{

    public void ChangeNbBuildingsToEnd(string _NumBuilding)
    {
        
        NextTurnButton.NumberBuildingsToEnd = Convert.ToInt16(_NumBuilding);
    }
}
