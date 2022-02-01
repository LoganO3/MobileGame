using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckColliders : MonoBehaviour
{
    [SerializeField] bool topCollider;
    [SerializeField] bool bottomCollider;
    [SerializeField] bool rightCollider;
    [SerializeField] bool leftCollider;
    Puck puck;

    private void Start()
    {
        puck = FindObjectOfType<Puck>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (topCollider == true)
        {
            puck.topCollision = true;
        }
        if (bottomCollider == true)
        {
            puck.bottomCollision = true;
        }
        if (rightCollider == true)
        {
            puck.rightCollision = true;
        }
        if (leftCollider == true)
        {
            puck.leftCollision = true;
        }
    }
}