using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Animal;

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

