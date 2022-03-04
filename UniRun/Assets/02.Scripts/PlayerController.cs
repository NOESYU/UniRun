using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip;
    public float jumpForce = 700f;
    
    private int jumpCount = 0;
    private bool isGrounded = false;
    private bool isDead = false;
    private Rigidbody2D playerRb;
    private AudioSource playerAudio;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAudio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;

        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            jumpCount++;

            // 점프속도, 높이 이상 방지
            playerRb.velocity = Vector2.zero;
            playerRb.AddForce(new Vector2(0, jumpForce));

            playerAudio.Play();
        }
        else if (Input.GetMouseButtonUp(0) && playerRb.velocity.y > 0)
        {
            playerRb.velocity = playerRb.velocity * 0.5f;
        }

        // 애니메이터 Grounded 파라미터 값 갱신
        animator.SetBool("Grounded", isGrounded);
    }

    void Die()
    {
        animator.SetTrigger("Die");
        playerAudio.clip = deathClip;
        playerAudio.Play();
        playerRb.velocity = Vector2.zero;
        isDead = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Dead" && !isDead)
        {
            Die();
        }   
    }

}
