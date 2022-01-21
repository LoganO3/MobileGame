using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePaddle : MonoBehaviour
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
    if (Input.touchCount > 0)
    {
        Touch touch = Input.GetTouch(0);
        Vector3 touchPostion = Camera.main.ScreenToWorldPoint(touch.position);
        Vector3 paddlePos = new Vector3(transform.position.x, transform.position.y, 0);
        paddlePos.y = Mathf.Clamp(touchPostion.y, yMin, yMax);
        paddlePos.x = Mathf.Clamp(touchPostion.x, xMin, xMax);
        transform.position = paddlePos;
    }
}
}
