using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonDragDrop : MonoBehaviour, IPointerDownHandler
{
    public GameObject resource;
    public Transform holder;

    public void SpawnResourceItem()
    {
        GameObject item = Instantiate(resource, holder);
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        SpawnResourceItem();
    }
    
}
