using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{
    Rigidbody2D rB;

    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
    }
    public Vector3 CurrentLocation()
    {
        Vector3 PuckLocation = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        return PuckLocation;
    }
    public Rigidbody2D returnRigidbody()
    {
        return rB;
    }
}
