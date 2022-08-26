using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody2D rb;

    private float posTrackX;
    private float posTrackY;
    private float moveDistance = 2;

    public bool isAlive;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            move();
        } 
    }

    void move()
    {
        //the player position changes depending on the X,Y values that change via key presses
        rb.transform.position = new Vector3(posTrackX, posTrackY, 0f);

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && posTrackY < 4)
        {
            posTrackY += moveDistance;
        }
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && posTrackX > -2)
        {
            posTrackX -= moveDistance;
        }
        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && posTrackY > -2)
        {
            posTrackY -= moveDistance;
        }
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && posTrackX < 4)
        {
            posTrackX += moveDistance;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            isAlive = false;
        }
        if (other.gameObject.tag == "points")
        {
            Object.Destroy(other.gameObject);
            ballUI.score += 200;
        }
    }
}
