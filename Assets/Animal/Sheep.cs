using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : Animal
{
    Rigidbody rb;
    float jumpForce = 2f;
    // Start is called before the first frame update
    void Start()
    {
        GetAnimalComponents();
        StartCoroutine(MakeSoundOnRepeat());
        rb = GetComponent<Rigidbody>();
    }

    public override void PenInteraction()
    {
        Jump();
    }

    public override void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
