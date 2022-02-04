using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    SceneLoader sceneLoader;
    public int playerScore;
    public int enemyScore;
    public bool difficultyIsEasy = false;
    public bool difficultyIsMedium = false;
    public bool difficultyIsHard = false;

    private void Awake()
    {
        SetUpSingleton();
    }

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>(); 
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
        if (playerScore >= 7) 
        {
            sceneLoader.LoadGameOver();
            Reset();
        }
        if (enemyScore >= 7)
        {
            sceneLoader.LoadGameOver();
            Reset();
        }
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
    public void SetDifficultyEasy()
    {
        difficultyIsEasy = true;
        difficultyIsMedium = false;
        difficultyIsHard = false;
    }
    public void SetDifficultyMedium()
    {
        difficultyIsEasy = false;
        difficultyIsMedium = true;
        difficultyIsHard = false;
    }
    public void SetDifficultyHard()
    {
        difficultyIsEasy = false;
        difficultyIsMedium = false;
        difficultyIsHard = true;
    }
}

