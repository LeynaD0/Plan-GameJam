using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomMovement : MonoBehaviour
{
    [Header("NavMesh")]
    [SerializeField] private NavMeshAgent _agent;
    [Space(3)]
    [Header("Range")]
    [SerializeField] private float _range;
    [Space(3)]
    [Header("Center Point")]
    [SerializeField] private Transform centerPoint;
    [Space(3)]
    [Header("Control")]
    [SerializeField] private bool _isRandom = false;
    public bool isRandom { get { return _isRandom; } set {  _isRandom = value; } }

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isRandom)
        {
            RandomPositionMovement();
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
}
