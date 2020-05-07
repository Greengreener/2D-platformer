using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingUpDown : MonoBehaviour
{
    public float speed;
    private bool isOn = true;
    public float Distance;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("OnAndOff", 0, Distance);

    }

    // Update is called once per frame
    void Update()
    {
        if (isOn == true)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);

        }
        if (isOn == false)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);

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