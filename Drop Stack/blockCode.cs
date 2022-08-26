using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockCode : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool isTouching;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isTouching = false;
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "rightWall")
        {
            rb.velocity = new Vector2(rb.velocity.x * -1, 0f);
        }
        if (other.tag == "leftWall")
        {
            rb.velocity = new Vector2(rb.velocity.x * -1, 0f);
        }
        if (other.tag == "Stack")
        {
            isTouching = true;
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Stack")
        {
            isTouching = true;
        } 
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Stack")
        {
            isTouching = false;
        }
    }
}
