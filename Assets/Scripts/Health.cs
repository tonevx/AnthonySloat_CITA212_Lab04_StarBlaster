using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int scorevalue = 50;
    [SerializeField] int health = 100;
    [SerializeField] ParticleSystem hitEffect;

    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;
    AudioManager audioManager;
    ScoreManager scoreManager;
    public int GetHealth()
    {
        return health;
    } 
    void Start()
    {
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            cameraShake = mainCamera.GetComponent<CameraShake>();
        }
        audioManager = FindAnyObjectByType<AudioManager>();
        scoreManager = FindAnyObjectByType<ScoreManager>();

        if (applyCameraShake && cameraShake == null)
        {
            Debug.LogWarning("Camera shake is enabled, but no main camera with CameraShake was found.", this);
        }
        if (audioManager == null)
        {
            Debug.LogWarning("No AudioManager was found; health sounds will be skipped.", this);
        }
        if (!isPlayer && scoreManager == null)
        {
            Debug.LogWarning("No ScoreManager was found; this object's score will not be added.", this);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();
        if(damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            damageDealer.Hit();
            if (applyCameraShake && cameraShake != null)
            {
                cameraShake.ShakeCamera();
            }
            if (audioManager != null)
            {
                audioManager.PlayDamageSound();
            }
        }
    }

    void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
        if (health <= 0)
        {
            Die();
            if (audioManager != null)
            {
                audioManager.PlayDeathSound();
            }
        }
    }
    void Die()
    {
        if (!isPlayer && scoreManager != null)
        {
            scoreManager.AddScore(scorevalue);
        }
        Destroy(gameObject);
    }
    void PlayHitEffect()
    {
        if (hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}
