using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeft : MonoBehaviour
{
    private Rigidbody2D rb;
    private playerController player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = Object.FindObjectOfType<playerController>();
    }

    void Update()
    {
        if (!player.isAlive)
        {
            Object.Destroy(this.gameObject);
        }
        rb.velocity = new Vector2(-spawner.moveSpeed, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "despawner")
        {
            Object.Destroy(this.gameObject);
        }
    }
}
