using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    public int GetScore()
    {
        return score;
    }

    public void AddScore(int points)
    {
        score += points;
        score = Mathf.Clamp(score, 0, int.MaxValue);
        Debug.Log(score);
    }
    public void ResetScore()
    {
        score = 0;
    }
}
