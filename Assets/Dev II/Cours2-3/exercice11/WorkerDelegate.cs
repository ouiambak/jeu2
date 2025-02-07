using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkerDelegate : MonoBehaviour
{
    [SerializeField] private WorkType workType;
    [SerializeField] private Button _button;
    private delegate void WorkFunctionDelegate();
    private WorkFunctionDelegate _delegate;
    void Start()
    {
        _button.onClick.AddListener(work);
    }
    void Update()
    {
        
    }
    public void work()
    {
        UpdateWorkType();
        _delegate();
    }
    private enum WorkType
    {
        Mining,
        Logging,
        Farming
         
    }
    private void UpdateWorkType()
    {
        _delegate = null;
        switch (workType)
        {
            case WorkType.Mining:
                _delegate += Mining;
                break;
            case WorkType.Logging:
                _delegate += Logging;
                break;
            case WorkType.Farming:
                _delegate += Farming;
                break;
        }
    }
    private void Farming()
    {
        Debug.Log("Worker is farming");
    }
    private void Mining()
    {
        Debug.Log("Worker is Mining");
    }
    private void Logging()
    {
        Debug.Log("Worker is Logging");
    }
}
