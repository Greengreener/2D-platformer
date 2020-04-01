using System.Collections;
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
        public int sprintSpeed = 7;
        public int speedUp = 2;
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
        [Header("Count Fown Times")]
        public float baseCountDown;
        public float bigCountDown;
        public float speedCountDown;

        public bool isTouchingWalls;
        void Awake()
        {
            hearts = 2;
        }
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            bigCountDown = baseCountDown;
            speedCountDown = baseCountDown;
        }

        public void Update()
        {
            if (isTouchingWalls)
            {
                if(Input.GetKeyDown(KeyCode.W))
                {
                    rb.velocity = new Vector2(0, 1) * jumpSpeed;
                    isTouchingWalls = false;
                    
                }
            }

            if (jumps <= 0)
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
                    Debug.Log("ExtraJumpLoss");
                   
                }
            }
            if (hearts == 0)
            {
                Death();
            }
            if (Input.GetButtonDown("Shift"))
            {
                speed = sprintSpeed;
            }
            if (Input.GetButtonUp("Shift"))
            {
                speed = baseSpeed;
            }
            #region Powerups update
            //Big count down
            if (big)
            {
                BigCounter();           
            }
            if (bigCountDown <= 0)
            {
                GrowSmall();
                bigCountDown = baseCountDown;
            }
            //Speed count down
            if (fast)
            {
                SpeedCounter();
            }
            if (speedCountDown <= 0)
            {
                SpeedSlow();
                speedCountDown = baseCountDown;
            }
            #endregion

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
            if(Grounded.gameObject.tag =="Wall")
            {
                isTouchingWalls = true;
            }
            if (Grounded.gameObject.tag == "Ground")
            {
                jumps = 2;
            }
            if (Grounded.gameObject.tag == "DeathGround")
            {
                Death();
            }
            if (Grounded.gameObject.tag == "ScaleUp" && big == false)
            {
                Debug.Log("Embiggen");
                GrowBig();
                Destroy(Grounded.gameObject);
            }
            if (Grounded.gameObject.tag == "SpeedUp" && fast == false)
            {
                Debug.Log("Sanic");
                SpeedFast();
                Destroy(Grounded.gameObject);
            }
            if (Grounded.gameObject.tag == "BonusJump")
            {
                bonusJump++;
                bonusJumpB = true;
                Destroy(Grounded.gameObject);
                Debug.Log("Extra jump");
            }
            if (Grounded.gameObject.tag == "Heart")
            {
                hearts++;
                Debug.Log("Babump");
                Destroy(Grounded.gameObject);
            }
            if (Grounded.gameObject.tag == "EnemyHead")
            {
                rb.velocity = new Vector2(0, 1) * jumpSpeed;

                Destroy(Grounded.transform.parent.gameObject);
             }
        }
        private void OnTriggerExit2D(Collider2D Air)
        {
            if (Air.gameObject.tag == "Ground")
            {
                jumps = 1;
            }
            if (Air.gameObject.tag == "Wall")
            {
                isTouchingWalls = false;
            }
        }
        public void Death()
        {
            hearts = 0;
            player1Sprite.SetActive(false);
            deathScreen.SetActive(true);
            Time.timeScale = 0;
        }
        #region Powerups
        public void GrowBig()
        {
            player1.transform.localScale += new Vector3(+1, +1, 0);
            big = true;
        }
        public void GrowSmall()
        {
            player1.transform.localScale += new Vector3(-1, -1, 0);
            big = false;
        }
        public void BigCounter()
        {
            bigCountDown -= Time.deltaTime;
        }
        public void SpeedFast()
        {
            speed = speed * speedUp;
            fast = true;
        }
        public void SpeedSlow()
        {
            speed = baseSpeed;
            fast = false;
        }
        public void SpeedCounter()
        {
            speedCountDown -= Time.deltaTime;
        }
        #endregion
    }
}