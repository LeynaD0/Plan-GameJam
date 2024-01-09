using UnityEngine;
public enum NpcStates
{
    PATROL,
    CHASING,
    ATTACKING,
    RUN_AWAY,
    DEAD,
    DEFAULT
}

public enum NpcType
{
    STUDENT,
    TEACHER,
    CLEANER,
    POLICE,
    DEFAULT
}
[CreateAssetMenu(fileName = "New Enemy", menuName = "IA/NPC Target")]
public class EnemyBase : ScriptableObject
{
    public string _npcName;
    public GameObject _npcPrefab;
    public NpcType _type;
    public NpcStates _state;
}
