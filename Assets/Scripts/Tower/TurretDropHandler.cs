using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurretDropHandler : MonoBehaviour, IDropHandler
{
    public GameObject inventory;

    public void OnDrop(PointerEventData eventData)
    {
        

        print("OnDrop");
    }

}
