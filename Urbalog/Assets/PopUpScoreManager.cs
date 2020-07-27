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
            HoldTextWin.text = Language.HELD_ENVI;
            Debug.Log("Environment");
        }
        else if (role.hold.Equals("Fluidity"))
        {
            HoldImageWin.GetComponent<Image>().sprite = FluidSprite;
            HoldTextWin.text = Language.HELD_FLUID;
            Debug.Log("Fluid");
        }
        else
        {
            HoldImageWin.GetComponent<Image>().sprite = AttractSprite;
            HoldTextWin.text = Language.HELD_ATTRACT;
            Debug.Log("Attract");
        }
        
        if (role.improve.Equals("Environment"))
        {
            ImproveImageWin.GetComponent<Image>().sprite = EnviSprite;
            ImproveTextWin.text = Language.IMPROVE_ENVI;
            Debug.Log("Environment");
        }
        else if(role.improve.Equals("Fluidity"))
        {
            ImproveImageWin.GetComponent<Image>().sprite = FluidSprite;
            ImproveTextWin.text = Language.IMPROVE_FLUID;
            Debug.Log("Fluid");
        }
        else
        {
            ImproveImageWin.GetComponent<Image>().sprite = AttractSprite;
            ImproveTextWin.text = Language.IMPROVE_ATTRACT;
            Debug.Log("Attract");
        }
        
    }

    public void FillPopUpLose()
    {
        Role role = GameObject.Find("playerLocal").GetComponent<Player>().role;
        if (role.hold.Equals("Environment"))
        {
            HoldImageLose.GetComponent<Image>().sprite = EnviSprite;
            HoldTextLose.text = Language.HELD_ENVI_LOSE;
        }
        else if (role.hold.Equals("Fluidity"))
        {
            HoldImageLose.GetComponent<Image>().sprite = FluidSprite;
            HoldTextLose.text = Language.HELD_FLUID_LOSE;
        }
        else
        {
            HoldImageLose.GetComponent<Image>().sprite = AttractSprite;
            HoldTextLose.text = Language.HELD_ATTRACT_LOSE;
        }

        if (role.improve.Equals("Environment"))
        {
            ImproveImageLose.GetComponent<Image>().sprite = EnviSprite;
            ImproveTextLose.text = Language.IMPROVE_ENVI_LOSE;
        }
        else if (role.improve.Equals("Fluidity"))
        {
            ImproveImageLose.GetComponent<Image>().sprite = FluidSprite;
            ImproveTextLose.text = Language.IMPROVE_FLUID_LOSE;
        }
        else
        {
            ImproveImageLose.GetComponent<Image>().sprite = AttractSprite;
            ImproveTextLose.text = Language.HELD_ATTRACT_LOSE;
        }

    }

}
