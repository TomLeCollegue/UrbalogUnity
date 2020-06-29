using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUpScoreManager : MonoBehaviour
{
    public GameObject PopUpWin;
    public GameObject PopUpLose;

    public TextMeshProUGUI HoldTextWin;
    public TextMeshProUGUI ImproveTextWin;
    public Image HoldImageWin;
    public Image ImproveImageWin;

    public TextMeshProUGUI HoldTextLose;
    public TextMeshProUGUI ImproveTextLose;
    public Image HoldImageLose;
    public Image ImproveImageLose;

    public Sprite EnviSprite;
    public Sprite AttractSprite;
    public Sprite FluidSprite;

    private void Update()
    {
        FillPopUpLose();
        FillPopUpWin();
    }

    public void OpenPopUpWin()
    {
        PopUpWin.SetActive(true);
        FillPopUpWin();
    }
    public void OpenPopUpLose()
    {
        PopUpLose.SetActive(true);
        FillPopUpLose();
    }
    public void ClosePopUp()
    {
        PopUpWin.SetActive(false);
        PopUpLose.SetActive(false);
    }

    public void FillPopUpWin()
    {
        Role role = GameObject.Find("playerLocal").GetComponent<Player>().role;
        if (role.hold.Equals("Environment"))
        {
            HoldImageWin.GetComponent<Image>().sprite = EnviSprite;
            HoldTextWin.text = "Environnement Maitrisé";
            Debug.Log("Environment");
        }
        else if (role.hold.Equals("Fluidity"))
        {
            HoldImageWin.GetComponent<Image>().sprite = FluidSprite;
            HoldTextWin.text = "Fluidité Maitrisée";
            Debug.Log("Fluid");
        }
        else
        {
            HoldImageWin.GetComponent<Image>().sprite = AttractSprite;
            HoldTextWin.text = "Attractivité Maitrisée";
            Debug.Log("Attract");
        }
        
        if (role.improve.Equals("Environment"))
        {
            ImproveImageWin.GetComponent<Image>().sprite = EnviSprite;
            ImproveTextWin.text = "Environnement Amélioré";
            Debug.Log("Environment");
        }
        else if(role.improve.Equals("Fluidity"))
        {
            ImproveImageWin.GetComponent<Image>().sprite = FluidSprite;
            ImproveTextWin.text = "Fluidité Améliorée";
            Debug.Log("Fluid");
        }
        else
        {
            ImproveImageWin.GetComponent<Image>().sprite = AttractSprite;
            ImproveTextWin.text = "Attractivité Améliorée";
            Debug.Log("Attract");
        }
        
    }

    public void FillPopUpLose()
    {
        Role role = GameObject.Find("playerLocal").GetComponent<Player>().role;
        if (role.hold.Equals("Environment"))
        {
            HoldImageLose.GetComponent<Image>().sprite = EnviSprite;
            HoldTextLose.text = "Maitriser Environnement";
        }
        else if (role.hold.Equals("Fluidity"))
        {
            HoldImageLose.GetComponent<Image>().sprite = FluidSprite;
            HoldTextLose.text = "Maitriser Fluidité";
        }
        else
        {
            HoldImageLose.GetComponent<Image>().sprite = AttractSprite;
            HoldTextLose.text = " Maitriser Attractivité";
        }

        if (role.improve.Equals("Environment"))
        {
            ImproveImageLose.GetComponent<Image>().sprite = EnviSprite;
            ImproveTextLose.text = "Améliorer Environnement";
        }
        else if (role.improve.Equals("Fluidity"))
        {
            ImproveImageLose.GetComponent<Image>().sprite = FluidSprite;
            ImproveTextLose.text = "Améliorer Fluidité";
        }
        else
        {
            ImproveImageLose.GetComponent<Image>().sprite = AttractSprite;
            ImproveTextLose.text = "Améliorer Attractivité";
        }

    }

}
