using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
// Classe RessourcesManager
public class RessourcesManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _foodTXT;
    [SerializeField] private TextMeshProUGUI _oreTXT;
    [SerializeField] private TextMeshProUGUI _woodTXT;
    [SerializeField] private int _foodCount = 100;
    [SerializeField] private int _woodCount = 0;
    [SerializeField] private int _oreCount = 0;

    void Start()
    {
        UpdateAllTextFields();
    }

    public void AddWood(int woodToAdd)
    {
        _woodCount += woodToAdd;
        UpdateAllTextFields();
    }

    public void AddOre(int oreToAdd)
    {
        _oreCount += oreToAdd;
        UpdateAllTextFields();
    }

    public void AddFood(int foodToAdd)
    {
        _foodCount += foodToAdd;
        UpdateAllTextFields();
    }

    private void UpdateAllTextFields()
    {
        _foodTXT.text = "Food: " + _foodCount;
        _oreTXT.text = "Ore: " + _oreCount;
        _woodTXT.text = "Wood: " + _woodCount;
    }

    public void EndWorkDay()
    {
        // Appelle la fonction Work sur tous les enfants
        foreach (Worker worker in GetComponentsInChildren<Worker>())
        {
            worker.Work();
        }
    }
}
