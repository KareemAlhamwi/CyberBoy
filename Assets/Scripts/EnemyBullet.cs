using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Rigidbody2D rb;
    ScaleObject so;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    }

    void Update()
    {
        transform.right = rb.velocity;
        Invoke("destroybullet", 3f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //kil
            StartCoroutine(DestroyBullet());
        }
    }
    void destroybullet()
    {
        Destroy(gameObject);
    }
    private IEnumerator DestroyBullet()
    {
        yield return new WaitForEndOfFrame(); // Wait for the end of the frame
        Destroy(gameObject); // Destroy the bullet after the delay
    }
}
