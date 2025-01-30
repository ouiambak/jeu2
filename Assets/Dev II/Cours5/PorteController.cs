using UnityEngine;

public class PorteController : MonoBehaviour
{
    public Vector3 scaleOuvert = new Vector3(1, 1, 0.1f); 
    private Vector3 scaleFerme; 
    private bool isOpening = false;
    public float vitesse = 2f;

    private void Start()
    {
        scaleFerme = transform.localScale;
        DalleTrigger.OnDallePress += G�rerOuverture; 
        Debug.Log($"{gameObject.name} �coute l'�v�nement.");
    }

    private void OnDestroy()
    {
        DalleTrigger.OnDallePress -= G�rerOuverture; 
    }

    private void Update()
    {
        Vector3 cible = isOpening ? scaleOuvert : scaleFerme;
        transform.localScale = Vector3.Lerp(transform.localScale, cible, Time.deltaTime * vitesse);

        Debug.Log($"{gameObject.name} Scale actuel : {transform.localScale}");
    }

    private void G�rerOuverture(bool ouvrir)
    {
        isOpening = ouvrir;
        Debug.Log($"{gameObject.name} re�oit l'�v�nement. Ouvrir : {ouvrir}");
    }
}
