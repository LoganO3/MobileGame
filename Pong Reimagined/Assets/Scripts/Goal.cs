using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    SceneLoader sceneLoader;
    GameLogic gamelogic;
    public bool isPlayerGoal;
    // Start is called before the first frame update
    void Start()
    {
       sceneLoader = FindObjectOfType<SceneLoader>();
       gamelogic = FindObjectOfType<GameLogic>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 12)
        {
            Debug.Log("Hit");
            if (isPlayerGoal == true)
            {
                gamelogic.enemyScore++;
                Debug.Log("Enemy Scored");
                sceneLoader.ResetScene();
            }
            else
            {
                gamelogic.playerScore++;
                Debug.Log("Player Scored");
                sceneLoader.ResetScene();
            }
        }
        else { return; }
    }
}