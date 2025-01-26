using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe enfant Lumberjack
public class LumberJack : Worker
{
    public override void Work()
    {
        base.Work(); // Consomme de la nourriture
        _manager.AddWood(_production); // Ajoute du bois
    }
}