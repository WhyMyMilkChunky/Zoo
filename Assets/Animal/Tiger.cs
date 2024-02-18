using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Animal;

public class Tiger : Animal, TigerInteractable
{

    bool isInFeedRange;
    bool isCurrentlyJumping;
    public int numberOfJumpsRange;
    public float jumpDelayTime;
    public float strenghtOfJump;
    

    void Start()
    {
        GetAnimalComponents();

        StartCoroutine(MakeSoundOnRepeat());
    }

    void Update()
    {
        MyCustomInteract();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(other.name + " is in range feeding range");
            
            isInFeedRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInFeedRange = false;
        }
    }

    public void MyCustomInteract()
    {
        if (Input.GetKeyDown(KeyCode.R) && isInFeedRange && isCurrentlyJumping == false)
        {
            Debug.Log("start feeding the Tigers");
           
            isCurrentlyJumping = true;

            StartCoroutine(ApplyJumpEffect(numberOfJumpsRange, jumpDelayTime, strenghtOfJump, gameObject));         
        }
    }

    IEnumerator ApplyJumpEffect(int repeatValue, float delayTime, float jumpStrenght, GameObject gameObject)
    {
        repeatValue = Random.Range(1, repeatValue);
        
        for (int i = 0; i < repeatValue; i++) 
        {
            float currentDelay = Random.Range(0.0f, delayTime);
            
            yield return new WaitForSeconds(currentDelay);
       
            if (gameObject.GetComponent<Rigidbody>() != null)
            {
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.up * jumpStrenght;
            }
            
            Debug.Log("The player has feed the Tigers and they're happy");
        }
        isCurrentlyJumping = false;
    }
}