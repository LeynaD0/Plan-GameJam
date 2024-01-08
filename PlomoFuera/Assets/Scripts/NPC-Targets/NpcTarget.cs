using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NpcState
{
    ESCONDIDO,
    HUYENDO,
    MUERTO,
    DEFAULT
}

[CreateAssetMenu(fileName = "New Target", menuName = "IA/NpcTarget")]
public class NpcTarget : ScriptableObject
{
    public string npcName;
    public int npcHealth;
    public int points;
    public NpcState state;
}
