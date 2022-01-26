using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float yMin = -8f;
    [SerializeField] float yMax = 8f;
    [SerializeField] float xMin = -18.5f;
    [SerializeField] float xMax = -1.3f;
    Rigidbody2D rB;

    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
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
}
