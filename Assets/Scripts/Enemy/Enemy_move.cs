using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [Range(100,500)]public int movingRange = 100;

    public HealthBar healthBar;

    public float MonsterHealth = 1000;

    // Dazed after Hit
    private float dazedTime;
    public float startDazedTime;
    public float blood = 1;

    public bool Hit;

    
    // Location
    public float locationX(float x)
    {
        x= transform.position.x;
        
        return x;
    }
    public float locationY(float y)
    {
        y= transform.position.y;
       
        return y;
    }
    public float locationZ(float z)
    {
        z= transform.position.z;
        
        return z;
    }
    public GameObject bloodEffect;
    //public Bleed bleed;
    void Start()
    {
        anim = GetComponent<Animator>();
        blood = 1;
        Hit = false;
       
        
    }
    
    // Update is called once per frame
    void Update()
    {
       if(blood>0)
       {
        
        if(distance > runSpeed * movingRange)
        {
            
            btn_rightOnClick();
            
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
           
            btn_leftOnClick();
            distance += runSpeed;
        }
       }
       else
       {
           anim.SetTrigger("isDie");
           Destroy(gameObject);
       }
       if(dazedTime <= 0)
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
        Hit=true;
        blood = blood - damage/MonsterHealth;
        Debug.Log(damage/MonsterHealth);
        //Debug.Log("damege Taken");
    }

    
}
