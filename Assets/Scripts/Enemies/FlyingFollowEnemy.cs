using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingFollowEnemy : MonoBehaviour
{
    public float speed;
    private bool isOn = true;

    public Rigidbody2D rb;
    private Transform target;
    public float distance;
    public float Range = 5;
    private bool movingRight = true;
    public bool foundPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("OnAndOff", 0, 4);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()

    {
        if (Vector3.Distance(transform.position, target.transform.position) < 5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            Debug.Log("Test");
        }
        else Patrol();
         
    }
    void OnAndOff()
    {
        if (isOn)
        {
            isOn = false;
        }
        else
        {
            isOn = true;
        }
    }
    void Patrol()
    {
        if (isOn == true)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

        }
        if (isOn == false)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);

        }
    }
}

