using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField] private float _maxDistance = 12f;
    void Update()//4pts
    {
        //Si la sph�re est en dessous du plan (plancher), incr�menter le score du ControlManager
        //en appelant la fonction AddScore � partir du singleton puis d�truire la sph�re.
        if((transform.position-Vector3.zero).magnitude>_maxDistance)
        {
            ControlManager._instance.AddOneToScore();
            Destroy(gameObject);
        }
    }
}
