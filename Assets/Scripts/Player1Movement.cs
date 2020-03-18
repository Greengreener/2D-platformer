using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace player1
{
    public class Player1Movement : MonoBehaviour
    {
        public Rigidbody2D rb;

        public int speed = 5;
        public int jumpSpeed = 15;

        public int jumps = 2;

        public GameObject player1Sprite;


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
            transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, 0) * speed * Time.deltaTime);

            //Fast down
            if (Input.GetKey(KeyCode.S))
            {
                rb.velocity = new Vector2(0, -1) * 10;
            }
        }

        private void OnTriggerEnter2D(Collider2D Grounded)
        {
            if (Grounded.gameObject.tag == "Ground")
            {
                jumps = 2;
            }
            if (Grounded.gameObject.tag == "Death")
            {

                player1Sprite.SetActive(false);
                Time.timeScale = 0;
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