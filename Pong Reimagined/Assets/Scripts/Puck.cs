using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{
    public Rigidbody2D rB;
    GameLogic gameLogic;
    float gravityScale;

    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        gameLogic = GetComponent<GameLogic>();
    }

    private void Update()
    {
        CheckDifficulty();
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

    private void CheckDifficulty()
    {
        gameLogic = FindObjectOfType<GameLogic>();
        if (gameLogic.difficultyIsEasy == true)
        {
            gravityScale = 4;
            if (rB.velocity.y > 10)
            {
                rB.velocity = new Vector3(0, 10, 0);
            }
            else if (rB.velocity.y < -10)
            {
                rB.velocity = new Vector3(0, -10, 0);
            }
            else { return; }
        }
        else if (gameLogic.difficultyIsMedium == true)
        {
            gravityScale = 6;
            if (rB.velocity.y > 10)
            {
                rB.velocity = new Vector3(0, 20, 0);
            }
            else if (rB.velocity.y < -10)
            {
                rB.velocity = new Vector3(0, -20, 0);
            }
            else { return; }
        }
        else if (gameLogic.difficultyIsHard == true)
        {
            gravityScale = 8;
            if (rB.velocity.y > 10)
            {
                rB.velocity = new Vector3(0, 30, 0);
            }
            else if (rB.velocity.y < -10)
            {
                rB.velocity = new Vector3(0, -30, 0);
            }
            else { return; }
        }
        else { return; }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 11)
        {
            rB.gravityScale = 10;
        }
        else if (other.gameObject.layer == 10)
        {
            rB.gravityScale = -10;
        }
        else { return; }
    }
}

