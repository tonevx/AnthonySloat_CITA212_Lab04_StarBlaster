using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 2f;

    ScoreManager scoreManager;

    void Awake()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("GameScreen");
        scoreManager.ResetScore();
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver", 2f));
        StartCoroutine(WaitAndLoad("GameOver", sceneLoadDelay));
    }

    public void LoadGameStart()
    {
        SceneManager.LoadScene("GameStart");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void RestartGameOnLoss()
    {
        SceneManager.LoadScene("GameScreen");
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
