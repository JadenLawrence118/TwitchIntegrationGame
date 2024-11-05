using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlatformMovement : MonoBehaviour
{
    private TwitchConnect twitch;

    private Vector2 direction;
    [SerializeField] private float moveSpeed = 5;

    private GameObject map;
    private Rigidbody2D rb;

    void Awake()
    {
        twitch = GameObject.Find("TwitchConnect").GetComponent<TwitchConnect>();
        direction = new Vector2(0, 0);
        map = GameObject.Find("Foreground");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision == map.GetComponent<Collision2D>())
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    public void OnChatMessage()
    {
        if (twitch.msg.ToLower().Contains("left"))
        {
            direction.x = -1;
            direction.y = 0;
            print(twitch.msg);
        }

        if (twitch.msg.ToLower().Contains("right"))
        {
            direction.x = 1;
            direction.y = 0;
            print(twitch.msg);
        }

        if (twitch.msg.ToLower().Contains("up"))
        {
            direction.x = 0;
            direction.y = 1;
            print(twitch.msg);
        }

        if (twitch.msg.ToLower().Contains("down"))
        {
            direction.x = 0;
            direction.y = -1;
            print(twitch.msg);
        }
    }
}
