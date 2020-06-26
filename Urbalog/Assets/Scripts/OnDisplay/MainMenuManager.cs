using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject PlayerMenu;
    public GameObject HostMenu;

    public void DisplayPlayerMenu()
    {
        MainMenu.SetActive(false);
        HostMenu.SetActive(false);
        PlayerMenu.SetActive(true);
    }
    public void DisplayHostMenu()
    {
        MainMenu.SetActive(false);
        HostMenu.SetActive(true);
        PlayerMenu.SetActive(false);
    }
    public void DisplayMainMenu()
    {
        MainMenu.SetActive(true);
        HostMenu.SetActive(false);
        PlayerMenu.SetActive(false);
    }

}
