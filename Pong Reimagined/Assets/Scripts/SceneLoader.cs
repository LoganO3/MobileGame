using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]int sceneNumber;
    Pause pause;
    GameLogic gameLogic;
    Timer timer;
    Achievements achievements;
    public void Start()
    {
        pause = FindObjectOfType<Pause>();
        gameLogic = FindObjectOfType<GameLogic>();
    }
    public void LoadNextScene()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex + 1);
    }
    public void LoadSceneTwoAway()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex + 2);
    }
    public void LoadSceneThreeAway()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex + 3);
    }
    public void LoadPreviousScene()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex - 1);
    }
    public void LoadSpecificScene()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneNumber);
    }
    public void ResetScene()
    {
        pause.removePauseMenu();
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex);
    }
    public void CompleteResetScene()
    {
        pause.removePauseMenu();
        gameLogic.Reset();
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex);
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        pause.removePauseMenu();
        gameLogic.Reset();
    }
    public void LoadGameOver()
    {
        timer = FindObjectOfType<Timer>();
        gameLogic.totalTime = timer.time;
        SceneManager.LoadScene(6);
        Destroy(timer);
    }
    public void LoadVictory()
    {
        timer = FindObjectOfType<Timer>();
        gameLogic.totalTime = timer.time;
        gameLogic.DidNotGetScoredOn();
        gameLogic.WonInTime();
        SceneManager.LoadScene(5);
        Destroy(timer);
    }
    public void Loadachievements()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

