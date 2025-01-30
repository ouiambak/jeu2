using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanCharacter : MonoBehaviour
{
    [SerializeField] private List<Fruit> _fruitList;
    [SerializeField] private float _vitamineCContent;

    public void Manger()
    {
        if (_fruitList != null && _fruitList.Count > 0)
        {
            Fruit fruitAManger = _fruitList[0];
            Debug.Log("J'ai mangé " + fruitAManger.Nom());
            _vitamineCContent += fruitAManger.GetEaten();
            _fruitList.RemoveAt(0);
            if (fruitAManger.gameObject != null)
            {
                Destroy(fruitAManger.gameObject);
            }
        }
        else
        {
            Debug.Log("Aucun fruit disponible à manger.");
        }
    }
    public float ObtenirVitamineC()
    {
        return _vitamineCContent;
    }
}
