using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public Rigidbody2D rb;
    public float dashSpeed;
    public float dashTime;
    public float dashStartTime;
    private int direction;
    public Vector2 dashDirection;
    void Start()
    {
        dashTime = dashStartTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                direction = 1;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                direction = 2;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                direction = 3;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                direction = 4;
            }
        }
        if (dashTime < 0)
        {
            direction = 0;
            dashTime = dashStartTime;
            rb.velocity = Vector2.zero;
        }
        else
        {
            dashTime -= Time.deltaTime;
        }
        if (direction == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                dashDirection = rb.velocity = Vector2.left * dashSpeed;
            }
        }
        if (direction == 2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                dashDirection = rb.velocity = Vector2.right * dashSpeed;
            }
        }
        if (direction == 3)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                dashDirection = rb.velocity = Vector2.up * dashSpeed;
            }
        }
        if (direction == 4)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                dashDirection = rb.velocity = Vector2.down * dashSpeed;
            }
        }
    }
}
