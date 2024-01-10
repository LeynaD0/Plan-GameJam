using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectArea : MonoBehaviour
{
    [SerializeField] private EnemyDisplay m_Display;
    [SerializeField] private EnemyMovement _movement;

    public int randomBehaviour;

    private void Start()
    {
        if (m_Display is null)
        {
            m_Display = GetComponentInParent<EnemyDisplay>();
        }

        if (_movement is null)
        {
            _movement = GetComponentInParent<EnemyMovement>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            randomBehaviour = Random.Range(0, 2);

            switch (m_Display.Base._type)
            {
                case NpcType.STUDENT:
                    if (randomBehaviour == 0)
                        _movement.state = NpcStates.FEAR;
                    else if(randomBehaviour == 1)
                        _movement.state = NpcStates.RUN_AWAY;
                    break;
                case NpcType.TEACHER:
                    break;
                case NpcType.CLEANER:
                    break;
                case NpcType.POLICE:
                    _movement.state = NpcStates.CHASING;
                    _movement.targetToChase = other.transform;
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _movement.state = NpcStates.PATROL;
        }
    }
}
