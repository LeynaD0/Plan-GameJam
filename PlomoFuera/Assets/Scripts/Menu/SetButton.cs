using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class SetButton : MonoBehaviour
{
    [SerializeField]
    EventSystem eventSystem;
    [SerializeField]
    GameObject firstButton;
    // Start is called before the first frame update
    void OnEnable()
    {
        if (firstButton != null && eventSystem != null)
        {
            eventSystem.firstSelectedGameObject = firstButton;
            firstButton.GetComponent<ButtonSelected>().OnSelected();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
