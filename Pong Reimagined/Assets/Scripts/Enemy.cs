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
    GameLogic gameLogic;
    Puck puck;

    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        gameLogic = FindObjectOfType<GameLogic>();
        puck = FindObjectOfType<Puck>();
    }

    // Update is called once per frame
    void Update()
    {
    rB.velocity = new Vector3(xVelocity, yVelocity, 0);
    Vector3 puckLocation = puck.CurrentLocation();
    puckLocation.y = Mathf.Clamp(puckLocation.y, yMin, yMax);
    puckLocation.x = Mathf.Clamp(puckLocation.x, xMin, xMax);
    Move(puckLocation, moveSpeed);
    }

    private void Move(Vector3 target, float movementSpeed)
    {
        transform.position += (target - transform.position).normalized * movementSpeed * Time.deltaTime;
    }

    private void CheckDifficulty()
    {
        if (gameLogic.difficultyIsEasy == true)
        {
            xVelocity = 10f;
            moveSpeed = 5f;

        }
        else if (gameLogic.difficultyIsMedium == true)
        {
            xVelocity = 25f;
            moveSpeed = 10f;
        }
        else if (gameLogic.difficultyIsHard == true)
        {
            xVelocity = 50f;
            moveSpeed = 15f;
        }
        else { return; }
    }
}