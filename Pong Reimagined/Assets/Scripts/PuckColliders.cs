using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckColliders : MonoBehaviour
{
    Puck puck;
    GameLogic gameLogic;
    float newVelocity = 0f;
    [SerializeField] bool leftCollider;

    void Start()
    {
        puck = FindObjectOfType<Puck>();
        gameLogic = FindObjectOfType<GameLogic>();
    }

    void Update()
    {
        CheckDifficulty();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (leftCollider == true)
        {
            puck.rB.velocity = new Vector3(newVelocity, 0, 0);
        }
        else if (leftCollider == false)
        {
            puck.rB.velocity = new Vector3(-newVelocity, 0, 0);
        }
        else { return; }
    }

    private void CheckDifficulty()
    {
        gameLogic = FindObjectOfType<GameLogic>();
        if (gameLogic.difficultyIsEasy == true)
        {
            newVelocity = 10f;
        }
        else if (gameLogic.difficultyIsMedium == true)
        {
            newVelocity = 15f;
        }
        else if (gameLogic.difficultyIsHard == true)
        {
            newVelocity = 20f;
        }
        else { return; }
    }
}