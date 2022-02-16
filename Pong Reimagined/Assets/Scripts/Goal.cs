using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    LogicSceneLoader logicSceneLoader;
    GameLogic gamelogic;
    public bool isPlayerGoal;
    public bool isLastLevel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        logicSceneLoader = FindObjectOfType<LogicSceneLoader>();
        gamelogic = FindObjectOfType<GameLogic>();
        if (other.gameObject.layer == 12)
        {
            if (isPlayerGoal == true)
            {
                gamelogic.enemyScore++;
                gamelogic.wasScoredOn = true;
                logicSceneLoader.ResetScene();
            }
            else
            {
                gamelogic.playerScore++;
                logicSceneLoader.ResetScene();
            }
        }
        else { return; }
    }
}