using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    SceneLoader sceneLoader;
    GameLogic gamelogic;
    public bool isPlayerGoal;

    private void OnTriggerEnter2D(Collider2D other)
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        gamelogic = FindObjectOfType<GameLogic>();
        if (other.gameObject.layer == 12)
        {
            if (isPlayerGoal == true)
            {
                gamelogic.enemyScore++;
                sceneLoader.ResetScene();
            }
            else
            {
                gamelogic.playerScore++;
                sceneLoader.ResetScene();
            }
        }
        else { return; }
    }
}