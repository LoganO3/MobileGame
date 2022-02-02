using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float yMin = -8f;
    [SerializeField] float yMax = 8f;
    [SerializeField] float xMin = -18.5f;
    [SerializeField] float xMax = -1.3f;

    public float acceleration = 10000f;
    public Vector2 totalForceY;
    public Vector2 totalForceX;

    // Start is called before the first frame update
    void Start()
    {
        totalForceY = new Vector2(0, acceleration);
        totalForceX = new Vector2(acceleration, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 paddlePos = new Vector3(transform.position.x, transform.position.y, 0);
        paddlePos.y = Mathf.Clamp(mousePostion.y, yMin, yMax);
        paddlePos.x = Mathf.Clamp(mousePostion.x, xMin, xMax);
        transform.position = paddlePos;
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
}


