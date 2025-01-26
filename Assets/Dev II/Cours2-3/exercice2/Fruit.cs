using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    protected string _nom;
    protected float _vitamineC;

    public virtual string Nom()
    {
        return _nom;
    }

    public virtual float GetEaten()
    {
        Debug.Log("Le fruit a été mangé.");
        return _vitamineC;
    }

    public virtual void TasteSweet()
    {
        Debug.Log("Ce fruit est sucré.");
    }

    public virtual void TasteBitter()
    {
        Debug.Log("Ce fruit est amer.");
    }
}


