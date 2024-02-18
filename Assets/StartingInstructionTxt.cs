using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartingInstructionTxt : MonoBehaviour
{

    public TextMeshProUGUI startTextMesh;
    
    bool isInRange = true;


    void Update()
    {
        DisplayText();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

    void DisplayText()
    { 
        if (isInRange == false)
        {
            startTextMesh.enabled = false;
            this.enabled = false;
        }
    }
}
