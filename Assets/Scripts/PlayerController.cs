using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(GravityManipulator))]
[RequireComponent(typeof(Destructible))]
[RequireComponent(typeof(PlayerAnimationController))]
public class PlayerController : MonoBehaviour
{
    private Mover mover;
    private Jumper jumper;
    private Destructible destructible;
    private PlayerAnimationController animationController;

    void Start()
    {
        mover = GetComponent<Mover>();
        jumper = GetComponent<Jumper>();
        destructible = GetComponent<Destructible>();
        animationController = GetComponent<PlayerAnimationController>();
    }

    private void Update()
    {
        Jumping();
        bool moving = Movement();
        bool crouching = Crouching();
        
        animationController.PlayerDown(destructible.isDown());
        animationController.PlayerCrouching(crouching);
        animationController.PlayerWalking(moving);
        animationController.PlayerJump(jumper.IsJumping());
    }

    private bool Crouching()
    {
        return Input.GetKey(KeyCode.S);
    }

    private bool Jumping()
    {
        if (Input.GetKey(KeyCode.W))
        {
            jumper.Jump(transform.up);
            return true;
        }
        return false;
    }

    private bool Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            mover.AccelarateInDirection(-transform.right);
            animationController.PlayerFacingDirection(false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            mover.AccelarateInDirection(transform.right);
            animationController.PlayerFacingDirection(true);
        }
        else
        {
            return false;
        }
        return true;
    }
}
