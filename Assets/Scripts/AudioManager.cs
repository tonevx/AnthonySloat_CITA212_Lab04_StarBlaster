using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Shooting Sounds")]
    [SerializeField] AudioClip shootingSound;
    [SerializeField] [Range(0f, 1f)] float shootingVolume;

    [Header("Damage Sounds")]
    [SerializeField] AudioClip damageSound;
    [SerializeField] [Range(0f, 1f)] float damageVolume;

    [Header("Death Sounds")]
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0f, 1f)] float deathVolume;

    public void PlayShootingSound()
    {
        PlaySound(shootingSound, shootingVolume);
    }
    public void PlayDamageSound()
    {
        PlaySound(damageSound, damageVolume);
    }
    public void PlayDeathSound()
    {
        PlaySound(deathSound, deathVolume);
    }

    public void PlaySound(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
        }
        else
        {
            Debug.LogWarning("Audio clip is not assigned.");
        }
    }
}
