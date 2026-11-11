using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shooter : MonoBehaviour
{
    [Header("Shooter Settings")]
    [SerializeField] GameObject projectile;
    [SerializeField] float speed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float baseFireRate = 0.2f;
    [Header("AI Settings")]
    [SerializeField] bool useAI;
    [SerializeField] float minFireRate = 0.1f;
    [SerializeField] float fireRateVariance = 0f;
    [HideInInspector]public bool isFiring;
    Coroutine fireCoroutine;

    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
    }
    void Update()
    {
        Fire();
    }
    void Fire()
    {
        if (isFiring && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring && fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }
    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectile, transform.position, Quaternion.identity);
            instance.transform.rotation = transform.rotation;
            Rigidbody2D projectileRB = instance.GetComponent<Rigidbody2D>();
            projectileRB.linearVelocity = transform.up * speed;
            Destroy(instance, projectileLifetime);
            float waitTime = Random.Range(minFireRate, baseFireRate + fireRateVariance);
            waitTime = Mathf.Clamp(waitTime, minFireRate, float.MaxValue);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
