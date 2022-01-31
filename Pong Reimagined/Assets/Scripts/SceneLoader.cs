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
        pause.removePauseMenu();
        FindObjectOfType<GameLogic>().Reset();
        SceneManager.LoadScene(0);
    }
    public void LoadGameOver()
    {
        StartCoroutine(DelayForSeconds());
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    IEnumerator DelayForSeconds()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene(2);
    }
}

