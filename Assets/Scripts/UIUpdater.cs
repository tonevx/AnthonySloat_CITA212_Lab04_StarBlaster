using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIUpdater : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreManager scoreManager;
    void Start()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();
        healthSlider.maxValue = playerHealth.GetHealth();
    }
    void Update()
    {
        UpdateScore();
        UpdateHealth();
    }

    void UpdateScore()
    {
        scoreText.text = scoreManager.GetScore().ToString("0000000");
    }
    void UpdateHealth()
    {
        healthSlider.value = playerHealth.GetHealth();
    }
}
