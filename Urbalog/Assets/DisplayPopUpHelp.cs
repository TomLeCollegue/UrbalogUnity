using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPopUpHelp : MonoBehaviour
{
    public GameObject PopUp;


    public void OpenPopUp()
    {
        PopUp.SetActive(true);
    }
    public void ClosePopUp()
    {
        PopUp.SetActive(false);
    }
}
