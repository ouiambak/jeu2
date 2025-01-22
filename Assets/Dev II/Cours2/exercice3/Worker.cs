using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Classe parent Worker
public class Worker : MonoBehaviour
{
    [SerializeField] protected RessourcesManager _manager;
    [SerializeField] protected int _foodConsumptionRate;
    [SerializeField] protected int _production;

    void Start()
    {
        _manager = transform.parent.GetComponent<RessourcesManager>();
    }

    public virtual void Work()
    {
        // Consomme de la nourriture
        _manager.AddFood(-_foodConsumptionRate);
    }
}
