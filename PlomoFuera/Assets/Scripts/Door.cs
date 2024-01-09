using System.Collections;
using UnityEngine;
using StarterAssets;

public class Door : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private Animator door;
    [SerializeField] private bool doorIsOpen = false;
    [SerializeField] bool isToilet;

    [Header("Interact")]
    [SerializeField] StarterAssetsInputs _input;
    [SerializeField] float interactTimeOutDelta;
    [SerializeField] GameObject openDoor;
    [SerializeField] GameObject closeDoor;

    private void Start()
    {
        interactTimeOutDelta = 0.2f;
        door = GetComponent<Animator>();
        openDoor.SetActive(false);
        closeDoor.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {            
            if (doorIsOpen)
            {
                closeDoor.SetActive(true);
                openDoor.SetActive(false);
            }
            else
            {
                openDoor.SetActive(true);
                closeDoor.SetActive(false);                
            }

            if (_input.interact && interactTimeOutDelta <= 0.0f)
            {
                interactTimeOutDelta = 0.2f;
                DoorAnimation();
            }

            if (interactTimeOutDelta >= 0.0f)
            {
                interactTimeOutDelta -= Time.deltaTime;
            }
        }
    }

    public void DoorAnimation()
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

    private void OnTriggerExit(Collider other)
    {
        openDoor.SetActive(false);
        closeDoor.SetActive(false);
    }

    //ontrigger stay para que salga la interaccion 
}
