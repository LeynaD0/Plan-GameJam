using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "new enemy", menuName = "IA/enemy")]
public class Enemy : MonoBehaviour//ScriptableObject
{
    //[SerializeField] string enemyName;
    //public GameObject enemyObj;
    [SerializeField] int health;
    [SerializeField] int points;    
    
    public enum TypeBehaviour
    { 
        run,
        shoot
    };
    [SerializeField] TypeBehaviour behaviour;

    private void Start()
    {
        if(behaviour == TypeBehaviour.run)
        {

        } 
        else if(behaviour == TypeBehaviour.shoot)
        {

        }
    }

    public void Health()
    {
        health--;
        if (health <= 0)
        {
            Points.instance.AddPoints(points);
            //matar
        }
    }
}
