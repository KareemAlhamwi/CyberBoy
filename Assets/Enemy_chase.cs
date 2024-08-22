using NUnit.Framework.Constraints;
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
    Animator anm;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
        sr = GetComponent<SpriteRenderer>();
        anm = GetComponent<Animator>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > mindist)
        {
            FollowPlayer();
        }
        else
        {
            anm.SetTrigger("hit");
        }
        if (player.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }
    void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x,transform.position.y), speed * Time.deltaTime);
    }
}
