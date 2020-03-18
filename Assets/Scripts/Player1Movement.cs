﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace player1
{
    public class Player1Movement : MonoBehaviour
    {
        public Rigidbody2D rb;
        [Header("Speed Variables")]
        public int speed = 5;
        public int baseSpeed = 5;
        public int speedUp = 10;
        public int jumpSpeed = 15;
        [Header("Jumps")]
        public int jumps = 2;
        public int bonusJump = 0;
        public bool canJump;
        [Header("Lives")]
        public int lives = 1;
        public int hearts;
        [Header("Objects")]
        public GameObject player1, player1Sprite, deathScreen;
        [Header("Power Up Bools")]
        public bool big = false;
        public bool fast = false;
        public bool bonusJumpB = false;

        void Awake()
        {
            hearts = 2;
        }
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void Update()
        {
            if (jumps == 0)
            {
                canJump = false;
            }
            if (jumps > 0)
            {
                canJump = true;
            }
            if (bonusJump == 0)
            {
                bonusJumpB = false;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (canJump)
                {
                    rb.velocity = new Vector2(0, 1) * jumpSpeed;
                    jumps--;
                }
                if (bonusJumpB && !canJump)
                {
                    rb.velocity = new Vector2(0, 1) * jumpSpeed;
                    bonusJump--;
                   
                }
            }
            if (hearts == 0)
            {
                Death();
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
            if (Grounded.gameObject.tag == "DeathGround")
            {
                Death();
            }
            //Size up
            if (Grounded.gameObject.tag == "ScaleUp" && big == false)
            {
                player1.transform.localScale += new Vector3(+1, +1, 0);
                big = true;
            }
            // speed boost
            if (Grounded.gameObject.tag == "SpeedUp" && fast == false)
            {
                speed = speedUp;
                fast = true;
            }
            //Extra jump
            if (Grounded.gameObject.tag == "BonusJump")
            {
                bonusJump++;
                bonusJumpB = true;
            }
            //Slow motion
            if (Grounded.gameObject.tag == "SlowMo")
            {
                Time.timeScale = 0.5f;
            }
        }
        private void OnTriggerExit2D(Collider2D Air)
        {
            if (Air.gameObject.tag == "Ground")
            {
                jumps = 1;
            }
        }
        public void Death()
        {
            hearts = 0;
            player1Sprite.SetActive(false);
            deathScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}