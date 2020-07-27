using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonDragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public GameObject resource;
    public Transform holder;
    public RectTransform transformtest;
    public Canvas canvas;

    public void OnBeginDrag(PointerEventData eventData)
    {
        GameObject item = Instantiate(resource, eventData.position, Quaternion.identity);
        item.transform.SetParent(holder, false);
        item.GetComponent<DragDrop>().canvas = canvas;
        eventData.pointerDrag = item;
   
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

}
