using UnityEngine;

public class SphereColorLerp : MonoBehaviour
{
    private Renderer rend;
    private float duration = 5f; 
    private float elapsedTime = 0f; 

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float t = Mathf.Clamp01(elapsedTime / duration);
        rend.material.color = Color.Lerp(Color.black, Color.red, t);
        if (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
        }
    }
}
