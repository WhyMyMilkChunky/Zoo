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

public class Animal : MonoBehaviour
{
    AudioSource audioSource;

    public float movementSpeed;

    public string animalName;

    public AnimalType type;
    public bool stopSound = false;

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
