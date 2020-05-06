using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1 : MonoBehaviour
{
    public Rigidbody2D rb;
    [Header("Speed Variables")]
    public int speed = 5;
    public static int baseSpeed = 5;
    public int sprintSpeed = 7;
    public int speedUp = 2;
    public int jumpSpeed = 15;
    [Header("Jumps")]
    public static int baseJumps = 2;
    public int jumps = 2;
    public int bonusJump = 0;
    public bool canJump;
    [Header("Lives")]
    public int lives = 1;
    public int hearts;
    public Vector3 respawnPos;
    [Header("Objects")]
    public GameObject player1, player1Sprite, deathScreen, pause;
    [Header("Power Up Bools")]
    public bool big = false;
    public bool fast = false;
    public bool bonusJumpB = false;
    [Header("Carrot")]
    public bool canSee;

    [Header("Count Fown Times")]
    public static float baseCountDown = 15;
    public float bigCountDown;
    public float speedCountDown;
    public float carrotTimer;
    /*[Header("Sticky Bomb")]
    public GameObject bombPrefab;
    public GameObject chuckPoint;
    public Vector3 chuckPointTrans;
    public Transform chuckLeft;
    public Transform chuckRight;
    public Vector2 chuckPositive;
    public Vector3 mousePosition;
    public static int chuckDir = 1;
    public Transform chuckRotation;*/
    [Header("UI")]
    public Text textHearts;
    public GameObject darkVision;
    public bool isPaused;

    #region Delete later
    public float cocaineTimer = 60;
    public bool cocaine;
    #endregion

    void Awake()
    {
        hearts = 100;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bigCountDown = baseCountDown;
        speedCountDown = baseCountDown;
        carrotTimer = baseCountDown + 15;
        respawnPos = transform.position;
        Debug.Log("Respawn position " + respawnPos);
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
        if (Input.GetKeyDown(KeyBinds.keys["Jump"]))
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
        if (!canJump && Input.GetKey(KeyBinds.keys["Jump"]) && rb.velocity.y <= -1)
        {
            rb.gravityScale = 1;
        }
        else
        {
            rb.gravityScale = 4;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
            {
                if(player1Sprite == isActiveAndEnabled)
                {
                    setTimeScale(0);
                    pause.SetActive(true);
                }
            }
        #region Old code
        /*if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            mousePosition = Input.mousePosition;
            mousePosition.z = 10;

            chuckPositive = new Vector2(chuckDir, 0);
            chuckRotation.rotation = Quaternion.FromToRotation(chuckPoint.transform.position, mousePosition);
            Instantiate(bombPrefab, chuckPoint.transform.position, chuckRotation.rotation);
            *//*Vector2 mousePosition2 = mousePosition;
            StickyBomb.rb2D.AddForce(mousePosition2);*//*
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            chuckPoint.transform.position = chuckLeft.position;
            chuckDir = -1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            chuckPoint.transform.position = chuckRight.position;
            chuckDir = 1;
        }*/
        #endregion
        if (Input.GetKey(KeyBinds.keys["Sprint"]))
        {
            speed = sprintSpeed;
        }
        if (Input.GetKeyUp(KeyBinds.keys["Sprint"]))
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
        if (canSee)
        {
            CarrotCounter();
        }
        if (carrotTimer <= 0)
        {
            canSee = false;
            darkVision.SetActive(true);
            carrotTimer = baseCountDown + 15;
        }
        #endregion
        if (hearts == 0)
        {
            Death();
        }
        //textHearts.text = ("Hearts: ") + hearts.ToString();
        #region Delete later 2
        if (cocaine)
        {
            CocaineTimerDown();
        }
        if (cocaineTimer <= 0)
        {
            Death();
        }
        #endregion
    }
    public void FixedUpdate()
    {
        //Horizontal movement
        if (Input.GetKey(KeyBinds.keys["Left"]))
        {
            transform.Translate((-speed * Time.deltaTime), 0, 0);
        }
        if (Input.GetKey(KeyBinds.keys["Right"]))
        {
            transform.Translate((speed * Time.deltaTime), 0, 0);
        }

        //Fast down
        if (Input.GetKey(KeyBinds.keys["Fall"]))
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
            this.transform.position = respawnPos;
            rb.velocity = new Vector3(0, 0, 0);
            jumps = baseJumps;
            hearts--;
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
        if (Grounded.gameObject.tag == "Carrot")
        {
            NightVision();
            Destroy(Grounded.gameObject);
        }
        #region Delete later 3
        if (Grounded.gameObject.tag == "EditorOnly")
        {
            Cocaine();
            Destroy(Grounded.gameObject);
        }
        #endregion
    }
    private void OnTriggerExit2D(Collider2D Air)
    {
        if (Air.gameObject.tag == "Ground")
        {
            jumps = 1;
            //respawnPos = this.transform.position - new Vector3(rb.velocity.x * 3, 0, 0);
            //Debug.Log(respawnPos);
        }
    }
    public void Death()
    {
        //hearts = 0;
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
    public void NightVision()
    {
        darkVision.SetActive(false);
        canSee = true;
    }
    public void DarkVision()
    {
        darkVision.SetActive(true);
        carrotTimer = baseCountDown + 15;
    }
    public void CarrotCounter()
    {
        carrotTimer -= Time.deltaTime;
    }
    #endregion

    #region Delete later 4
    public void Cocaine()
    {
        Time.timeScale = 10;
        cocaine = true;
    }
    public void CocaineTimerDown()
    {
        cocaineTimer -= Time.deltaTime;
    }
    #endregion
    public void setTimeScale(int type)
    {
        switch (type)
        {
            case 0:
                Time.timeScale = 0;
                break;
            case 1:
                Time.timeScale = 1;
                break;
            case 2:
                Time.timeScale = 4;
                break;
        }
    }
    }
