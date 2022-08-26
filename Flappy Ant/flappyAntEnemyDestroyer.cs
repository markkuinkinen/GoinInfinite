using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flappyAntEnemyDestroyer : MonoBehaviour
{
    public flappyAntPlayer player;

    void Start()
    {
        player = FindObjectOfType<flappyAntPlayer>();
    }

    void Update()
    {
        if (player.GetComponent<Transform>().position.x > (this.gameObject.GetComponent<Transform>().position.x + 15))
        {
            Invoke("destroyObject", 5f);
        }
    }

    public void destroyObject()
    {
        Destroy(this.gameObject);
    }
}
