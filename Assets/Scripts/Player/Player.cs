using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController2D controller;
    [SerializeField] public int test;
    public float horizontalMove = 0f;
    public float runSpeed ;
    private Animator anim;
    bool Jump = false;
    public bool isAtk = false;

    public bool skill1;

    public bool LeftNotRight = false;
    //Attack
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public float damage;

    public GameObject gameObject;

    public Enemy_move enemy_Move;
    void Start()
    {
        anim = GetComponent<Animator>();
                 
    }

    // Update is called once per frame
    void Update()
    {
        //sxsxx x
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
        anim.SetTrigger("CastSkill1");
        skill1=true;
    }
    public void onIddle()
    {

        if (controller.GetVelocity() == 0)
        {
            anim.SetBool("isWalking", false);
            horizontalMove = 0;
        }
        
        
    }
    string jdo;
    string tenOb;
    public void Attack()
    {
        tenOb="";
        anim.SetTrigger("Attack");
        isAtk=true;
        //if(timeBtwAttack <=0 )
        //{
        //Debug.Log("1");
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position,attackRange,whatIsEnemies);
        
        for(int i= 0; i< enemiesToDamage.Length;i++)
        {
            //Debug.Log(i);
            jdo = enemiesToDamage[0].ToString();
            for(int y = 0;y<jdo.Length-31;y++)
            {
                tenOb = tenOb + jdo[y];
            }
            Debug.Log(tenOb);
            //Debug.Log(jdo.Length);

            gameObject = GameObject.Find(tenOb);
            enemy_Move = gameObject.GetComponent<Enemy_move>();
            enemy_Move.TakeDamage(damage);
            //enemiesToDamage[i].GetComponent<Enemy_moves>().TakeDamage(damage);
            //gameOject = GameObject.FindGameObjectWithTag("CheckAttack").GetComponent<Attack>();;
        }
        timeBtwAttack= startTimeBtwAttack;
        //}
       // else
        //{
       //     timeBtwAttack -= Time.deltaTime;
       // }
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
