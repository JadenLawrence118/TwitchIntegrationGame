using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlatformMovement : MonoBehaviour
{
    private Vector2 direction;
    [SerializeField] private float moveSpeed = 5;

    private GameObject map;

    private Vector2 lastPos;

    private Globals global;

    void Awake()
    {
        direction = new Vector2(0, 0);
        map = GameObject.Find("Foreground");
        global = GameObject.Find("Globals").GetComponent<Globals>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x + (direction.x * moveSpeed), transform.position.y + (direction.y * moveSpeed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform == map.transform)
        {
            direction.x = 0;
            direction.y = 0;
            transform.position = lastPos;
        }

        if (collision.transform == GameObject.FindGameObjectWithTag("Player").transform)
        {
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform == GameObject.FindGameObjectWithTag("Player").transform)
        {
            collision.transform.parent = null;
        }
    }

    private void Update()
    {
        lastPos = transform.position;

        if (global.single)
        {
            if (Input.GetKeyUp(KeyCode.J))
            {
                direction.x = -1;
                direction.y = 0;
            }
            if (Input.GetKeyUp(KeyCode.L))
            {
                direction.x = 1;
                direction.y = 0;
            }
            if (Input.GetKeyUp(KeyCode.I))
            {
                direction.x = 0;
                direction.y = 1;
            }
            if (Input.GetKeyUp(KeyCode.K))
            {
                direction.x = 0;
                direction.y = -1;
            }
        }
    }

    public void OnChatMessage(string msg)
    {
        if (!global.single)
        {
            if (msg.ToLower().Contains("left"))
            {
                direction.x = -1;
                direction.y = 0;
            }

            if (msg.ToLower().Contains("right"))
            {
                direction.x = 1;
                direction.y = 0;
            }

            if (msg.ToLower().Contains("up"))
            {
                direction.x = 0;
                direction.y = 1;
            }

            if (msg.ToLower().Contains("down"))
            {
                direction.x = 0;
                direction.y = -1;
            }
        }
    }
}
