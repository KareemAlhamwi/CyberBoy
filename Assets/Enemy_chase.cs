using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_chase : MonoBehaviour
{
    public float speed = 2.0f;
    public float jumpForce = 5.0f;
    public float mindist;
    private Transform player;
    SpriteRenderer sr;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > mindist)
        {
            FollowPlayer();
        }
        else
        {
            //attack()
        }
        if(player.transform.position.x < transform.position.x)
        {
            sr.flipX = false;
        }
        else if (player.transform.position.x > transform.position.x)
        {
            sr.flipX = true;

        }
    }
    void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x,transform.position.y), speed * Time.deltaTime);
    }
}
