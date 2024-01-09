using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectArea : MonoBehaviour
{
    [SerializeField] private EnemyDisplay m_Display;
    [SerializeField] private EnemyBehavior _behaviour;
    [SerializeField] private EnemyMovement _movement;

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
            switch(m_Display.Base._type)
            {
                case NpcType.STUDENT:
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
            /*_behaviour.target = null;
            _behaviour.inReach = false;*/
        }
    }
}
