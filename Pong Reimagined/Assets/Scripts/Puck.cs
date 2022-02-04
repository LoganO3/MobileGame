using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{
    public float maxVelocity = 1;
    public float difficultyMaxVelocity;
    public Rigidbody2D rB;
    GameLogic gameLogic;

    private void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        gameLogic = GetComponent<GameLogic>();
        CheckDifficulty();
    }

private void Update()
{
        CheckMaxVelocity();
}

    public Vector3 CurrentLocation()
    {
        Vector3 PuckLocation = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        return PuckLocation;
    }

    private void CheckDifficulty()
{
    gameLogic = FindObjectOfType<GameLogic>();
    if (gameLogic.difficultyIsEasy == true)
    {
            difficultyMaxVelocity = 50f;
            maxVelocity = difficultyMaxVelocity;
        }
    else if (gameLogic.difficultyIsMedium == true)
    {
            difficultyMaxVelocity = 60f;
            maxVelocity = difficultyMaxVelocity;
        }
    else if (gameLogic.difficultyIsHard == true)
    {
            difficultyMaxVelocity = 70f;
            maxVelocity = difficultyMaxVelocity;
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
}


