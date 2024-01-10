using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float speed = 60, timeToDestroy = 5;
    
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
        timeToDestroy -= Time.deltaTime;

        if (timeToDestroy <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        
    }
}
