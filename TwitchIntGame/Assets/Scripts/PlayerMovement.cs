using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private Vector2 jumpHeight;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;
    void Start()
    {

    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0)
        {
            GetComponent<Animator>().SetBool("moving", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("moving", false);
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
        float horizontalInput = Input.GetAxis("Horizontal");


        // left/right
        Vector2 direction = new Vector2(horizontalInput, 0);

        GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);



        float jumpInput = Input.GetAxis("Jump");

        // jumping
        if (isGrounded() && jumpInput > 0)
        {
            GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
        }
    }

    bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}