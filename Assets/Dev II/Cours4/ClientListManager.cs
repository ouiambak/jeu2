using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClientListManager : MonoBehaviour
{
    public TMP_InputField clientNameInputField; // Champ d'entrée en haut à droite
    public RectTransform clientListContainer; // Conteneur de la liste des clients
    public GameObject clientPrefab; // Préfabriqué pour un client (image + nom + bouton supprimer)

    private void Start()
    {
        // S'assurer que le champ Input est positionné en haut à droite
        RectTransform inputFieldRect = clientNameInputField.GetComponent<RectTransform>();
        inputFieldRect.anchorMin = new Vector2(1, 1);
        inputFieldRect.anchorMax = new Vector2(1, 1);
        inputFieldRect.pivot = new Vector2(1, 1);
        inputFieldRect.anchoredPosition = new Vector2(-10, -10); // Décalage pour espacement

        // Ajouter un écouteur au TMP_InputField
        clientNameInputField.onEndEdit.AddListener(AddClient);
    }

   private void AddClient(string clientName)
{
    if (string.IsNullOrWhiteSpace(clientName)) return;

    if (clientPrefab == null || clientListContainer == null)
    {
        Debug.LogError("Client Prefab or Client List Container is not assigned in the inspector!");
        return;
    }

    // Créer une nouvelle instance du client à partir du prefab
    GameObject newClient = Instantiate(clientPrefab, clientListContainer);

    // Vérifier et définir le nom du client
    TextMeshProUGUI clientNameText = newClient.transform.Find("NameText")?.GetComponent<TextMeshProUGUI>();
    if (clientNameText != null)
    {
        clientNameText.text = clientName;
    }
    else
    {
        Debug.LogError("NameText is missing or not configured correctly in the prefab!");
    }

    // Vérifier et définir une couleur aléatoire pour l'icône
    Image clientIcon = newClient.transform.Find("ClientIcon")?.GetComponent<Image>();
    if (clientIcon != null)
    {
        clientIcon.color = new Color(Random.value, Random.value, Random.value);
    }
    else
    {
        Debug.LogError("ClientIcon is missing or not configured correctly in the prefab!");
    }

    // Ajouter une action au bouton de suppression
    Button deleteButton = newClient.transform.Find("DeleteButton")?.GetComponent<Button>();
    if (deleteButton != null)
    {
        deleteButton.onClick.AddListener(() => DeleteClient(newClient));
    }
    else
    {
        Debug.LogError("DeleteButton is missing or not configured correctly in the prefab!");
    }

    // Effacer le champ d'entrée après l'ajout
    clientNameInputField.text = "";

    // Mettre à jour la taille des éléments pour qu'ils s'adaptent
    StartCoroutine(UpdateLayout());
}


    private void DeleteClient(GameObject client)
    {
        Destroy(client);
        StartCoroutine(UpdateLayout());
    }

    private IEnumerator UpdateLayout()
    {
        // Attendre la fin du frame pour que le LayoutGroup s'actualise
        yield return null;

        // Forcer la mise à jour du layout
        LayoutRebuilder.ForceRebuildLayoutImmediate(clientListContainer);

        // Redimensionner dynamiquement les enfants pour s'adapter à la taille du conteneur
        int childCount = clientListContainer.childCount;
        float preferredHeight = Mathf.Min(100, clientListContainer.rect.height / Mathf.Max(1, childCount));

        foreach (RectTransform child in clientListContainer)
        {
            LayoutElement layoutElement = child.GetComponent<LayoutElement>();
            if (layoutElement != null)
            {
                layoutElement.preferredHeight = preferredHeight;
            }
        }
    }
}
