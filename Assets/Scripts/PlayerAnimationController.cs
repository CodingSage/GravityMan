using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void PlayerFacingDirection(bool right)
    {
        spriteRenderer.flipX = !right;
    }

    public void PlayerJump(bool onGround)
    {
        animator.SetBool("OnGround", onGround);
    }

    public void PlayerWalking(bool moving)
    {
        animator.SetBool("Moving", moving);
    }

    public void PlayerDown(bool emptyHealth)
    {
        if(emptyHealth)
        {
            animator.SetTrigger("EmptyHealth");
        }
        /*else
        {
            animator.ResetTrigger("EmptyHealth");
            animator.SetTrigger("Revived");
            animator.ResetTrigger("Revived");
        }*/
    }

    public void PlayerCrouching(bool crouching)
    {
        animator.SetBool("Crouching", crouching);
    }
}
