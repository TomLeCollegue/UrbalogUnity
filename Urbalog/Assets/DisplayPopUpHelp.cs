using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayPopUpHelp : MonoBehaviour
{
    public GameObject PopUp;

    //Help PopUp
    public TextMeshProUGUI HelpEnviText;
    public TextMeshProUGUI HelpFluidText;
    public TextMeshProUGUI HelpAttractText;
    public TextMeshProUGUI HelpLogiText;
    public TextMeshProUGUI HelpEcoText;
    public TextMeshProUGUI HelpPoliText;
    public TextMeshProUGUI HelpSocialText;

    public void OpenPopUp()
    {
        PopUp.SetActive(true);
        FillHelp();
    }

    /// <summary>
    /// Fills the help popup with correct text
    /// </summary>
    public void FillHelp()
    {
        HelpEnviText.text = Language.HELP_ENVI;
        HelpFluidText.text = Language.HELP_FLUID;
        HelpAttractText.text = Language.HELP_ATTRACT;
        HelpLogiText.text = Language.HELP_LOGI;
        HelpEcoText.text = Language.HELP_ECO;
        HelpPoliText.text = Language.HELP_POLI;
        HelpSocialText.text = Language.HELP_SOCIAL;
    }
    public void ClosePopUp()
    {
        PopUp.SetActive(false);
    }
}
