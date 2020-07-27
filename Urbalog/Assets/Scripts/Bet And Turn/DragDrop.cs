using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public string ressource;
    public Canvas canvas;

    

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        ressource = "Political";
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("test begin drag");
        canvasGroup.blocksRaycasts = false;
   
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("test drag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("test clic");
        transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("test end drag");
        canvasGroup.blocksRaycasts = true;
    }

}
