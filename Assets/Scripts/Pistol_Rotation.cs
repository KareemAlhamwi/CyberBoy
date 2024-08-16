using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Pistol_Rotation : MonoBehaviour
{
    bool CanFire;
    float timer;
    [SerializeField] float TimeBetweenShots;
    [SerializeField] GameObject bulletPreFab;
    [SerializeField] Transform bulletpoint;
    [SerializeField] float speed;
    [SerializeField] float bulletSpeed;
    public Collider2D playerCollider;
    Camera cam;
    Transform playerTransform;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        playerTransform = transform.parent;
    }

    void Update()
    {
        // Get the mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Ensure the z position is zero since we're in 2D

        // Calculate the direction from the pistol to the mouse position
        Vector3 direction = mousePosition - transform.position;

        // Calculate the angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply the rotation to the pistol
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90)); // Adjust the angle by
        if (!CanFire)
        {
            timer += Time.deltaTime;
            if (timer > TimeBetweenShots)
            {
                CanFire = true;
                timer = 0;
            }
        }
        if (Input.GetMouseButtonDown(0) && CanFire)
        {
            CanFire = false;
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate the bullet at the fire point
        GameObject bullet = Instantiate(bulletPreFab, bulletpoint.position, bulletpoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = bulletpoint.up * bulletSpeed; // Set the bullet's velocity
        Collider2D bulletCollider = bullet.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(bulletCollider, playerCollider);

    }

}
