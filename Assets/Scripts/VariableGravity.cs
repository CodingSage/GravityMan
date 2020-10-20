using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class VariableGravity : MonoBehaviour
{
    [HideInInspector]
    public Vector2 gravityDirection;
    public float gravityForce = 5f;
    private Rigidbody2D body;

    void Start()
    {
        gravityDirection = Vector2.down;
        body = GetComponent<Rigidbody2D>();
        // A gravity variable rigidbody will not have any natural gravity act on it
        body.gravityScale = 0;
    }

    void Update()
    {
        body.AddForce(gravityForce * gravityDirection);
    }

    public void UpdateGravityDirection(Vector2 gravityDirection)
    {
        this.gravityDirection = gravityDirection;
    }
}
