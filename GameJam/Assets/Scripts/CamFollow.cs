using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{

    public float damping;
    public Vector3 offset;
    public Transform target;

    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        Vector3 newPos = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, damping);
    }
}
