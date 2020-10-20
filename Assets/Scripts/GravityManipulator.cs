using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(VariableGravity))]
public class GravityManipulator : MonoBehaviour
{
    public float gravityPowerRefreshTime = 5;
    private float timeSinceGravityPowerUsed = -1;
    private VariableGravity selfGravityController;
    private Vector2 gravityDirection;
    private Dictionary<GameObject, VariableGravity> neighbouringObjects;

    void Start()
    {
        neighbouringObjects = new Dictionary<GameObject, VariableGravity>();
        selfGravityController = GetComponent<VariableGravity>();
        gravityDirection = Vector2.down;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftAlt))
        {
            foreach(VariableGravity obj in neighbouringObjects.Values)
            {
                GravityControl(obj);
            }
        }
        else
        {
            GravityControl(selfGravityController);
        }
        // Gravity refresh timing code
        /*if (timeSinceGravityPowerUsed == -1 && GravityControl())
        {
            timeSinceGravityPowerUsed = 0;
        }
        else if (timeSinceGravityPowerUsed != -1)
        {
            timeSinceGravityPowerUsed += Time.deltaTime;
            if (timeSinceGravityPowerUsed > gravityPowerRefreshTime)
            {
                timeSinceGravityPowerUsed = -1;
            }
        }*/
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        VariableGravity objGravity = collider.gameObject.GetComponent<VariableGravity>();
        if(objGravity != null)
        {
            neighbouringObjects.Add(collider.gameObject, objGravity);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(neighbouringObjects.ContainsKey(collider.gameObject))
        {
            neighbouringObjects.Remove(collider.gameObject);
        }
    }

    private bool GravityControl(VariableGravity gravityController)
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            AlignDirection(gravityController, transform.up);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            AlignDirection(gravityController, -transform.right);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            AlignDirection(gravityController, transform.right);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            AlignDirection(gravityController, -transform.up);
        }
        else
        {
            return false;
        }
        return true;
    }

    private void AlignDirection(VariableGravity gravityController, Vector2 target)
    {
        gravityController.UpdateGravityDirection(target);
        float angle = Vector2.SignedAngle(gravityDirection, target);
        if(gravityController == selfGravityController)
        {
            transform.localRotation *= Quaternion.Euler(0, 0, angle);
            gravityDirection = target;
        }
    }
}
