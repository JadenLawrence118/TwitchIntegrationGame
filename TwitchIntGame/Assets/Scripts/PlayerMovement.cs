using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private float jumpHeight = 5.0f;

    private Animator animator;
    private bool grounded = true;
    private Vector2 respawnPoint;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        respawnPoint = transform.position;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0)
        {
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }


        // left/right

        if (horizontalInput < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (horizontalInput > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    private void FixedUpdate()
    {
        // left/right
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector2 direction = new Vector2(horizontalInput, 0);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(direction.x * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

        animator.SetFloat("yVelocity", rb.velocity.y);

        // jumping
        float jumpInput = Input.GetAxis("Jump");

        if (grounded && jumpInput > 0)
        {
            rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Platform" || collision.tag == "Ground")
        {
            animator.SetBool("grounded", true);
            grounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Platform" || collision.tag == "Ground")
        {
            animator.SetBool("grounded", false);
            grounded = false;
        }
    }

    public void SetRespawn(Vector2 location)
    {
        respawnPoint = location;
        print(respawnPoint);
    }

    public void Die()
    {
        transform.position = respawnPoint;
    }
}