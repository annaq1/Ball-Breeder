using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BallMovement : MonoBehaviour
{
    public float[] angles = { 45f, -45f, -90f, -180f, 90f, 180f };
    private Rigidbody2D rb;
    private Vector2 startingPosition;
    private float randomX;
    private float randomY;
    public float speed = 3f;


    void Move()
    //Changes vector by small random number
    {
        randomX = Random.Range(-1.0f, 1.0f);
        randomY = Random.Range(-1.0f, 1.0f);
        startingPosition = new Vector2(randomX, randomY);

        if (-1.0f <= randomX && randomX <= 1.0f)
        {
            randomX += Random.Range(-0.3f, 0.3f);
        }
        if (-1.0f <= randomY && randomY <= 1.0f)
        {
            randomY += Random.Range(-0.3f, 0.3f);
        }
        startingPosition.Set(randomX, randomY);
    }

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 30 == 0)
        {
            Move();
        }
        rb.AddForce(startingPosition * speed);

    }
}