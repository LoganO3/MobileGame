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
    float difficultyMoveSpeed;
    float timerCurrentCount = 5f;
    float timerTarget = 5f;
    float timeWithAbility = 3f;
    float acceleration = 10000f;
    float combinedSpeed;
    bool timerOver = false;
    [SerializeField] bool abilityIsSizeChange = false;
    [SerializeField] bool abilityIsSpeedChange = false;
    [SerializeField] bool abilityIsIncreasedPuckForce = false;
    Rigidbody2D rB;
    Puck puck;
    GameLogic gameLogic;

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
        puckLocation.y = Mathf.Clamp(puckLocation.y, yMin, yMax);
        puckLocation.x = Mathf.Clamp(puckLocation.x, xMin, xMax);
        AbilityTimer();
        Move(puckLocation, moveSpeed);
    }

    private void CheckDifficulty()
    {
        gameLogic = FindObjectOfType<GameLogic>();
        if (gameLogic.difficultyIsEasy == true)
        {
            difficultyMoveSpeed = 5f;
            moveSpeed = difficultyMoveSpeed;
        }
        else if (gameLogic.difficultyIsMedium == true)
        {
            difficultyMoveSpeed = 15f;
            moveSpeed = difficultyMoveSpeed;
        }
        else if (gameLogic.difficultyIsHard == true)
        {
            difficultyMoveSpeed = 25f;
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
        Debug.Log("Touch");
        if (transform.position.y < collision.transform.position.y)
        {
            collision.otherRigidbody.AddForce(totalForceY);
            Debug.Log("Hit Up");
        }
        else if (transform.position.y > collision.transform.position.y)
        {
            collision.otherRigidbody.AddForce(-totalForceY);
            Debug.Log("Hit Dowm");
        }
        if (transform.position.x < collision.transform.position.x)
        {
            collision.otherRigidbody.AddForce(totalForceX);
            Debug.Log("Hit right");
        }
        else if (transform.position.x > collision.transform.position.x)
        {
            collision.otherRigidbody.AddForce(-totalForceX);
            Debug.Log("Hit left");
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
                    Debug.Log("Ability");
                    puck.maxVelocity = puck.difficultyMaxVelocity;
                    acceleration = 10000f;
                    timerCurrentCount = timerTarget;
                    timerOver = false;
                }
                else if (acceleration == 10000f)
                {
                    Debug.Log("Ability");
                    puck.maxVelocity = 100;
                    acceleration = 20000f;
                    timerCurrentCount = timeWithAbility;
                    timerOver = false;
                }
            }
        }
    }
}