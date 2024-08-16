using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullet : MonoBehaviour
{
    float timer;
    public float speed = 20f;
    private Vector2 target;
    void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void Update()
    {
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        transform.position = (Vector2)transform.position + direction * speed * Time.deltaTime;

        if (Vector2.Distance(transform.position, target) < 0.1f)
        {
            target = target + direction * 10f;
        }
        timer += Time.deltaTime;
        if (timer > 2f)
        {
            Destroy(gameObject);
        }
    }
}
