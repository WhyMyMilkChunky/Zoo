using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Animal;

public class AnimalPen : MonoBehaviour, IInteractable
{

    [SerializeField] bool isInRange;

    public TextMeshProUGUI textMesh;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(other.name + " is in range");
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
            if (textMesh != null)
            {
                StartCoroutine(ShowThenHideText(textMesh, 2.0f));
            }
                                  
            Debug.Log("The player has interacted with the Animal Pen");                    
        } 
    }

    IEnumerator ShowThenHideText(TextMeshProUGUI text, float delayTime)
    {
        textMesh.enabled = true;
        
        yield return new WaitForSeconds(delayTime);

        textMesh.enabled = false;
    }

    void Update()
    {
        Interact();
    }
}
