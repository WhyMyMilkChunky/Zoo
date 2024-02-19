using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Animal;

public class Tiger : Animal, TigerInteractable
{
    //Created by Devin Hunt(200190392).

    bool isInFeedRange;
    bool isCurrentlyJumping;
    
    public int numberOfJumpsRange;
    
    public float jumpDelayTime;
    public float strenghtOfJump;

    public GameObject tigerFood;

    

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

            if (isCurrentlyJumping && tigerFood !=null)
            {
                SpawnFood(tigerFood, gameObject.transform.position + new Vector3(0.0f, 2.0f, -5.0f));
            }
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
            
            Debug.Log("The player has feed the" + gameObject.name + " and they're happy");
        }
        isCurrentlyJumping = false;
    }

    void SpawnFood(GameObject food, Vector3 destination)
    {
        GameObject newprojectile = Instantiate(food, destination, Quaternion.Euler(90f, 0.0f, 0.0f));
       
        Destroy(newprojectile, 4.0f);
    }
}