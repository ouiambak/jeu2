using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEvents : MonoBehaviour
{
    public static event Action OnDoorUnlocked;
    public static event Action OnDoorOpenRequested;

    public Button keyButton;
    public Button openDoorButton;

    private bool doorUnlocked = false;

    void Start()
    {
        if (keyButton != null)
            keyButton.onClick.AddListener(HandleKeyButton);

        if (openDoorButton != null)
            openDoorButton.onClick.AddListener(HandleOpenDoorButton);
    }

    void HandleKeyButton()
    {
        if (!doorUnlocked)
        {
            doorUnlocked = true;
            Debug.Log("Porte débarrée (déverrouillée).");

            OnDoorUnlocked?.Invoke();
            if (keyButton != null)
                keyButton.interactable = false;
        }
    }

    void HandleOpenDoorButton()
    {
        if (doorUnlocked)
        {
            Debug.Log("Demande d'ouverture de la porte.");
            OnDoorOpenRequested?.Invoke();
        }
        else
        {
            Debug.Log("La porte est verrouillée. Utilisez d'abord le bouton clef.");
        }
    }
}
