using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleSettingsPanel : MonoBehaviour
{
    public GameObject panel;

    public InputField RoleName;

    public Button HoldAttractButton;
    public Button HoldEnviButton;
    public Button HoldFluidButton;

    public Button ImproveAttractButton;
    public Button ImproveEnviButton;
    public Button ImproveFluidButton;

    public InputField PoliNumberInput;
    public InputField EcoNumberInput;
    public InputField SocialNumberInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// opens the panel which allows us to modify the role
    /// </summary>
    public void OpenRoleSettingsPanel(Role _role)
    {
        if (panel != null)
        {
            panel.SetActive(true);
            RoleName.text = _role.nameRole;
        }
    }

    internal void CloseRoleSettingsPanel()
    {
        panel.SetActive(false);
    }
}
