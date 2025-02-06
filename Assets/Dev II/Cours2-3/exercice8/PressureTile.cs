using System;
using UnityEngine;

public class PressureTile : MonoBehaviour
{
    public static event Action OnTilePressed;

    private bool isPressed = false;

    void OnTriggerEnter(Collider other)
    {
        if (!isPressed && other.CompareTag("Cube"))
        {
            isPressed = true;
            Debug.Log("Dalle activée !");

            OnTilePressed?.Invoke();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (isPressed && other.CompareTag("Cube"))
        {
            isPressed = false;
            Debug.Log("Dalle relâchée.");
        }
    }
}
