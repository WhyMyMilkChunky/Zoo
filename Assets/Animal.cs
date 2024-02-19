using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AnimalType
{
    Sheep,
    Giraffe,
    Tiger,
    Cow,
}

public abstract class Animal : MonoBehaviour
{
    AudioSource audioSource;

    public GameObject Food;
    public string animalName;

    public AnimalType type;
    public bool stopSound = false;
    private GameObject currentFood;
    public void GetAnimalComponents()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public virtual void MakeSound()
    {
        if (audioSource != null)
            audioSource.Play();
        else
            Debug.LogWarning("No audio source found for " + type);
    }
    public void Feed()
    {
        Vector3 spawnPosition = transform.position - transform.right * 5f;
        currentFood = Instantiate(Food, spawnPosition, Quaternion.identity);
        Spin();
        Eat(currentFood);
    }

    IEnumerator Eat(GameObject food)
    {
        yield return new WaitForSeconds(3f);

        Destroy(food);
        Debug.Log("Food Eaten");
        yield return null;
    }
    public abstract void PenInteraction();

    IEnumerator SpinCoroutine()
    {
        float totalRotation = 0f;
        while (totalRotation < 360f)
        {
            transform.Rotate(Vector3.up, 360f * Time.deltaTime / 3f);
            totalRotation += 360f * Time.deltaTime / 3f;
            yield return null;
        }
    }

    public void Spin()
    {
        StartCoroutine(SpinCoroutine());
    }

    public virtual IEnumerator MakeSoundOnRepeat()
    {

        while (true)
        {
            float RandomDelay2 = Random.Range(4f, 8f);
            yield return new WaitForSeconds(RandomDelay2);

            MakeSound();

            if (stopSound)
            {
                break;
            }
        }
    }

    public interface IInteractable
    {
        void Interact();

        
    }

    public interface TigerInteractable
    {
        void MyCustomInteract();
    }
}
