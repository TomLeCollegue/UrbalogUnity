using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildingsBuiltListItem : MonoBehaviour
{
    public TextMeshProUGUI nameBuilding;
    public TextMeshProUGUI descripLogBuilding;
    public TextMeshProUGUI logScoreBuilding;

    public void RenameBuilding(string _nameBuilding)
    {
       nameBuilding.text = _nameBuilding;
    }
    public void RenameDescripLog(string _descripLogBuilding)
    {
        descripLogBuilding.text = _descripLogBuilding;
    }
    public void RenameScoreLogstring(int _logScoreBuilding)
    {
        logScoreBuilding.text = _logScoreBuilding.ToString();
    }
}
