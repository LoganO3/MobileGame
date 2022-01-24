using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float yMin = -8f;
    [SerializeField] float yMax = 8f;
    [SerializeField] float xMin = 1.5f;
    [SerializeField] float xMax = 18.5f;
    [SerializeField] float xVelocity = 10f;
    [SerializeField] float yVelocity = 10f;
    Rigidbody2D rB;
    Puck puck;

    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        puck = FindObjectOfType<Puck>();
    }

    // Update is called once per frame
    void Update()
    {
        rB.velocity = new Vector3(xVelocity, yVelocity, 0);
        Vector3 mousePostion = Camera.main.ScreenToWorldPoint(puck.CurrentLocation());
        Vector3 paddlePos = new Vector3(transform.position.x, transform.position.y, 0);
        paddlePos.y = Mathf.Clamp(mousePostion.y, yMin, yMax);
        paddlePos.x = Mathf.Clamp(mousePostion.x, xMin, xMax);
        transform.position = paddlePos;
    }
}

