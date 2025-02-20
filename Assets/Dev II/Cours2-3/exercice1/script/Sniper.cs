
using Unity.VisualScripting;
using UnityEngine;

public class Sniper : Gun
{
    private bool _isAiming=false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!_isAiming)
            {
                Debug.Log("Is aiming");
            }
        }
        else
        {
            _isAiming = false;
        }
    }
}


/*private static ControlManager _instance;
    public static ControlManager Instance => _instance;

private void Awake() //2pts
{
    // Utiliser un Singleton Pattern pour le ControlManager
    if (_instance != null && _instance != this)
    {
        Destroy(gameObject); // Détruire le duplicata s'il existe déjà une instance
        return;
    }
    _instance = this;
    DontDestroyOnLoad(gameObject); // Préserver l'instance lors des changements de scène

    // Ajouter les listeners pour les boutons
    _toggleGateBtn.onClick.AddListener(ToggleDoorButton);
    _toggleLockBtn.onClick.AddListener(ToggleLockButton);
    _toggleLightBtn.onClick.AddListener(ToggleLight);
    _spawnSphere.onClick.AddListener(SpawnSphere);
    _moveSphere.onClick.AddListener(GiveImpulseToSphere);
}
*/