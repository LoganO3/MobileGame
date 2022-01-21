using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float yMin = -8f;
    [SerializeField] float yMax = 8f;
    [SerializeField] float xMin = 1.3f;
    [SerializeField] float xMax = 18.5f;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float xVelocity = 10f;
    [SerializeField] float yVelocity = 10f;
    Rigidbody2D rB;
    Puck puck;

    // Start is called before the first frame update
    void Start()
    {
        puck = FindObjectOfType<Puck>();
        rB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (!puck) { return; }
        else
        {
            var targetPosition = puck.CurrentLocation(); 
            var movementThisFrame = moveSpeed * Time.deltaTime;
            targetPosition.y = Mathf.Clamp(targetPosition.y, yMin, yMax);
            targetPosition.x = Mathf.Clamp(targetPosition.x, xMin, xMax);
            transform.position = Vector3.MoveTowards (transform.position, targetPosition, movementThisFrame);
        }
    }
}
