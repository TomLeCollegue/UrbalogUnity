using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject form1;
    public GameObject form2;
    public GameObject form3;

    public void DisplayForm1()
    {
        mainMenu.SetActive(false);
        form1.SetActive(true);
    }

    public void DisplayForm2()
    {
        form1.SetActive(false);
        form2.SetActive(true);
    }

    public void DisplayForm3()
    {
        form2.SetActive(false);
        form3.SetActive(true);
    }

}
