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
        if (Seconds == "9")
        {
            timerText.text = Hours + ":" + Minutes + ":0" + Seconds;
        }
        else if (Seconds == "8")
        {
            timerText.text = Hours + ":" + Minutes + ":0" + Seconds;
        }
        else if (Seconds == "7")
        {
            timerText.text = Hours + ":" + Minutes + ":0" + Seconds;
        }
        else if (Seconds == "6")
        {
            timerText.text = Hours + ":" + Minutes + ":0" + Seconds;
        }
        else if (Seconds == "5")
        {
            timerText.text = Hours + ":" + Minutes + ":0" + Seconds;
        }
        else if (Seconds == "4")
        {
            timerText.text = Hours + ":" + Minutes + ":0" + Seconds;
        }
        else if (Seconds == "3")
        {
            timerText.text = Hours + ":" + Minutes + ":0" + Seconds;
        }
        else if (Seconds == "2")
        {
            timerText.text = Hours + ":" + Minutes + ":0" + Seconds;
        }
        else if (Seconds == "1")
        {
            timerText.text = Hours + ":" + Minutes + ":0" + Seconds;
        }
        else if (Seconds == "0")
        {
            timerText.text = Hours + ":" + Minutes + ":0" + Seconds;
        }
        else
        {
            timerText.text = Hours + ":" + Minutes + ":" + Seconds;
        }
    }
}
