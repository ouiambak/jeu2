using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe enfant Farmer
public class Farmer : Worker
{
    public override void Work()
    {
        base.Work(); // Consomme de la nourriture
        _manager.AddFood(_production); // Ajoute de la nourriture
    }
}