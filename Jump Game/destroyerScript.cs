using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyerScript : MonoBehaviour
{
    public playerScript player;
    public float xPosition;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<playerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        xPosition = this.gameObject.GetComponent<Transform>().position.x;
        if (player.playerTrans.position.x > (xPosition + 40))
        {
            destroyObject();
        }
    }

    public void destroyObject()
    {
        if (!player.gameOver)
        {
            Destroy(this.gameObject);
        }
    }
}
