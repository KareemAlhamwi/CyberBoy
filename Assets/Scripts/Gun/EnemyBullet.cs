using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Rigidbody2D rb;
    ScaleObject so;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        so = GameObject.FindGameObjectWithTag("Draggable").GetComponent<ScaleObject>();
    }

    void Update()
    {
        transform.right = rb.velocity;
    }

    private void OnTriggerEnter2D(Collider2D other2)
    {
        if (other2.gameObject.CompareTag("Draggable"))
        {
            other2.gameObject.GetComponent<ScaleObject>().HandleHitSmall();
            StartCoroutine(DestroyBullet());
        }
        else if (other2.gameObject.CompareTag("Ground"))
        {
            destroybullet();
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
