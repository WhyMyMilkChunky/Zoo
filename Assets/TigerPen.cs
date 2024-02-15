using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Animal;

public class TigerPen : MonoBehaviour, IInteractable
{
    public bool isInRange;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("in range" + other.name);
            isInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

    public void Interact()
    {

        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {


            Debug.Log("The player has interacted with the TigerPen by pressing the 'E' key.");
        }
    }


    void Update()
    {
        Interact();
    }
}
