using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using Random = UnityEngine.Random;

public class ControlManager : MonoBehaviour
{
    public static Action _OnGateOpen;
    public static Action _OnGateClose;
    public static Action<bool> _OnToggleLock;
    public static ControlManager _instance;

    [SerializeField] private TextMeshProUGUI _scoreTxt;
    [SerializeField] private Button _toggleGateBtn;
    [SerializeField] private Button _toggleLockBtn;
    [SerializeField] private Button _toggleLightBtn;
    [SerializeField] private Button _spawnSphere;
    [SerializeField] private Button _moveSphere;
    [SerializeField] private List<Sprite> _gateBtnImage;
    [SerializeField] private List<Sprite> _lockBtnImage;
    [SerializeField] private List<Sprite> _lightBtnImage;
    [SerializeField] private Light _light;
    [SerializeField] private GameObject _sphere;
    [SerializeField] private float _sphereSpeed = 3f;
    [SerializeField] private float  _lightChangeDelay;

    private GameObject _lastSphere;

    private int _score;
    private float _lightTimer;
    private float _currentLightIntensity;
    private bool _isDoorOpen;
    private bool _isUnlocked;
    private bool _isLightOn ;
    private float duration = 5f;
    private float elapsedTime = 0f;
    private void Awake()//2pts
    {
        //Utiliser un Singleton Pattern pour le Control Manager
        if (_instance != null && _instance != this) { 
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
        _toggleGateBtn.onClick.AddListener(ToggleDoorButton);
        _toggleLockBtn.onClick.AddListener(ToggleLockButton); 
        _toggleLightBtn.onClick.AddListener(ToggleLight);
        _spawnSphere.onClick.AddListener(SpawnSphere); 
        _moveSphere.onClick.AddListener(GiveImpulseToSphere); 
    }

    public void ToggleDoorButton()//2pts
    {
        _isDoorOpen = !_isDoorOpen;
        _OnGateOpen?.Invoke();
        ToggleButtonDisplay(_toggleGateBtn, _isDoorOpen, _gateBtnImage);
    }

    public void ToggleLockButton()//1pts
    {
        // Inverser la valeur de _isUnlocked
        _isUnlocked = !_isUnlocked;
        // Appeler l'évènement qui barre ou débarre les portes
        _OnToggleLock?.Invoke(_isUnlocked);
        ToggleButtonDisplay(_toggleLockBtn, _isUnlocked, _lockBtnImage);
    }

    public void ToggleLight()//2pts
    {
        // Inverser la valeur de _isLightOn
        _isLightOn =! _isLightOn;
        // Mettre le timer de gradation graduel de la lumière à 0;
        _lightTimer = 0f;
        // Assigner la valeur de _currentLight Intensity à la valeur d'intensité actuel de la lumière (_light.intensity)
        _currentLightIntensity = _light.intensity;
        ToggleButtonDisplay(_toggleLightBtn, _isLightOn, _lightBtnImage);
    }

    public void SpawnSphere()//2pts
    {
        //Détruire la sphére actuelle si elle existe
        if(_sphere.gameObject == null)
        {
            Instantiate(_sphere);
        }
        else
        {
            Destroy(_sphere.gameObject);
        }
        //Instancier une nouvelle sphère au dessus du plan et assigner la valeur de _currentSphere a la sphere nouvellement créée 
        Vector3 spawnPosition = new Vector3(0,1,0);
        _sphere = Instantiate(_sphere,spawnPosition,Quaternion.identity);

    }

    private void Update()//4pts
    {
        // Incrémenter le lightTimer en fonction du temps qui s'écoule
        _lightTimer += Time.deltaTime;
        // Si la lumière est allumé, interpoler linéairement l'intensité de la lumière vers 1 en fonction du lightTimer et du _lightChangeDelay
        if (_isLightOn)
        {
            _light.intensity = Mathf.Lerp(_currentLightIntensity, 10f, _lightTimer / _lightChangeDelay);
        }
        // Si la lumière est fermée, interpoler linéairement l'intensité de la lumière vers 0 en fonction du lightTimer et du _lightChangeDelay
        if (_isLightOn)
        {
            _light.intensity = Mathf.Lerp(_currentLightIntensity, 0f, _lightTimer / _lightChangeDelay);
        }
    }

    public void GiveImpulseToSphere()//3pts
    {
        // Créer un vecteur direction de taille 1 (normalisé) qui pointe vers une direction orientée au hazard sur le plan XZ
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        // Si la currentSphere existe, utiliser la direction déterminée au hazard pour assigné la vitesse au Rigidbody de la sphère (utiliser sphereSpeed) 
        if (_sphere != null)
        {
            Rigidbody rb = _sphere.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = randomDirection * _sphereSpeed;

            }
        }
    }

    public void AddOneToScore()//1pts
    {
        //Ajouter 1 au score
        _score++;
        //Mettre a jour la valeur le texte du score dans le UI
        _scoreTxt.text = _score.ToString();
    }

    private void ToggleButtonDisplay(Button btn, bool isOn, List<Sprite> _OnOffSpriteList)
    {
        btn.image.sprite = isOn ? _OnOffSpriteList[0] : _OnOffSpriteList[1];
    }
}
