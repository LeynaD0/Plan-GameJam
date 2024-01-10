using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Display")]
    [SerializeField]private EnemyDisplay _display;
    [Space(3)]
    [Header("Health and Points")]
    [SerializeField]private int maxHealth;
    [SerializeField]private int health;
    [SerializeField]private int points;
    [Space(3)]
    [Header("Helth Bar")]
    [SerializeField] private Slider _healthBar;

    private Rigidbody[] rb;
    //[SerializeField] Animator animator;
    

    private void Start()
    {
        if (_display is null)
        {
            _display = GetComponent<EnemyDisplay>();
        }
        rb = transform.GetComponentsInChildren<Rigidbody>();

        maxHealth = _display.Base.healthBase;
        health = maxHealth;
        points = _display.Base.pointsBase;

        foreach (Rigidbody rigidbody in rb)
        {
            rigidbody.isKinematic = true;
        }

        _healthBar.maxValue = maxHealth;
        _healthBar.minValue = 0;
        _healthBar.value = health;
    }

    public void Health(int amount)
    {
        health -= amount;
        _healthBar.value = health;

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
        /*
        animator.enabled = false;
        foreach(Rigidbody rigidbody in rb)
        {
            rigidbody.isKinematic = false;
        }*/
        Spawns.instance.EnemyCount--;

        Destroy(gameObject);
    }
}
