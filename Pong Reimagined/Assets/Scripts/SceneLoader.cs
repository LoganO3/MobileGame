using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]int sceneNumber;
    Pause pause;
    public void Start()
    {
        pause = FindObjectOfType<Pause>();
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
        FindObjectOfType<GameLogic>().Reset();
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex);
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        pause.removePauseMenu();
        FindObjectOfType<GameLogic>().Reset();
    }
    public void LoadGameOver()
    {
        SceneManager.LoadScene(5);
    }
    public void LoadVictory()
    {
        SceneManager.LoadScene(4);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

