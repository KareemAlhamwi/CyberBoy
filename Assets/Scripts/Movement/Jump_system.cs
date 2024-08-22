using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_system : MonoBehaviour
{
    [Header("Float settings")]
    [SerializeField] float floatForce = 5.0f; 
    [SerializeField] float maxFloatTime = 2.0f; 


    [Header("Recharge settings")]
    [SerializeField] float minRechargeTime = 0.1f;
    [SerializeField] float maxRechargeTime = 3.0f; 
    float rechargeTime;


    private Rigidbody2D rb;
    private bool isFloating = false;
    private bool canFloat = true;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isFloating && canFloat)
        {
            StartCoroutine(FloatUp());
        }
    }

    IEnumerator FloatUp()
    {

        isFloating = true;
        canFloat = false;
        float elapsedTime = 0.0f;

        while (elapsedTime < maxFloatTime && Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, floatForce);
            elapsedTime += Time.deltaTime;
            yield return null;
        }


        rb.velocity = new Vector2(rb.velocity.x, 0);
        isFloating = false;


        rechargeTime = Mathf.Lerp(0.1f, maxRechargeTime, elapsedTime / maxFloatTime);
        yield return new WaitForSeconds(rechargeTime);


        canFloat = true;
    }
}

    //[SerializeField] private LayerMask groundLayer;
    //[SerializeField] private Transform groundCheck;
    //[SerializeField] private Vector2 checkSize = new Vector2(0.5f, 0.1f);
    //[SerializeField] private float jumpForce = 5f;
    //private Rigidbody2D rb;
    //private bool isGrounded;
    //[SerializeField] AudioSource jump;
    //Animator anm;
    //void Start()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //    anm = GetComponent<Animator>();
    //}

//void Update()
//{
//    isGrounded = Physics2D.OverlapBox(groundCheck.position, checkSize, 0f, groundLayer);

//    if (isGrounded && Input.GetButtonDown("Jump"))
//    {
//        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
//        jump.Play();
//    }
//}
//private void OnCollisionStay2D(Collision2D other)
//{
//    if (other.gameObject.CompareTag("Ground"))
//    {
//        anm.SetBool("IsJumping", false);
//    }
//}
//private void OnCollisionExit2D(Collision2D collision)
//{
//    if (collision.gameObject.CompareTag("Ground"))
//    {
//        anm.SetBool("IsJumping", true);
//    }
//}
////private void OnTriggerStay2D(Collider2D other)
////{
////    if (other.gameObject.CompareTag("Ground"))
////    {
////        anm.SetBool("IsJumping", false);
////    }
////}
////private void OnTriggerExit2D(Collider2D collision)
////{
////    if (collision.gameObject.CompareTag("Ground"))
////    {
////        anm.SetBool("IsJumping", true);
////    }
////}
//void OnDrawGizmos()
//{
//    Gizmos.color = Color.red;
//    Gizmos.DrawWireCube(groundCheck.position, checkSize);
//}


