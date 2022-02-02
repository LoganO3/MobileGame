using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{
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
            maxVelocity = 50f;
    }
    else if (gameLogic.difficultyIsMedium == true)
    {
            maxVelocity = 75f; 
    }
    else if (gameLogic.difficultyIsHard == true)
    {
            maxVelocity = 100f; 
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


