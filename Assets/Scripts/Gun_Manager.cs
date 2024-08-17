using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Gun_Manager : MonoBehaviour
{
    [Header("Gun")]
    [SerializeField] Transform gun;
    [SerializeField] float gun_distance;

    [Header("Bullet")]
    [SerializeField] GameObject bulletPreFab;
    [SerializeField] float bulletSpeed;
    
    void Update()
    {
        //============================//
        //Gun rotation
        // Get the mouse position in world coordinates
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; // Ensure the z position is zero since we're in 2D

        // Calculate the direction from the player to the mouse position
        Vector3 direction = mousePos - transform.position;

        // Calculate the angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply the rotation to the gun
        gun.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Position the gun at the specified distance from the player
        gun.position = transform.position + direction.normalized * gun_distance;
        //============================//

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            shoot(direction);
        }
    }
    public void shoot(Vector3 direction)
    {
       GameObject newbullet = Instantiate(bulletPreFab,gun.position, Quaternion.identity);
        newbullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * bulletSpeed;
    }
}
