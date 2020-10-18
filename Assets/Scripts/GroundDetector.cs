using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [HideInInspector]
    public bool onGround = false;
    private GravityController gravityController;

    private void Start()
    {
        gravityController = GetComponent<GravityController>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        onGround = ContactUnderCenterOfGravity(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        onGround = ContactUnderCenterOfGravity(collision);
    }

    private bool ContactUnderCenterOfGravity(Collision2D collision)
    {
        Vector2 gravityDirection = gravityController != null ? gravityController.gravityDirection : Vector2.down;
        if(collision.contactCount > 0)
        {
            foreach(ContactPoint2D contact in collision.contacts)
            {
                if(Vector2.Dot(contact.normal, -gravityDirection) > 0.5)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
