using UnityEngine;

public class SphereColorSwitcher : MonoBehaviour
{
    [SerializeField] private Transform plane;
    [SerializeField] private Material greenMaterial;
    [SerializeField] private Material redMaterial;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        bool isInFront = Vector3.Dot(plane.right, transform.position - plane.position) > 0;
        rend.material = isInFront ? greenMaterial : redMaterial;
    }
}
