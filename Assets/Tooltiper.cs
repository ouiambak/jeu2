using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tooltiper : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public static Action<string> _onMouseOver;
    [SerializeField] private string _TooltipString;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _onMouseOver?.Invoke(_TooltipString);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _onMouseOver?.Invoke("");
    }

    private void OnMouseEnter()
    {
        //dans l'objet faut un collider pour que l'unity le detecte a partir d'un raycast
        _onMouseOver?.Invoke(_TooltipString);
    }
    private void OnMouseExit() {
        
        _onMouseOver?.Invoke("");

    }
}
