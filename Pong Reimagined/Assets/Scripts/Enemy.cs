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
    Rigidbody2D rB;
    Puck puck;
    GameLogic gameLogic;
    float acceleration = 10000f;
    public Vector2 totalForceY;
    public Vector2 totalForceX;

    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        puck = FindObjectOfType<Puck>();
        gameLogic = FindObjectOfType<GameLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 puckLocation = puck.CurrentLocation();
        puckLocation.y = Mathf.Clamp(puckLocation.y, yMin, yMax);
        puckLocation.x = Mathf.Clamp(puckLocation.x, xMin, xMax);
        Move(puckLocation, moveSpeed);
    }

    private void Move(Vector3 target, float movementSpeed)
    {
        transform.position += (target - transform.position).normalized * movementSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (transform.position.y < collision.transform.position.y)
        {
            collision.otherRigidbody.AddForce(totalForceY);
        }
        else if (transform.position.y > collision.transform.position.y)
        {
            collision.otherRigidbody.AddForce(-totalForceY);
        }
        if (transform.position.x < collision.transform.position.x)
        {
            collision.otherRigidbody.AddForce(totalForceX);
        }
        else if (transform.position.x > collision.transform.position.x)
        {
            collision.otherRigidbody.AddForce(-totalForceX);
        }
    }

private void CheckDifficulty()
    {
        gameLogic = FindObjectOfType<GameLogic>();
        if (gameLogic.difficultyIsEasy == true)
        {
            moveSpeed = 5f;
        }
        else if (gameLogic.difficultyIsMedium == true)
        {
            moveSpeed = 15f;
        }
        else if (gameLogic.difficultyIsHard == true)
        {
            moveSpeed = 25f;
        }
        else { return; }
    }
}