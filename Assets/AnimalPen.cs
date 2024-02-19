using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Animal;

public class AnimalPen : MonoBehaviour, IInteractable
{
    //Created by Devin Hunt(200190392).

    [SerializeField] bool isInRange;

    public TextMeshProUGUI textMesh;


    void Update()
    {
        Interact();
    }

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
                StartCoroutine(ShowThenHideText(textMesh, 3.0f));
            }
                                  
            Debug.Log("The player has interacted with the Animal Pen");                    
        } 
    }

    IEnumerator ShowThenHideText(TextMeshProUGUI text, float delayTime)
    {
        text.enabled = true;
        
        yield return new WaitForSeconds(delayTime);

        text.enabled = false;
    }
}
