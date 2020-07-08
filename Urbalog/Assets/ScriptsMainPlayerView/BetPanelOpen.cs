using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetPanelOpen : MonoBehaviour
{
    public GameObject Panel;
    

    public void OpenPanel()
    {
        if (Panel != null)
        {
            Panel.SetActive(true);
        }
    }

    public void ClosePanel()
    {
        Debug.Log("test");
        if (Panel != null)
        {
            Panel.SetActive(false);
        }
    }
}
