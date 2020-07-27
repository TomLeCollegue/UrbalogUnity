using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotDropItem : MonoBehaviour, IDropHandler
{
    public int num = 0;
    public string ressource;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            ressource = eventData.pointerDrag.GetComponent<DragDrop>().ressource;
            Bet(ressource);

        }
        

        

    }

    public void Bet(string ressource)
    {
        BetControl betcontrol = GameObject.Find("playerLocal").GetComponent<BetControl>();
        Role role = GameObject.Find("playerLocal").GetComponent<Player>().role;
        betcontrol.CheckBet(1, ressource, role);
    }
}
