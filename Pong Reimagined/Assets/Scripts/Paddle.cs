using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float yMin = -10f;
    [SerializeField] float yMax = 10f;
    [SerializeField] float xMin = -21.5f;
    [SerializeField] float xMax = 0f;

    // Start is called before the first frame update
    void Start()
    {

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
