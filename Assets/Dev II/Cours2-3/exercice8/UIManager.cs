using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI counterText; 
    private int count = 0;

    void OnEnable()
    {
        PressureTile.OnTilePressed += UpdateCounter;
    }

    void OnDisable()
    {
        PressureTile.OnTilePressed -= UpdateCounter;
    }

    void UpdateCounter()
    {
        count++;
        counterText.text = " " + count;
    }
}
