using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orange : Fruit
{
    private bool _hasPeel;

    public Orange(bool hasPeel)
    {
        _nom = "Orange";
        _vitamineC = 10f; // Exemple de valeur pour la vitamine C
        _hasPeel = hasPeel;
    }
    public override string Nom()
    {
        
        return base.Nom()+_nom;
        
    }

    public void SquirtJuice()
    {
        Debug.Log("What a mess");
    }

    public override float GetEaten()
    {
        SquirtJuice();

        if (_hasPeel)
        {
            TasteBitter();
        }
        else
        {
            TasteSweet();
        }

        base.GetEaten();
        return _vitamineC;
    }
}
