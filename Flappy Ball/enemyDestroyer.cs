using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDestroyer : MonoBehaviour
{
    public flappyPlayer player;

    void Start()
    {
        player = FindObjectOfType<flappyPlayer>();    
    }

    void Update()
    {
        if (player.gameStarted && player.playerTrans.position.x > (this.gameObject.GetComponent<Transform>().position.x + 15))
        {
            Invoke("destroyObject", 5f);
        }
    }

    public void destroyObject()
    {
        Destroy(this.gameObject);
    }
}
