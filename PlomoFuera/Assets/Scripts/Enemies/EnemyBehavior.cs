using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [Header("Enemy Ref")]
    [SerializeField] private Enemy m_Enemy;
    [SerializeField]private Enemy.TypeBehaviour m_TypeBehaviour;
    [Space(3)]
    [Header("Overlap")]
    [SerializeField] private float _radius;
    [SerializeField] private int _layer;
    [Space(3)]
    [Header("Player")]
    [SerializeField] private GameObject m_Player;
    [Space(3)]
    [Header("Target")]
    [SerializeField] private Transform _target;
    // Start is called before the first frame update
    void Start()
    {
        m_TypeBehaviour = m_Enemy.type;
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_TypeBehaviour)
        {
            case Enemy.TypeBehaviour.run:
                Escape();
                break;
            case Enemy.TypeBehaviour.shoot:
                TargetingPlayer();
                break;
            default:
                break;
        }
    }

    private void Escape()
    {
        Debug.Log("Huyendo del JUGADOR");
    }

    private void TargetingPlayer()
    {
        Debug.Log("Atacando al jugador");
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, _radius, _layer);

        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent<FirstPersonController>(out FirstPersonController _player))
            {
                //_target = collider.gameObject.
            }
        }
    }
}
