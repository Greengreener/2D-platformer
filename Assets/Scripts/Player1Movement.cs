using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace player1
{
    public class Player1Movement : MonoBehaviour
    {
        public Rigidbody2D rb;

        public int speed = 500;
        public int jumpSpeed = 10000;

        public int jumps = 2;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void Update()
        {
            if (jumps > 0)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    rb.velocity = new Vector2(0, 1) * jumpSpeed;
                    jumps--;
                }
            }

        }

        public void FixedUpdate()
        {
            //Horizontal movement
            transform.Translate(new Vector3(Input.GetAxis("Horizontal"),0,0) * speed * Time.deltaTime);
            //Old movement
            /*float moveHorizontal = Input.GetAxis("Horizontal");
            Vector3 movement = new Vector3(moveHorizontal, 0, 0);
            transform.Translate(movement * speed * Time.deltaTime);*/

            if (Input.GetKey(KeyCode.S))
            {
                rb.velocity = new Vector2(0, -1) * 10;
            }

            /*    if (jumps > 0)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    rb.velocity = new Vector2(0, 1) * jumpSpeed;
                    jumps--;
                }
            }*/
        }

        private void OnTriggerEnter2D(Collider2D Grounded)
        {
            if (Grounded.gameObject.tag == "Ground")
            {
                jumps = 2;
            }
        }
        private void OnTriggerExit2D(Collider2D Air)
        {
            if (Air.gameObject.tag == "Ground")
            {
                jumps = 1;
            }
        }

    }
}