using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ComputerPlayer : MonoBehaviour
{
    private Rigidbody2D paddle;
    public Ball ball;
    public Wall WallToWatch;

    // Start is called before the first frame update
    void Start()
    {
        paddle = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var r = ball.GetComponent<Rigidbody2D>();
        var hits = Physics2D.RaycastAll(ball.transform.position, r.velocity.normalized, 1000);

       // Debug.DrawRay(ball.transform.position, r.velocity);

        Vector2? p = null;

        foreach (var c in hits)
        {
            if(c.collider.tag == WallToWatch.tag)
            {
                p = c.point;
               // Debug.Log(c.point);
                break;
            }
        }

        if(p != null)
        {
            var t = new Vector3(transform.position.x,
                p.Value.y, 0);

            /*
            if(t.y >= transform.position.y)
            {
                transform.position = new Vector3(transform.position.x,
                    Mathf.Clamp(transform.position.y + (Time.deltaTime * 2), transform.position.y, t.y));

                Debug.Log("Math: = " + transform.position.y + (Time.deltaTime * 2));
                Debug.Log("Lerp: = " + Vector2.Lerp(transform.position, t, Time.deltaTime * 2).y);
            }*/

            transform.position = Vector2.Lerp(transform.position, t, Time.deltaTime * 2);
        }
        else
        {
            transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, 0), Time.deltaTime * 2);
        }
    }
}
