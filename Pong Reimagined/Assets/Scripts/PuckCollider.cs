using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckCollider : MonoBehaviour
{
    [SerializeField] float newVelocity = 2f;
    [SerializeField] bool isVertical;
    Puck puck;

    // Start is called before the first frame update
    void Start()
    {
        puck = FindObjectOfType<Puck>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Hit");
        if (isVertical == true)
        {
            if (other.gameObject.layer == 10)
            {
                puck.returnRigidbody().velocity = new Vector3(puck.returnRigidbody().velocity.x, puck.returnRigidbody().velocity.y + newVelocity, 0);
            }
            if (other.gameObject.layer == 11)
            {
                puck.returnRigidbody().velocity = new Vector3(puck.returnRigidbody().velocity.x, puck.returnRigidbody().velocity.y + newVelocity, 0);
            }
            else { puck.returnRigidbody().velocity = new Vector3(puck.returnRigidbody().velocity.x, puck.returnRigidbody().velocity.y, 0); }
        }
        else
        {
            if (other.gameObject.layer == 10)
            {
                puck.returnRigidbody().velocity = new Vector3(puck.returnRigidbody().velocity.x + newVelocity, puck.returnRigidbody().velocity.y, 0);
            }
            if (other.gameObject.layer == 11)
            {
                puck.returnRigidbody().velocity = new Vector3(puck.returnRigidbody().velocity.x + newVelocity, puck.returnRigidbody().velocity.y, 0);
            }
            else { puck.returnRigidbody().velocity = new Vector3(puck.returnRigidbody().velocity.x, puck.returnRigidbody().velocity.y, 0); }
        }
    }
}
