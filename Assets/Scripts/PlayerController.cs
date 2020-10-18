using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(GravityController))]
[RequireComponent(typeof(Destructible))]
[RequireComponent(typeof(PlayerAnimationController))]
public class PlayerController : MonoBehaviour
{
    private Mover mover;
    private Jumper jumper;
    private Destructible destructible;
    private GravityController gravityController;
    private Vector2 gravityDirection;
    private PlayerAnimationController animationController;
    
    public float gravityPowerRefreshTime = 5;
    private float timeSinceGravityPowerUsed = -1;

    void Start()
    {
        gravityDirection = Vector2.down;
        gravityController = GetComponent<GravityController>();
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
        if(timeSinceGravityPowerUsed == -1 && GravityControl())
        {
            timeSinceGravityPowerUsed = 0;
        }
        else if(timeSinceGravityPowerUsed != -1)
        {
            timeSinceGravityPowerUsed += Time.deltaTime;
            if(timeSinceGravityPowerUsed > gravityPowerRefreshTime)
            {
                timeSinceGravityPowerUsed = -1;
            }
        }
        
        animationController.PlayerDown(destructible.isDown());
        animationController.PlayerCrouching(crouching);
        animationController.PlayerWalking(moving);
        animationController.PlayerJump(jumper.IsJumping());
    }

    private bool Crouching()
    {
        return Input.GetKey(KeyCode.S);
    }

    private bool GravityControl()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            AlignDirection(transform.up);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            AlignDirection(-transform.right);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            AlignDirection(transform.right);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            AlignDirection(-transform.up);
        }
        else
        {
            return false;
        }
        return true;
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

    private void AlignDirection(Vector2 target)
    {
        gravityController.UpdateGravityDirection(target);
        float angle = Vector2.SignedAngle(gravityDirection, target);
        transform.localRotation *= Quaternion.Euler(0, 0, angle);
        gravityDirection = target;
    }
}
