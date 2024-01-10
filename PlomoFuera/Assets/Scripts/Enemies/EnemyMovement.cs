using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using VictorRivero;

public class EnemyMovement : MonoBehaviour
{
    [Header("Display")]
    [SerializeField] private EnemyDisplay m_Display;
    [Space(3)]
    [Header("EnemyAttack")]
    [SerializeField] private EnemyAttack _enemyAttacks;
    [Space(3)]
    [Header("States")]
    [SerializeField] private NpcStates _state;
    public NpcStates state { get { return _state; } set {  _state = value; } }
    [Space(3)]
    [Header("Nav Mesh")]
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private float _stopDist;

    [Space(3)]
    [Header("Target")]
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _targetToChase;
    public Transform targetToChase { get { return _targetToChase; } set { _targetToChase = value; } }
    [Space(3)]
    [Header("Support")]
    [SerializeField] private float displacementDist = 5.0f;

    [Space(3)]
    [Header("Animator")]
    [SerializeField] private Animator _anim;

    [Space(3)]
    [Header("Range")]
    [SerializeField] private float _range;
    [Space(3)]
    [Header("Center Point")]
    [SerializeField] private Transform centerPoint;
    [Space(3)]
    [Header("Control")]
    [SerializeField] private bool _isRandom = false;

    [Space(3)]
    [Header("Support")]
    private float dist;

    // Start is called before the first frame update
    void Start()
    {
        if(m_Display is null)
        {
            m_Display = GetComponent<EnemyDisplay>();
        }
        if (_agent is null)
        {
            _agent = GetComponent<NavMeshAgent>();
        }
        if (_anim is null)
        {
            _anim = GetComponentInChildren<Animator>();
        }
        
    }
    void Awake()
    {
        if (_target is null)
        {
            _target = FindFirstObjectByType<FirstPersonController>().transform;
            Debug.Log("Obtenido");
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 normDir = (_target.position - transform.position).normalized;
        normDir = Quaternion.AngleAxis(45.0f, Vector3.up) * normDir;
        
        dist = Vector3.Distance(_target.position, transform.position);
        

        switch (state)
        {
            case NpcStates.PATROL:
                _isRandom = true;
                _anim.SetBool("Walk", true);
                _anim.SetBool("Running", false);
                _anim.SetBool("Pistol", false);
                RandomPositionMovement();
                break;
            case NpcStates.CHASING:
                _isRandom = false;
                _anim.SetBool("Walk", true);
                _anim.SetBool("Running", false);
                _anim.SetBool("Pistol", false);
                Chasing();
                break;
            case NpcStates.FEAR:
                _isRandom = false;
                _anim.SetTrigger("Fear");
                _anim.SetBool("Walk", false);
                Feared();
                break;
            case NpcStates.ATTACKING:
                _isRandom = false;
                if (_enemyAttacks.inReach)
                {
                    Debug.Log("A Melee");
                    _enemyAttacks.MeleeAttack();
                }
                else if (_enemyAttacks.canShoot)
                {
                    Debug.Log("A Distancia");
                    _enemyAttacks.ShootAttack();
                    _enemyAttacks.canShoot = false;
                }
                break;
            case NpcStates.RUN_AWAY:
                _isRandom = false;
                _anim.SetBool("Walk", false);
                _anim.SetBool("Running", true);
                _anim.SetBool("Pistol", false);
                RunAway(transform.position - (normDir * displacementDist));
                break;
            case NpcStates.DEAD:
                _isRandom = false;
                break;
            case NpcStates.DEFAULT:
                
                break;
        }
    }

    private void MoveToPos(Vector3 pos)
    {
        //Movimiento en caso de que el enemigo vaya a 
        //atacar al jugador.
        _agent.SetDestination(pos);
        _agent.stoppingDistance = _stopDist;
        //_agent.isStopped = true;        
    }

    private void RunAway(Vector3 pos)
    {
        _agent.SetDestination(pos);
        _agent.isStopped = false;
    }

    private void Chasing()
    {
        MoveToPos(_targetToChase.position);
        transform.LookAt(_targetToChase);

        if (dist <= _stopDist)
        {
            transform.LookAt(_targetToChase);
            if (_enemyAttacks.attackType == EnemyAttacks.MELEE)
            {
                transform.LookAt(_targetToChase);
                _enemyAttacks.canHit = true;
                transform.LookAt(_targetToChase);
                state = NpcStates.ATTACKING;
            }else if (_enemyAttacks.attackType == EnemyAttacks.SHOOT)
            {
                transform.LookAt(_targetToChase);
                transform.LookAt(_targetToChase);
                state = NpcStates.ATTACKING;
            }
        }        
    }

    private void RandomPositionMovement()
    {
        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            Vector3 point;
            if (RandomPoint(centerPoint.position, _range, out point)) //pass in our centre point and radius of area
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                _agent.SetDestination(point);
            }
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        {
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    private void Feared()
    {
        _agent.isStopped = true;
    }
}
