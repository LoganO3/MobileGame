using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{
    public bool topCollision = false;
    public bool bottomCollision = false;
    public bool leftCollision = false;
    public bool rightCollision = false;
    float velocityIncrease = 10f;
    float maxVelocity = 1;
    Rigidbody2D rB;
    GameLogic gameLogic;

    private void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        gameLogic = GetComponent<GameLogic>();
    }

private void Update()
{
        CheckDifficulty();
        CheckMaxVelocity();
}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (topCollision == true)
        {
            rB.velocity = new Vector3(rB.velocity.x, rB.velocity.y - velocityIncrease, 0);
            topCollision = false;
            Debug.Log("Top");
        }
        else { return; }
        if (bottomCollision == true)
        {
            rB.velocity = new Vector3(rB.velocity.x, rB.velocity.y + velocityIncrease, 0);
            bottomCollision = false;
            Debug.Log("Bottom");
        }
        else { return; }
        if (leftCollision == true)
        {
            rB.velocity = new Vector3(rB.velocity.x - velocityIncrease, rB.velocity.y, 0);
            leftCollision = false;
            Debug.Log("Left");
        }
        else { return; }
        if (rightCollision == true)
        {
            rB.velocity = new Vector3(rB.velocity.x + velocityIncrease, rB.velocity.y, 0);
            rightCollision = false;
            Debug.Log("Right");
        }
        else { return; }
    }

    private void CheckDifficulty()
{
    gameLogic = FindObjectOfType<GameLogic>();
    if (gameLogic.difficultyIsEasy == true)
    {
        velocityIncrease = 2f;
    }
    else if (gameLogic.difficultyIsMedium == true)
    {
        velocityIncrease = 3f;
    }
    else if (gameLogic.difficultyIsHard == true)
    {
        velocityIncrease = 5f;
    }
    else { return; }
}

private void CheckMaxVelocity()
    {
        if (rB.velocity.y > maxVelocity)
        {
            rB.velocity = new Vector3 (rB.velocity.x, maxVelocity,0);
        }
        if (rB.velocity.y < -maxVelocity)
        {
            rB.velocity = new Vector3(rB.velocity.x, -maxVelocity, 0);
        }
        if (rB.velocity.x > maxVelocity)
        {
            rB.velocity = new Vector3(maxVelocity, rB.velocity.y, 0);
        }
        if (rB.velocity.x < -maxVelocity)
        {
            rB.velocity = new Vector3(-maxVelocity, rB.velocity.y, 0);
        }
    }

    public Vector3 CurrentLocation()
    {
        Vector3 PuckLocation = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        return PuckLocation;
    }
}


