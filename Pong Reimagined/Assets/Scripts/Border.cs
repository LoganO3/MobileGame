using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    Vector2 totalForceY = new Vector2 (0, 1);
    Vector2 totalForceX = new Vector2 (1, 0);
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
