using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private Vector2 jumpHeight;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");


        // left/right
        Vector3 direction = new Vector2(horizontalInput, 0);

        transform.Translate(direction * speed * Time.deltaTime);

        if (horizontalInput < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            transform.GetChild(0).transform.rotation = new Quaternion(0, 0, 180, 0);
        }
        else if (horizontalInput > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            transform.GetChild(0).transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }
    private void FixedUpdate()
    {
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