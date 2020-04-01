using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    public float speedOfBullet;
    public float lifeTime = 20;

    void Update()
    {
        transform.position += transform.right * speedOfBullet * Time.deltaTime;
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
            lifeTime = 20;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(collision.transform.gameObject);

        }
        if(collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);

        }
    }
}
