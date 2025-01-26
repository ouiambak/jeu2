using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanCharacter : MonoBehaviour
{
    [SerializeField] private List<Fruit> _fruitList;
    [SerializeField] private float _vitamineCContent;

    // Méthode pour manger le premier fruit de la liste
    public void Manger()
    {
        if (_fruitList != null && _fruitList.Count > 0)
        {
            // Récupérer le premier fruit de la liste
            Fruit fruitAManger = _fruitList[0];

            // Afficher dans la console quel fruit est mangé
            Debug.Log("J'ai mangé " + fruitAManger.Nom());

            // Ajouter le contenu en vitamine C du fruit à celui de l'homme
            _vitamineCContent += fruitAManger.GetEaten();

            // Retirer le fruit mangé de la liste
            _fruitList.RemoveAt(0);

            // Détruire l'objet fruit s'il est attaché à un GameObject
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

    // Pour obtenir le contenu actuel en vitamine C de l'homme
    public float ObtenirVitamineC()
    {
        return _vitamineCContent;
    }
}
