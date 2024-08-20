using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullet : MonoBehaviour
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
        Invoke("destroybullet", 3f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Draggable"))
        {
            so.HandleHit();
            StartCoroutine(DestroyBullet());
        }
        else if (other.gameObject.CompareTag("DraggableOEnemy"))
        {
            so.HandleHit();
            StartCoroutine(DestroyBullet());
        }
        else if (other.gameObject.CompareTag("Ground"))
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
