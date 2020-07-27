using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
   private RectTransform rectTransform;
    

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("test begin drag");
   
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("test drag");
        rectTransform.position = eventData.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("test clic");
        transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("test end drag");
    }

}
