using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlanes : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().Die();
        }
    }
}
