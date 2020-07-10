using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EarlyGameManager : NetworkBehaviour
{
    [Header("Serveur Buttons")]
    public GameObject ServeurButtons;
    public TextMeshProUGUI marketviewText;
    public TextMeshProUGUI marketButtonsText;

    [Header("MarketButtonView")]
    public Button MarketButton;
    [Header("MarketButtons")]
    public Button Button1;
    public Button Button2;
    public Button Button3;
    public Button Button4;
    public Button Button5;
    public Button Button6;

    [SerializeField]
    [SyncVar]
    bool MarketViewlocked = true;
    [SerializeField]
    [SyncVar]
    bool MarketButtonlocked = true;

    private void Update()
    {
        if (!isServer)
        {
            ServeurButtons.SetActive(false);
        }
        if (MarketViewlocked)
        {
            MarketButton.interactable = false;
            marketviewText.text = "Unlock Vue Marché";
            marketviewText.color = Color.red;
        }
        else
        {
            MarketButton.interactable = true;
            marketviewText.text = "Lock Vue Marché";
            marketviewText.color = Color.green;
        }

        if (MarketButtonlocked)
        {
            marketButtonsText.text = "Unlock Boutons Marché";
            marketButtonsText.color = Color.red;
            Button1.interactable = false;
            Button2.interactable = false;
            Button3.interactable = false;
            Button4.interactable = false;
            Button5.interactable = false;
            Button6.interactable = false;
        }
        else
        {
            marketButtonsText.text = "Lock Boutons Marché";
            marketButtonsText.color = Color.green;
            Button1.interactable = true;
            Button2.interactable = true;
            Button3.interactable = true;
            Button4.interactable = true;
            Button5.interactable = true;
            Button6.interactable = true;
        }
        

    }

    [Command]
    public void CmdActivateMarketView()
    {
        MarketViewlocked = !MarketViewlocked;
    }
    
    [Command]
    public void CmdActivateMarketButtons()
    {
        MarketButtonlocked = !MarketButtonlocked;
    }




}
