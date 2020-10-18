using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GravityController : MonoBehaviour
{
    [HideInInspector]
    public Vector2 gravityDirection;
    public float gravityForce = 5f;
    private Rigidbody2D body;

    void Start()
    {
        gravityDirection = Vector2.down;
        body = GetComponent<Rigidbody2D>();
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
