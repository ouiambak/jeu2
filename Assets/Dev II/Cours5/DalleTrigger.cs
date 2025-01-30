using UnityEngine;
using System; 

public class DalleTrigger : MonoBehaviour
{
    public static event Action<bool> OnDallePress; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnDallePress?.Invoke(true); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnDallePress?.Invoke(false); 
        }
    }
}
