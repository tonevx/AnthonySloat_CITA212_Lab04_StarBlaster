using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float speed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float fireRate = 0.2f;
    public bool isFiring;
    Coroutine fireCoroutine;

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
            Rigidbody2D projectileRB = instance.GetComponent<Rigidbody2D>();
            projectileRB.linearVelocityY = speed;
            Destroy(instance, projectileLifetime);
            yield return new WaitForSeconds(fireRate);
        }
    }
}
