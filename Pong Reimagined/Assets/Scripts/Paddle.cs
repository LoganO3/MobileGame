using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    internal object trnasform;
    [SerializeField] float ScreenWidthUnits = 16f;
    [SerializeField] float yMin = 1f;
    [SerializeField] float yMax = 15f;
    [SerializeField] float xMin = 1f;
    [SerializeField] float xMax = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.y = Mathf.Clamp(GetYPos(), yMin, yMax);
        paddlePos.x = Mathf.Clamp(GetXPos(), xMin, xMax);
        transform.position = paddlePos;
        Debug.Log(Input.mousePosition);
        Debug.Log(paddlePos);
        Debug.Log(Screen.width);
    }

    private float GetYPos()
    {
        return (Input.mousePosition.y / Screen.width * ScreenWidthUnits);
    }

    private float GetXPos()
    {
        return (Input.mousePosition.x / Screen.width * ScreenWidthUnits);
    }
}
