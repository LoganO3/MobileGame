using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public int playerScore;
    public int enemyScore;

    private void Awake()
    {
        SetUpSingleton();
    }

    // Start is called before the first frame update
    void Start()
    {
        
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

    // Update is called once per frame
    void Update()
    {
    }

    public int getPlayerScore()
    {
        return playerScore;
    }
    public int getEnemyScore()
    {
        return enemyScore;
    }
    public void Reset()
    {
        playerScore = 0;
        enemyScore = 0;
    }
}

