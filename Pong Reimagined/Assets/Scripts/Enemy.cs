using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    float difficultyMoveSpeed;
    float timerCurrentCount = 5f;
    float timerTarget = 5f;
    float timeWithAbility = 3f;
    float acceleration = 20000f;
    float combinedSpeed;
    bool timerOver = false;
    [SerializeField] bool abilityIsSizeChange = false;
    [SerializeField] bool abilityIsSpeedChange = false;
    [SerializeField] bool abilityIsIncreasedPuckForce = false;
    Rigidbody2D rB;
    Puck puck;
    GameLogic gameLogic;
    Vector3 puckLocation;

    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        puck = FindObjectOfType<Puck>();
        gameLogic = FindObjectOfType<GameLogic>();
        CheckDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 puckLocation = puck.CurrentLocation();
        AbilityTimer();
        MovementChecksAndConstrants();
        Move(puckLocation, moveSpeed);
    }

    private void MovementChecksAndConstrants()
    {
        if (puck.CurrentLocation().x < -.5)
        {
            puckLocation.x = puck.CurrentLocation().x + 10f;
            puckLocation.y = puck.CurrentLocation().y;
        }
        else if (transform.position.x > puck.CurrentLocation().x)
        {
            if (transform.position.y < puckLocation.y + 1 && transform.position.y > puckLocation.y - 1)
            {
                puckLocation.x = puck.CurrentLocation().x;
                puckLocation.y = puck.CurrentLocation().y;
            }
            else
            {
                puckLocation.y = puck.CurrentLocation().y;
            }
        }
        else if (transform.position.x <= puck.CurrentLocation().x)
        {
            if (transform.position.y == puckLocation.y)
            {
                puckLocation.x = puck.CurrentLocation().x;
            }
            else if (puck.CurrentLocation().y >= 0)
            {
                puckLocation.y = puckLocation.y - 5;
                puckLocation.x = puckLocation.x + 5;
            }
            else
            {
                puckLocation.y = puckLocation.y + 5;
                puckLocation.x = puckLocation.x + 5;
            }
        }
    }

    private void CheckDifficulty()
    {
        gameLogic = FindObjectOfType<GameLogic>();
        if (gameLogic.difficultyIsEasy == true)
        {
            difficultyMoveSpeed = 20f;
            moveSpeed = difficultyMoveSpeed;
        }
        else if (gameLogic.difficultyIsMedium == true)
        {
            difficultyMoveSpeed = 30f;
            moveSpeed = difficultyMoveSpeed;
        }
        else if (gameLogic.difficultyIsHard == true)
        {
            difficultyMoveSpeed = 50f;
            moveSpeed = difficultyMoveSpeed;
        }
        else { return; }
    }

    private void Move(Vector3 target, float movementSpeed)
    {
        transform.position += (target - transform.position).normalized * movementSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 totalForceY = new Vector2(0, acceleration);
        Vector2 totalForceX = new Vector2(acceleration, 0);
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

    private void AbilityTimer()
    {
        timerCurrentCount -= Time.deltaTime;
        if (abilityIsSizeChange == true)
        {
            if (timerCurrentCount <= 0)
            {
                timerOver = true;
            }
            if (timerOver == true)
            {
                if (transform.localScale == new Vector3(8, 8, 1))
                {
                    transform.localScale = new Vector3(4, 4, 1);
                    timerCurrentCount = timerTarget;
                    timerOver = false;
                }
                else if (transform.localScale == new Vector3(4, 4, 1))
                {
                    transform.localScale = new Vector3(8, 8, 1);
                    timerCurrentCount = timeWithAbility;
                    timerOver = false;
                }
            }
        }
        if (abilityIsSpeedChange == true)
        {
            if (timerCurrentCount <= 0)
            {
                timerOver = true;
            }
            if (timerOver == true)
            {
                if (moveSpeed >= 2 * difficultyMoveSpeed)
                {
                    moveSpeed = difficultyMoveSpeed;
                    timerCurrentCount = timerTarget;
                    timerOver = false;
                }
                else if (moveSpeed <= difficultyMoveSpeed)
                {
                    moveSpeed = difficultyMoveSpeed + difficultyMoveSpeed;
                    timerCurrentCount = timeWithAbility;
                    timerOver = false;
                }
            }
        }
        if (abilityIsIncreasedPuckForce == true)
        {
            if (timerCurrentCount <= 0)
            {
                timerOver = true;
            }
            if (timerOver == true)
            {
                if (acceleration == 20000f)
                {
                    puck.maxVelocity = puck.difficultyMaxVelocity;
                    acceleration = 10000f;
                    timerCurrentCount = timerTarget;
                    timerOver = false;
                }
                else if (acceleration == 10000f)
                {
                    puck.maxVelocity = 100;
                    acceleration = 20000f;
                    timerCurrentCount = timeWithAbility;
                    timerOver = false;
                }
            }
        }
    }
}