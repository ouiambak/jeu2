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
        DalleTrigger.OnDallePress += GererOuverture; 
        Debug.Log($"{gameObject.name} Ecoute l'evenement.");
    }

    private void OnDestroy()
    {
        DalleTrigger.OnDallePress -= GererOuverture; 
    }

    private void Update()
    {
        Vector3 cible = isOpening ? scaleOuvert : scaleFerme;
        transform.localScale = Vector3.Lerp(transform.localScale, cible, Time.deltaTime * vitesse);

        Debug.Log($"{gameObject.name} Scale actuel : {transform.localScale}");
    }

    private void GererOuverture(bool ouvrir)
    {
        isOpening = ouvrir;
        Debug.Log($"{gameObject.name} recoit l'evenement. Ouvrir : {ouvrir}");
    }
}
