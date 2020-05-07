using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    private Transform target;
    public float distance;
    public float Range = 5;
    private bool movingRight = true;
    public bool foundPlayer = false;

    public Transform groundDetection;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);

        if ((Vector3.Distance(transform.position, target.transform.position) <= Range))
        {
            foundPlayer = true;
            Debug.Log("BRUH");
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        else
        {
            foundPlayer = false;
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}