using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 0.5f;
    [SerializeField] float shakeMagnitude = 0.1f;

    Vector3 originalPosition;
    void Start()
    {
        originalPosition = transform.position;
    }
    public void ShakeCamera()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            while (elapsed < shakeDuration)
            {
                transform.position = originalPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
                elapsed += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
        }
        transform.position = originalPosition;
    }
}
