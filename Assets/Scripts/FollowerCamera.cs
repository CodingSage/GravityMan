using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerCamera : MonoBehaviour
{
    public Transform body;

    void Update()
    {
        Vector3 bodyPosition = body.position;
        Vector3 cameraPosition = new Vector3(bodyPosition.x, bodyPosition.y, transform.position.z);
        transform.position = cameraPosition;
        transform.rotation = body.rotation;
    }
}
