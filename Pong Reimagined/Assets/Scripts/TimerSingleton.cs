using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSingleton : MonoBehaviour
{
    private void Awake()
    {
        SetUpSingleton();
    }
    private void SetUpSingleton()
    {
        int numberGameStatus = FindObjectsOfType<TimerSingleton>().Length;
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
