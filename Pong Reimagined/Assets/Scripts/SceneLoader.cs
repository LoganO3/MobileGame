using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    int sceneNumber;
    Pause pause;
    public void Start()
    {
        pause = FindObjectOfType<Pause>();
    }

    [SerializeField] float delayInSeconds = 1f;
    public void LoadNextScene()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex + 1);
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
        SceneManager.LoadScene(4);
    }
    public void LoadVictory()
    {
        SceneManager.LoadScene(3);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

