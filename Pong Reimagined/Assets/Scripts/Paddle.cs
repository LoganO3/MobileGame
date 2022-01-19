using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    internal object trnasform;
    [SerializeField] float ScreenWidthUnits = 16f;
    [SerializeField] float yMin = 1f;
    [SerializeField] float yMax = 15f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.y = Mathf.Clamp(GetYPos(), yMin, yMax);
        transform.position = paddlePos;
    }

    private float GetYPos()
    {
        return (Input.mousePosition.y / Screen.width * ScreenWidthUnits);
    }
}
