using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthManager : MonoBehaviour
{
    private static HealthManager _instance;
    public static HealthManager Instance { get { return _instance; } }
    [Header("Health")]
    [SerializeField] private int health;
    [SerializeField] private int _curHealth;
    [Space(3)]
    [Header("States")]
    [SerializeField] private bool _canRecoverHealth = false;
    [SerializeField] private int _recoverAmount = 1;

    [Space(3)]
    [Header("Timers")]
    [SerializeField] private float _timerRecover;
    [SerializeField] private float _timeToRecover;

    [Space(3)]
    [Header("TESTEO")]
    [SerializeField] private Slider _healthBarTest;
    [SerializeField] private TextMeshProUGUI _textHealthTest;
    // Start is called before the first frame update
    void Start()
    {
        _curHealth = health;
        _healthBarTest.maxValue = health;
        _healthBarTest.value = _curHealth;
        _healthBarTest.minValue = 0;

        _textHealthTest.text = _curHealth + " / " + health;
    }

    // Update is called once per frame
    void Update()
    {
        _healthBarTest.value = _curHealth;

        if (_canRecoverHealth)
        {
            _timerRecover += Time.deltaTime;
            RecoverHeals();
        }

        if (_curHealth <= 0)
        {
            _curHealth = 0;
            Dead();
        }

        ///IFs de TEST -> ELIMINAR
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ModifyHealth(1);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            ModifyHealth(-1);
        }
        ///
    }
    void Awake()
    {
        if (_instance is null)
        {
            _instance = this;
        }

        DontDestroyOnLoad(this);
    }

    public void ModifyHealth(int amount)
    {
        _curHealth += amount;

        if (_curHealth >= health)
        {
            _curHealth = health;
        }

        ///TEST -> ELIMINAR
        _textHealthTest.text = _curHealth + " / " + health;
    }
    public void RecoverHeals()
    {        
        if (_timerRecover >= _timeToRecover)
        {
            ModifyHealth(_recoverAmount);
            _timerRecover = 0.0f;
        }

        if (_curHealth == health)
        {
            _canRecoverHealth = false;
        }
    }
    public void Dead()
    {
        Debug.Log("MUERTE");
    }
}