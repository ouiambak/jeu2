using UnityEngine;
using UnityEngine.UI;

public class ProgressBarManager : MonoBehaviour
{
    public Image progressBar;
    private float progress = 0f;
    public float increment = 0.1f;

    void OnEnable()
    {
        PressureTile.OnTilePressed += IncreaseBarSize;
    }

    void OnDisable()
    {
        PressureTile.OnTilePressed -= IncreaseBarSize;
    }

    void IncreaseBarSize()
    {
        progress = Mathf.Clamp01(progress + increment);
        progressBar.fillAmount = progress;
    }
}
