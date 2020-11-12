using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurretDragHandler : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    //Correct scale of mouse and item being dragged
    //[SerializeField] private Canvas canvas;

    //private CanvasGroup canvasGroup;
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        print("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        print("OnDrag");
        //rectTransform.anchoredPosition += eventData.delta; 
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //canvasGroup.blocksRaycasts = true;
        print("OnEndDrag");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print("OnPointerDown");
    }

    


}
