using UnityEngine;

public class DisplayFormView : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Form1;
    public GameObject Form2;
    public GameObject Form3;

    public void BackPressMenu()
    {
        MainMenu.SetActive(true);
        Form1.SetActive(false);
        Form2.SetActive(false);
        Form3.SetActive(false);
    }

    public void DisplayForm1()
    {
        MainMenu.SetActive(false);
        Form1.SetActive(true);
        Form2.SetActive(false);
        Form3.SetActive(false);
    }

    public void DisplayForm2()
    {
        MainMenu.SetActive(false);
        Form1.SetActive(false);
        Form2.SetActive(true);
        Form3.SetActive(false);
    }

    public void DisplayForm3()
    {
        MainMenu.SetActive(false);
        Form1.SetActive(false);
        Form2.SetActive(false);
        Form3.SetActive(true);
    }

    public void SkipForm()
    {
        MainMenu.SetActive(false);
        Form1.SetActive(false);
        Form2.SetActive(false);
        Form3.SetActive(false);
    }

}
