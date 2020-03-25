using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class StickyBomb : MonoBehaviour
{
    public static Rigidbody2D rb2D;
    public float throwForce = 0.01f;

    public Vector3 mousePosition;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        mousePosition = Input.mousePosition;
        Vector2 mousePosition2 = mousePosition;
        rb2D.AddForce(mousePosition2 * throwForce);
        Debug.Log(mousePosition);
        //rb2D.AddForce(new Vector2(Player1.chuckDir, 1) * throwForce * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D bomb)
    {
        rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
        if (bomb.gameObject.tag == "DeathGround")
        {
            Destroy(gameObject);
        }
    }
}
