using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlatformMovement : MonoBehaviour
{
    private Vector2 direction;
    [SerializeField] private float moveSpeed = 5;

    private Vector2 stretch;
    [SerializeField] private float stretchSpeed = 5;
    [SerializeField] private float minSideSquash = 0.5f;
    [SerializeField] private float minDownSquash = 0.5f;

    [Header("Distance from the player to respawn")]
    [SerializeField] private Vector2 respawnPos;


    private GameObject map;

    private Vector2 lastPos;
    private Vector2 lastScale;
    private Vector2 startScale;

    private Globals global;
    private GameObject player;

    void Awake()
    {
        direction = new Vector2(0, 0);
        map = GameObject.Find("Foreground");
        global = GameObject.Find("Globals").GetComponent<Globals>();
        player = GameObject.FindGameObjectWithTag("Player");
        startScale = transform.localScale;
    }

    void FixedUpdate()
    {
        transform.parent.position = new Vector2(transform.position.x + (direction.x * moveSpeed), transform.position.y + (direction.y * moveSpeed));

        transform.localScale = new Vector2(transform.localScale.x + (stretch.x * stretchSpeed), transform.localScale.y + (stretch.y * stretchSpeed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform == map.transform)
        {
            direction.x = 0;
            direction.y = 0;
            transform.parent.position = lastPos;

            stretch.x = 0;
            stretch.y = 0;
            transform.localScale = lastScale;
        }

        if (collision.transform == player.transform)
        {
            collision.transform.parent = transform.parent;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform == player.transform)
        {
            collision.transform.parent = null;
        }
    }

    private void Update()
    {
        lastPos = transform.parent.position;

        if (transform.localScale.x < minSideSquash || transform.localScale.y < minDownSquash)
        {
            stretch.x = 0;
            stretch.y = 0;
            transform.localScale = lastScale;
        }
        else
        {
            lastScale = transform.localScale;
        }

        if (global.single)
        {
            if (Input.GetKeyUp(KeyCode.J))
            {
                direction.x = -1;
                direction.y = 0;
                stretch.x = 0;
                stretch.y = 0;
            }
            if (Input.GetKeyUp(KeyCode.L))
            {
                direction.x = 1;
                direction.y = 0;
                stretch.x = 0;
                stretch.y = 0;
            }
            if (Input.GetKeyUp(KeyCode.I))
            {
                direction.x = 0;
                direction.y = 1;
                stretch.x = 0;
                stretch.y = 0;
            }
            if (Input.GetKeyUp(KeyCode.K))
            {
                direction.x = 0;
                direction.y = -1;
                stretch.x = 0;
                stretch.y = 0;
            }
            if (Input.GetKeyUp(KeyCode.Y))
            {
                direction.x = 0;
                direction.y = 0;
                stretch.x = 1;
                stretch.y = 0;
            }
            if (Input.GetKeyUp(KeyCode.U))
            {
                direction.x = 0;
                direction.y = 0;
                stretch.x = -1;
                stretch.y = 0;
            }
            if (Input.GetKeyUp(KeyCode.O))
            {
                direction.x = 0;
                direction.y = 0;
                stretch.x = 0;
                stretch.y = 1;
            }
            if (Input.GetKeyUp(KeyCode.P))
            {
                direction.x = 0;
                direction.y = 0;
                stretch.x = 0;
                stretch.y = -1;
            }
            if (Input.GetKeyUp(KeyCode.M))
            {
                direction.x = 0;
                direction.y = 0;
                stretch.x = 0;
                stretch.y = 0;
                transform.localScale = startScale;
                transform.parent.position = new Vector2(player.transform.position.x + respawnPos.x, player.transform.position.y + respawnPos.y);
            }
        }
    }

    public void OnChatMessage(string msg)
    {
        if (!global.single)
        {
            if (msg.ToLower().Contains("!left"))
            {
                direction.x = -1;
                direction.y = 0;
                stretch.x = 0;
                stretch.y = 0;
            }

            if (msg.ToLower().Contains("!right"))
            {
                direction.x = 1;
                direction.y = 0;
                stretch.x = 0;
                stretch.y = 0;
            }

            if (msg.ToLower().Contains("!up"))
            {
                direction.x = 0;
                direction.y = 1;
                stretch.x = 0;
                stretch.y = 0;
            }

            if (msg.ToLower().Contains("!down"))
            {
                direction.x = 0;
                direction.y = -1;
                stretch.x = 0;
                stretch.y = 0;
            }
            if (msg.ToLower().Contains("!sidestretch"))
            {
                direction.x = 0;
                direction.y = 0;
                stretch.x = 1;
                stretch.y = 0;
            }
            if (msg.ToLower().Contains("!sidesquash"))
            {
                direction.x = 0;
                direction.y = 0;
                stretch.x = -1;
                stretch.y = 0;
            }
            if (msg.ToLower().Contains("!upstretch"))
            {
                direction.x = 0;
                direction.y = 0;
                stretch.x = 0;
                stretch.y = 1;
            }
            if (msg.ToLower().Contains("!downsquash"))
            {
                direction.x = 0;
                direction.y = 0;
                stretch.x = 0;
                stretch.y = -1;
            }
            if (msg.ToLower().Contains("!respawn"))
            {
                direction.x = 0;
                direction.y = 0;
                stretch.x = 0;
                stretch.y = 0;
                transform.localScale = startScale;
                transform.parent.position = new Vector2(player.transform.position.x + respawnPos.x, player.transform.position.y + respawnPos.y);
            }
        }
    }
}
