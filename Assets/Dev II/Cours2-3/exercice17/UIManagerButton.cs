using UnityEngine;
using UnityEngine.UI;

public class UIManagerButton : MonoBehaviour
{
    public Button horseShowNameButton;
    public Button horseWorkButton;
    public Button catShowNameButton;
    public Button catWorkButton;
    public Button duckShowNameButton;
    public Button duckWorkButton;
    public Button buffaloShowNameButton;
    public Button buffaloWorkButton;

    private Animal currentAnimal;

    void Start()
    {
        // Associer les événements de clic pour chaque bouton
        horseShowNameButton.onClick.AddListener(() => SetAnimal("Horse"));
        horseWorkButton.onClick.AddListener(() => MakeAnimalWork());

        catShowNameButton.onClick.AddListener(() => SetAnimal("Cat"));
        catWorkButton.onClick.AddListener(() => MakeAnimalWork());

        duckShowNameButton.onClick.AddListener(() => SetAnimal("Duck"));
        duckWorkButton.onClick.AddListener(() => MakeAnimalWork());

        buffaloShowNameButton.onClick.AddListener(() => SetAnimal("Buffalo"));
        buffaloWorkButton.onClick.AddListener(() => MakeAnimalWork());
    }

    public void SetAnimal(string animalType)
    {
        switch (animalType)
        {
            case "Horse":
                currentAnimal = new Horse();
                break;
            case "Cat":
                currentAnimal = new Cat();
                break;
            case "Duck":
                currentAnimal = new Duck();
                break;
            case "Buffalo":
                currentAnimal = new Buffalo();
                break;
            default:
                currentAnimal = null;
                break;
        }
    }

    public void ShowAnimalName()
    {
        if (currentAnimal != null)
        {
            Debug.Log("Animal Name: " + currentAnimal.GetName());
        }
    }

    public void MakeAnimalWork()
    {
        if (currentAnimal is IWorker worker)
        {
            worker.Work();
        }
        else
        {
            Debug.Log("This animal can't work");
        }
    }
}
