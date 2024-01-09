using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyDisplay : MonoBehaviour
{
    private static EnemyDisplay _instance;
    public static EnemyDisplay Instance { get { return _instance; } }

    [Header("Base")]
    [SerializeField] private EnemyBase m_Base;
    public EnemyBase Base { get { return m_Base; } }

    [SerializeField] private TextMeshProUGUI _name;
    private void Awake()
    {
        if (_instance is null)
        {
            _instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _name.text = m_Base.name;
    }
}
