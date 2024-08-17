using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //private bool facingRight = true;

    public float num;
    bool grounded;
    [SerializeField] float jump;
    public float speed;
    //-----//
    SpriteRenderer sr;
    Animator anm;
    Rigidbody2D rb;
    //-----//
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anm = GetComponent<Animator>();
    }

    void Update()
    {
        //Right&Left Movement
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            sr.flipX = true;

        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            sr.flipX = false;
        }

        //prevent the player from sliding after stop moving
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        //Jumping
        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            grounded = false;
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }

    }
    //void Flip()
    //{
    //    facingRight = !facingRight;
    //    Vector3 theScale = transform.localScale;
    //    theScale.x *= -1;
    //    transform.localScale = theScale;
    //}

    private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                grounded = true;
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                grounded = false;
            }
        }
    
}
