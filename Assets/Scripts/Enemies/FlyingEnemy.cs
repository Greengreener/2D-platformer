using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public float speed;
    private bool isOn = true;

    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("OnAndOff", 0, 4);

    }

    // Update is called once per frame
    void Update()
    {
        if (isOn == true)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

        }
        if(isOn == false)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);

        }
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
}

