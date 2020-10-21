using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Destructible))]
[RequireComponent(typeof(Destructible))]
[RequireComponent(typeof(SpriteRenderer))]
public class MechaController : MonoBehaviour
{
    private Mover mover;
    private float initialX;
    private Vector2 facingDirection;
    public int patrolRange = 10;
    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        mover = GetComponent<Mover>();
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialX = transform.position.x;
        facingDirection = Vector2.right;
    }

    void Update()
    {
        if(transform.position.x <= initialX - patrolRange)
        {
            if (facingDirection == Vector2.left)
                body.velocity = Vector2.zero;
            facingDirection = Vector2.right;
            spriteRenderer.flipX = false;
        }
        else if(transform.position.x >= initialX + patrolRange)
        {
            if (facingDirection == Vector2.right)
                body.velocity = Vector2.zero;
            facingDirection = Vector2.left;
            spriteRenderer.flipX = true;
        }
        mover.AccelarateInDirection(facingDirection);
    }
}
