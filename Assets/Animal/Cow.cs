using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Animal;

public class Cow : Animal
{
    void Start()
    {
        GetAnimalComponents();
        StartCoroutine(MakeSoundOnRepeat());
    }

    void Update()
    {
        
    }
}
