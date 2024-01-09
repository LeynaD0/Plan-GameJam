using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator door;
    [SerializeField] private bool doorIsOpen = false;
    [SerializeField] bool isToilet;

    private void Start()
    {
        door = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isToilet)
            {
                if (doorIsOpen)
                {
                    door.Play("ToiletDoorClose");
                    doorIsOpen = false;
                }
                else
                {
                    door.Play("ToiletDoorOpen");
                    doorIsOpen = true;
                }
            }
            else
            {
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

    //ontrigger stay para que salga la interaccion 
}
