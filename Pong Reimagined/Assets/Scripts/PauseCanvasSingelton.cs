using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCanvasSingelton : MonoBehaviour
{
    private void Awake()
    {
        SetUpSingleton();
    }

    public void Start()
    {
        gameObject.SetActive(false);
    }

    private void SetUpSingleton()
    {
        int numberGameStatus = FindObjectsOfType<GameLogic>().Length;
        if (numberGameStatus > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
