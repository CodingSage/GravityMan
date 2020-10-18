using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundDetector))]
public class Jumper : MonoBehaviour
{
    public float jumpForce = 2.5f;
    private Rigidbody2D body;
    private GroundDetector groundDetector;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        groundDetector = GetComponent<GroundDetector>();
    }

    public void Jump(Vector2 direction)
    {
        if(groundDetector.onGround) 
            body.velocity += direction * jumpForce;
    }

    public bool IsJumping()
    {
        return groundDetector.onGround;
    }
}
