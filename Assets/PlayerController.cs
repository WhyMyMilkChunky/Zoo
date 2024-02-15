using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody playerRb;

    Vector3 movement;

    public float moveSpeed = 7.0f;

    void Start()
    {
        
    }

  
    void Update()
    {
        MovementControls();
    }

    private void FixedUpdate()
    {
        playerRb.MovePosition( playerRb.position + movement 
                               * moveSpeed * Time.fixedDeltaTime );


    }

    void MovementControls()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
    }
}
