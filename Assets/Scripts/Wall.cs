using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameManager GameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "EastWall")
        {
            GameManager.PlayerScore();
        }
        else if(tag == "WestWall")
        {
            GameManager.ComputerScore();
        }

        collision.collider.GetComponent<Ball>().Reset();
    }
}
