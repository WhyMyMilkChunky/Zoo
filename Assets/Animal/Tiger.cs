using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiger : Animal
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
