using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    GameLogic gameLogic;
    public bool isPlayerScore;

    // Use this for initialization
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        gameLogic = FindObjectOfType<GameLogic>();
        if (isPlayerScore == true)
        {
            scoreText.text = gameLogic.getPlayerScore().ToString();
        }
        else
        {
            scoreText.text = gameLogic.getEnemyScore().ToString();
        }
    }
}
