using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Enemy_move : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController2D controller;
    [SerializeField] public int test;
    float horizontalMove = 0f;
    //
    float horizontalMove1 = 0f;
    //
    public float runSpeed;
    private Animator anim;
    bool Jump = false;
    bool isAtk = false;
    private float distance = 0;
    [Range(100, 500)] public int movingRange = 100;

    public HealthBar healthBar;

    public float MonsterHealth = 1000;

    // Dazed after Hit
    private float dazedTime;
    public float startDazedTime;
    public float blood = 1;

    public bool Hit;
    private bool playerDetected = false;
    private GameObject player;
    public float rangeDetect = 0.5f;

    public LayerMask whatIsEnemies;
    public Transform attackPos;
    public float attackRange;
    // Location
    public LayerMask whatIsGround;
    public Transform groundDetect;
    public float groundDetectHeight;
    public float groundDetectWidth;
    public float locationX(float x)
    {
        x = transform.position.x;

        return x;
    }
    public float locationY(float y)
    {
        y = transform.position.y;

        return y;
    }
    public float locationZ(float z)
    {
        z = transform.position.z;

        return z;
    }
    public GameObject bloodEffect;
    //public Bleed bleed;
    void Start()
    {

        anim = GetComponent<Animator>();
        blood = 1;
        Hit = false;

        player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), GetComponent<CircleCollider2D>(), true);
        Physics2D.IgnoreCollision(player.GetComponent<CircleCollider2D>(), GetComponent<CircleCollider2D>(), true);
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("enemy");
    
        for (int i = 0; i < enemys.Length; i++)
        {
            Physics2D.IgnoreCollision(GetComponent<CircleCollider2D>(), enemys[i].GetComponent<CircleCollider2D>());
        }

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundDetect.position, groundDetectHeight);
    }

    bool canFollowPlayer()
    {
        float max = transform.position.y + 1.5f;
        float min = transform.position.y - 1.4f;
     
        return player.transform.position.y > min && player.transform.position.y < max;
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(checkFaceRight()); 
        if (blood > 0)
        {

            if (this.anim.GetCurrentAnimatorStateInfo(0).IsTag("attack")) return;
            float distanceWithPlayer = Math.Abs(player.transform.position.x - this.transform.position.x);
            if (distanceWithPlayer < rangeDetect && canFollowPlayer())
            {

                playerDetected = true;
            }
            else
            {
                playerDetected = false;
            }
            if (playerDetected)
            {
                if (distanceWithPlayer < 1.3)
                {

                    horizontalMove = 0;
                    onIddle();
                    controller.Move(horizontalMove, false, false);
                    atk();
                    return;
                }
                runToAtk((player.transform.position.x - this.transform.position.x) / distanceWithPlayer);
                return;
            }
            if (!checkGround())
            {
                onIddle();
                controller.Move(0, false, Jump);
                return;
            }
            if (distance > runSpeed * movingRange)
            {


                btn_rightOnClick();
                if (transform.localScale.x > 0)
                {

                }
                else
                {
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                }
                distance += runSpeed;
                if (distance > runSpeed * movingRange * 2)
                {
                    {
                        distance = 0;

                    }

                }
            }
            else
            {
                if (transform.localScale.x < 0)
                {

                }
                else
                {
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                }
                btn_leftOnClick();
                distance += runSpeed;
            }
        }
        else
        {
            anim.SetTrigger("isDie");
            Destroy(gameObject);
        }
        if (dazedTime <= 0)
        {
            runSpeed = 0.1f;
        }
        else
        {
            runSpeed = 0;
            dazedTime -= Time.deltaTime;
        }

    }

    private void FixedUpdate()
    {
      
    }

    void atk()
    {
        anim.SetBool("isRunning", false);
        anim.SetBool("isWalking", false);
        anim.SetTrigger("attack");
    }
    void hitPlayer()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
        if (enemiesToDamage.Length > 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Damage(20);
        }

    }

    bool checkGround()
    {
        Collider2D[] check = Physics2D.OverlapCircleAll(groundDetect.position, groundDetectHeight, whatIsGround);
        return check.Length > 0;
    }
    bool checkFaceRight()// kiểm tra cùng phía giữa player và checkWillGetGround
    {  
        return  (transform.position.x < groundDetect.transform.position.x);
    }
    bool checkToIddle() // kiểm tra để quay đầu đuổi sau khi đụng vực
    {
        if (checkFaceRight() && player.transform.position.x > transform.position.x)
        {
            return true;
        }
        else if (!checkFaceRight() && player.transform.position.x < transform.position.x)
        {
            return true;
        }
        else return false;
    }
    public void runToAtk(float direction) // 1 và  -1
    {
        if (!checkGround())
        {
            if (checkToIddle())
            {
                onIddle();
                controller.Move(0, false, Jump);
                return;
            }
          
        }
        if (this.anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack")) return;
        anim.SetBool("isRunning", true);
        controller.Move(runSpeed * 3.5f * direction, false, false);
    }

    public void btn_leftOnClick()
    {
        anim.SetBool("isWalking", true);
        if (this.anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack")) return;
        horizontalMove = -runSpeed;
        if (Jump != true)
            anim.SetBool("isWalking", true);
        else anim.SetBool("isWalking", false);
        controller.Move(horizontalMove, false, Jump);

    }

    public void btn_rightOnClick()
    {

        if (this.anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack")) return;
        horizontalMove = runSpeed;
        if (Jump != true)
            anim.SetBool("isWalking", true);
        else anim.SetBool("isWalking", false);
        controller.Move(horizontalMove, false, Jump);
    }
    public void onIddle()
    {

        if (controller.GetVelocity() == 0)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
            horizontalMove = 0;
        }


    }
    public void Attack()
    {

        anim.SetTrigger("Attack");

    }

    public void Damage(float damage)
    {
        // sau này mỗi thứ sẽ mất 1 kiểu máu khác nên gọi hàm này để nhân vật tụt máu
        Heart.heart -= 10f;
    }


    public void TakeDamage(float damage)
    {
        //Instantiate(bloodEffect,transform.position,Quaternion.identity);
        dazedTime = startDazedTime;
        Hit = true;
        blood = blood - damage / MonsterHealth;
        //Debug.Log("damege Taken");
    }


}
