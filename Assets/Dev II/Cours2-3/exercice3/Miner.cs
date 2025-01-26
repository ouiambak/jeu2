using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe enfant Miner
public class Miner : Worker
{
    public override void Work()
    {
        base.Work(); // Consomme de la nourriture
        _manager.AddOre(_production); // Ajoute du minerai
    }
}

