using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int points;    

    private Rigidbody[] rb;
    
    public enum TypeBehaviour
    { 
        run,
        shoot
    };
    [SerializeField] TypeBehaviour behaviour;

    public TypeBehaviour type; //puesto para quitar un error con otro Script - revisar cuando se pueda quitar/modificar

    private void Start()
    {
        rb = transform.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rigidbody in rb)
        {
            rigidbody.isKinematic = true;
        }

        if (behaviour == TypeBehaviour.run)
        {

        } 
        else if(behaviour == TypeBehaviour.shoot)
        {

        }
    }

    public void Health(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Points.instance.AddPoints(points);
            Death();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Health(1);
        }
    }

    public void Death()
    {
        foreach(Rigidbody rigidbody in rb)
        {
            rigidbody.isKinematic = false;
        }

        Destroy(gameObject, 5);
    }
}
