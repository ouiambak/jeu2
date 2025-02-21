using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tooltiper : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static Action<string> _onMouseOver;  
    private string _TooltipString;  

    void Start()
    {
        _TooltipString = gameObject.name;  
    }

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
    private void OnMouseExit()
    {

        _onMouseOver?.Invoke("");

    }
}
