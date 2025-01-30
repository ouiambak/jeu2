using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitEnum : MonoBehaviour
{
    enum Fruit
    {
        Cherry,
        Apple,
        Pear
    };
    
    [SerializeField] List<Fruit> fruits;
    void Start()
    {
        int cherryCount = 0;
        int appleCount = 0;
        int pearCount = 0;

        foreach (Fruit fruit in fruits)
        {
            switch (fruit)
            {
                case Fruit.Cherry:
                    cherryCount++;
                    break;
                case Fruit.Apple:
                    appleCount++;
                    break;
                case Fruit.Pear:
                    pearCount++;
                    break;
            }
        }

        Debug.Log($"Cherries: {cherryCount}");
        Debug.Log($"Apples: {appleCount}");
        Debug.Log($"Pears: {pearCount}");
    }

}
