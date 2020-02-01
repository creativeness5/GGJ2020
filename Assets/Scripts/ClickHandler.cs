using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent OnRightClick; // UnityEvent for right clicking

     public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right) // if the input is right click
        {
            OnRightClick.Invoke(); // invokes custom right click function
        }
    }
}
