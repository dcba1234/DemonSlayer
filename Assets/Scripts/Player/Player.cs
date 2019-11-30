using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController2D controller;
    //[SerializeField] public int test;
    public float horizontalMove = 0f;
    public float runSpeed ;
    private Animator anim;
    bool Jump = false;
    //public bool isAtk = false;

    //public bool skill1;

    public bool LeftNotRight = false;
    public bool DirecCast =false;
    //Attack
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public float damage;

    public GameObject gameObject;

    public Enemy_move enemy_Move;
    //Skill 1
    public GameObject Skill1;

    public Transform shotPoint;
    //Skill 2
    public GameObject Skill2;

    public Transform shotPoint2;


    private float timeBtwSkill1;

    public float startTimeBtwSkill1;
    void Start()
    {
        anim = GetComponent<Animator>();
                 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
        if (controller.GetGrounded() == true)
        {

            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }
    }
    public void jump()
    {
        if (this.anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack")) return;
        Jump = true;
        anim.SetBool("isJumping", true);
        controller.Move(horizontalMove, false, Jump);
        Jump = false;
        
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
        LeftNotRight=true;
        
    }

    public void btn_rightOnClick()
    {
        
        if (this.anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack")) return;
        horizontalMove = runSpeed;
        if (Jump != true)
            anim.SetBool("isWalking", true);
        else anim.SetBool("isWalking", false);
        controller.Move(horizontalMove, false, Jump);
        LeftNotRight = false;
    }

    public void btn_Skill1()
    {
        if(timeBtwSkill1 <=0)
        {
        anim.SetTrigger("CastSkill1");
        DirecCast = LeftNotRight;
        //skill1=true;
        Instantiate(Skill1,shotPoint.position,transform.rotation);
        timeBtwSkill1 = startTimeBtwSkill1;
        }
        else
        {
            timeBtwSkill1 -= Time.deltaTime;
        }

    }
    
    public void btn_Skill2()
    {
        if(timeBtwSkill1 <=0)
        {
        anim.SetTrigger("Attack");
        DirecCast = LeftNotRight;
        //skill1=true;
        Instantiate(Skill2,shotPoint2.position,transform.rotation);
        timeBtwSkill1 = startTimeBtwSkill1;
        }
        else
        {
            timeBtwSkill1 -= Time.deltaTime;
        }

    }
    public void onIddle()
    {

        if (controller.GetVelocity() == 0)
        {
            anim.SetBool("isWalking", false);
            horizontalMove = 0;
        }
        
        
    }
    string tenOb;
    string tenEnemy;
    public void Attack()
    {
        tenEnemy="";
        anim.SetTrigger("Attack");
        //isAtk=true;
        
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position,attackRange,whatIsEnemies);
        
        for(int i= 0; i< enemiesToDamage.Length;i++)
        {
            //Debug.Log(i);
            tenOb = enemiesToDamage[0].ToString();
            for(int y = 0;y<tenOb.Length-31;y++)
            {
                tenEnemy = tenEnemy + tenOb[y];
            }

            gameObject = GameObject.Find(tenEnemy);
            enemy_Move = gameObject.GetComponent<Enemy_move>();
            enemy_Move.TakeDamage(damage);
            
        }
        timeBtwAttack= startTimeBtwAttack;
        
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position,attackRange);    
    }

    public void Damage(float damage)
    {
        // sau này mỗi thứ sẽ mất 1 kiểu máu khác nên gọi hàm này để nhân vật tụt máu
        Heart.heart -= 10f;
    }
}
