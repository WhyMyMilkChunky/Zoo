using System.Collections;
using UnityEngine;

public class Cow : Animal
{
    private bool isRotating = false;
    private bool isInTriggerZone = false;
    public GameObject bucket;

    void Start()
    {
        GetAnimalComponents();
        StartCoroutine(MakeSoundOnRepeat());
    }

    void Update()
    {
        if (isInTriggerZone && Input.GetKeyDown(KeyCode.Space) && !isRotating)
        {
            Rotate();
            milkBucket();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInTriggerZone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInTriggerZone = false;
        }
    }

    void Rotate()
    {
        StartCoroutine(RotationCoroutine());
    }

    IEnumerator RotationCoroutine()
    {
        isRotating = true;

        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(-70f, 0f, 180f); 

        float duration = 2f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = endRotation;

        yield return new WaitForSeconds(0.5f);

        startRotation = endRotation;
        endRotation = Quaternion.Euler(-90f, 0f, 180f);

        elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = endRotation;

        isRotating = false;
    }

    void milkBucket()
    {
        GameObject newObject = Instantiate(bucket, transform.position - new Vector3(2.5f, 3f, 1f), Quaternion.identity);
        
        Destroy(newObject, 4f);
    }
}
