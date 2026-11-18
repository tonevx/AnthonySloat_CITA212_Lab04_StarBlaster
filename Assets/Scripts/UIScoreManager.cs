using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    ScoreManager scoreManager;

    void Awake()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();
    }

    void Start()
    {
        scoreText.text = "FINAL SCORE:\n" + scoreManager.GetScore();
    }
}

