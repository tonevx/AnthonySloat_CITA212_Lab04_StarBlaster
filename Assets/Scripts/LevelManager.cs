using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("GameScreen");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver", 2f));
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
