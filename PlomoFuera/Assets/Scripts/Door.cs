using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator door;
    [SerializeField] private bool doorIsOpen = false;

    private void Start()
    {
        door = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Afdd");
            if (doorIsOpen)
            {
                door.Play("DoorClose");
                doorIsOpen = false;
            }
            else
            {
                door.Play("DoorOpen");
                doorIsOpen = true;
            }
        }
    }
}
