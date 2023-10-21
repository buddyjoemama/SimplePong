using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 1);

        for(float i = 0; i <= 1; i = i + .02f)
        {
            Debug.Log(i + ":" + Vector2.Lerp(new Vector2(0, 0), new Vector2(0, 10), i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoBall()
    {
        gameObject.SetActive(true);
        ball.transform.position = new Vector3(0, 0, 0);
        ball.velocity = new Vector2(0, 0);
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            ball.AddForce(new Vector2(600, 0));
        }
        else
        {
            ball.AddForce(new Vector2(-600, 0));
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        var yComp = Random.Range(0, coll.collider.attachedRigidbody.velocity.y);

        Vector2 vel;
        vel.x = ball.velocity.x;
        vel.y = (ball.velocity.y / 2) + (yComp / 3);
        ball.velocity = vel;
    }

    internal void Reset()
    {
        gameObject.SetActive(false);
        Invoke("GoBall", 2);
    }
}
