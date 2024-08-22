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
    [SerializeField] Transform GunFirePoint;
    [SerializeField] SpriteRenderer gunSpriteRenderer;
    [SerializeField] Sprite[] gunSprites;
    bool gunfacingright;
    [Header("Bullet")]
    [SerializeField] GameObject[] bulletsPreFabs;
    [SerializeField] float bulletSpeed;
    private float timeSinceLastShot = 0.0f;
    public float shootDelay = 0.6f;
    private int currentBulletIndex = 0;
    public float scroll;
    [SerializeField] AudioSource lazer;
    private void Start()
    {
        timeSinceLastShot = 0.6f;
     }
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

        //gun flip
        gunflipcontroller(mousePos);
        //============================//


        //============================//
        //shoot
        timeSinceLastShot += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse0) && timeSinceLastShot >= shootDelay)
        {

            shoot(direction); 
            timeSinceLastShot = 0.0f;
            lazer.Play();
        }
        //============================//


        //============================//
        //scroll to change bullets
        scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            // Change the current bullet index based on scroll direction
            if (scroll > 0)
            {
                currentBulletIndex = (currentBulletIndex + 1) % bulletsPreFabs.Length;
            }
            else if (scroll < 0)
            {
                currentBulletIndex = (currentBulletIndex - 1 + bulletsPreFabs.Length) % bulletsPreFabs.Length;
            }
            gunSpriteRenderer.sprite = gunSprites[currentBulletIndex];
        }
        //============================//

    }
    void gunflipcontroller(Vector3 mousepos)
    {
        if (mousepos.x > gun.position.x && gunfacingright)
        {
            gunflip();
        }
        else if(mousepos.x < gun.position.x && !gunfacingright)
        {
            gunflip();
        }
    }
    void gunflip()
    {
        gunfacingright = !gunfacingright;
        gun.localScale = new Vector3(gun.localScale.x, gun.localScale.y * -1 ,gun.localScale.z);
    }
    public void shoot(Vector3 direction)
    {
        GameObject bulletPrefab = bulletsPreFabs[currentBulletIndex];
        GameObject newbullet = Instantiate(bulletPrefab, GunFirePoint.position, Quaternion.identity);
        newbullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * bulletSpeed;
    }
}
