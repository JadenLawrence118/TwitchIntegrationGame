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

    public ContactFilter2D castFilter;
    public float groundDistance = 0.05f;
    private CapsuleCollider2D coll;
    RaycastHit2D[] groundHits = new RaycastHit2D[4];

    private void Awake()
    {
        coll = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
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

        if (isGrounded() && jumpInput > 0)
        {
            rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        }
    }

    bool isGrounded()
    {
        if (coll.Cast(Vector2.down, castFilter, groundHits, groundDistance) > 0)
        {
            animator.SetBool("grounded", true);
            return true;
        }
        else
        {
            animator.SetBool("grounded", false);
            return false;
        }
    }
}