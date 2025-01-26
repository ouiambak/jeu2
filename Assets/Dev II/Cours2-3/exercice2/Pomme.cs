using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pomme : Fruit
{
    public Pomme()
    {
        _nom = "Pomme";
        _vitamineC = 5f; // Exemple de valeur pour la vitamine C
    }
    public override string Nom()
    {
        
        return base.Nom()+_nom;
        
    }

    public void EmitCrunchNoise()
    {
        Debug.Log("Crunch");
    }

    public override float GetEaten()
    {
        EmitCrunchNoise();
        TasteSweet();
        base.GetEaten();
        return _vitamineC;
    }
}
