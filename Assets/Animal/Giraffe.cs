using System.Collections;
using UnityEngine;
public class Giraffe : Animal
{
    void Start()
    {
        GetAnimalComponents();
        StartCoroutine(MakeSoundOnRepeat());
    }

    public override void PenInteraction()
    {
        Feed();
        Debug.Log("Griaffe eat");
    }
}
