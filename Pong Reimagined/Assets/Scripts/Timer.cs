using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    TextMeshProUGUI timerText;
    float time = 0f;

    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        time += Time.deltaTime;
        string Seconds = ((int)time % 60).ToString();
        string Minutes = ((int)time / 60).ToString();
        string Hours = ((int)time / 3600).ToString();
        timerText.text = Hours + ":" + Minutes + ":" + Seconds;
    }
}
