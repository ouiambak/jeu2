using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;

public class ToolTipsManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_TextMeshPro;
    void Start()
    {
        Tooltiper._onMouseOver += UpdateText;
    }
    private void UpdateText(string value)
    {

        m_TextMeshPro.text = value;
    }
    private void OnDestroy()
    {
        Tooltiper._onMouseOver -= UpdateText;
    }

}