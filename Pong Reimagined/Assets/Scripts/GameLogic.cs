using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    SceneLoader sceneLoader;
    Achievements achievements;
    Goal goal;
    public int playerScore;
    public int enemyScore;
    public float totalTime;
    public bool wasScoredOn;
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
        achievements = FindObjectOfType<Achievements>();
        goal = FindObjectOfType<Goal>();
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
        if (goal.isLastLevel == true)
        {
            if (playerScore >= 7)
            {
                sceneLoader.LoadVictory();
                Reset();
            }
            if (enemyScore >= 7)
            {
                sceneLoader.LoadGameOver();
                Reset();
            }
        }
        else
        {
            if (playerScore >= 7)
            {
                sceneLoader.LoadNextScene();
                Reset();
            }
            if (enemyScore >= 7)
            {
                sceneLoader.LoadNextScene();
                Reset();
            }
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
        wasScoredOn = false;
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

    public void WonInTime()
    {
        if (totalTime <= 300 && difficultyIsEasy == true)
        {
            achievements.hasCompletedEasyTimeTrial = true;
        }
        if (totalTime <= 300 && difficultyIsMedium == true)
        {
            achievements.hasCompletedIntermeidateTimeTrial = true;
        }
        if (totalTime <= 300 && difficultyIsHard == true)
        {
            achievements.hasCompletedHardTimeTrial = true;
        }
        else
        {
            return;
        }
    }

    public void DidNotGetScoredOn()
    {
        if (wasScoredOn == false && difficultyIsEasy == true)
        {
            achievements.hasCompletedEasyPointTrial = true;
        }
        if (wasScoredOn == false && difficultyIsMedium == true)
        {
            achievements.hasCompletedIntermeidatePointTrial = true;
        }
        if (wasScoredOn == false && difficultyIsHard == true)
        {
            achievements.hasCompletedHardPointTrial = true;
        }
        else
        {
            return;
        }
    }
}

