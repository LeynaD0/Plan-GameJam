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
    [Header("Speeds")]
    [SerializeField] private float _speed;
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
    public Transform target { get { return _target; } set { _target = value; } }
    [Space(3)]
    [Header("Control")]
    public bool inReach;
    // Start is called before the first frame update
    void Start()
    {
        //m_TypeBehaviour = m_Enemy.type;
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
        if (inReach)
        {
            Debug.Log("Huyendo del JUGADOR");

            //Realizar comportamiento de escapada de los enemigos
            Vector3 roamPosition;

            roamPosition = GetRoamingPosition();
            transform.position += roamPosition * Time.deltaTime * _speed;
        }
    }

    private void TargetingPlayer()
    {
        Debug.Log("Atacando al jugador");
        
        //Realizar comportamiento de ataque de los enemigos
    }
    private Vector3 GetRoamingPosition()
    {
        return transform.position + GetRandomDir() * Random.Range(5f, 10f); ;
    }
    public static Vector3 GetRandomDir()
    {
        return new Vector3(Random.Range(-1f, 1f), 0.0f).normalized;
    }
}
