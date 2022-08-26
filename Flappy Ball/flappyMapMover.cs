using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flappyMapMover : MonoBehaviour
{
    public Transform backgroundTrans;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            backgroundTrans.position = new Vector3((backgroundTrans.position.x + 10), backgroundTrans.position.y, 0);
        }
    }
}
