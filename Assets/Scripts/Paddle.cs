using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public GameManager GameManager;
    private Rigidbody2D paddle;
    public float speed = 10.0f;
    public float boundY = 1f;

    // Start is called before the first frame update
    void Start()
    {
        paddle = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var vel = paddle.velocity;

        if(Input.GetKey(KeyCode.W))
        {
            vel.y = speed;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            vel.y = -speed;
        }
        else
        {
            vel.y = 0;
        }

        paddle.velocity = vel;

        var pos = transform.position;
        if (pos.y > boundY)
        {
            pos.y = boundY;
        }
        else if (pos.y < -boundY)
        {
            pos.y = -boundY;
        }
        transform.position = pos;
    }
}
