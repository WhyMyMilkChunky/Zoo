using System.Collections;
using UnityEngine;
public class Giraffe : Animal
{
    void Start()
    {
        GetAnimalComponents();
        StartCoroutine(MakeSoundOnRepeat());

    }
}
