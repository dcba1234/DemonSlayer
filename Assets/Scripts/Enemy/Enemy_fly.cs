using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Enemy_fly : MonoBehaviour
{
    // Start is called before the first frame update
    private Enemy_move enemy_Move;
    private GameObject player;
    private float distance = 0;
    private Animator animator;
    private bool Attack=false;
    private bool Follow = false;
    void Start()
    {
        enemy_Move = GetComponent<Enemy_move>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {      
       if(Attack==false)
       {
         Move();
         
       }
       
         DoAttack();         
       
       
    }
    void Move()
    {
         if(distance > enemy_Move.runSpeed * enemy_Move.movingRange)
        {
            
            //btn_rightOnClick();
            transform.position = new Vector3(transform.position.x + 0.02f,transform.position.y,transform.position.z);
            distance += enemy_Move.runSpeed;
            if (distance > enemy_Move.runSpeed * enemy_Move.movingRange * 2)
            {
                {
                    distance = 0;
                    
                }
                
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x - 0.02f,transform.position.y,transform.position.z);
            //btn_leftOnClick();
            distance += enemy_Move.runSpeed;
        }
       
    }
    float x,y;
    void DoAttack()
    {
        if(Math.Abs(player.transform.position.x - transform.position.x) < 4f)
        {
            Attack=true;
            if(Attack==true && Follow == false)
            {
                Follow=true;
                x=transform.position.x;
                y=transform.position.y;
                
            }
            if(player.transform.position.x<transform.position.x)
            {
                if(transform.localScale.x<0)
                {}
                else
                {
                transform.localScale = new Vector3(transform.localScale.x * -1,transform.localScale.y,transform.localScale.z);
                }
                if(Math.Abs(player.transform.position.x - transform.position.x) > 1f)
                {
                    transform.position = new Vector3(transform.position.x - 0.01f,transform.position.y,transform.position.z);
                }
                if(Math.Abs(player.transform.position.y - transform.position.y) > 0.2f)
                {
                    transform.position = new Vector3(transform.position.x,transform.position.y - 0.025f,transform.position.z);
                }
            }
            else
            {
                if(transform.localScale.x>0)
                {}
                else
                {
                transform.localScale = new Vector3(transform.localScale.x * -1,transform.localScale.y,transform.localScale.z);
                }
                if(Math.Abs(player.transform.position.x - transform.position.x) > 1f)
                {
                    transform.position = new Vector3(transform.position.x + 0.01f,transform.position.y,transform.position.z);
                }
                if(Math.Abs(player.transform.position.y - transform.position.y) > 0.2f)
                {
                    transform.position = new Vector3(transform.position.x,transform.position.y - 0.025f,transform.position.z);
                }
            }
            if(Math.Abs(transform.position.x - x) > 7f)
            {
                if(transform.position.x <= x || transform.position.x >= x)
                {
                    if(transform.position.x <= x)
                    {
                    transform.position = new Vector3(transform.position.x + 0.05f,transform.position.y,transform.position.z);
                    }
                    if(transform.position.x >= x)
                    {
                    transform.position = new Vector3(transform.position.x + 0.05f,transform.position.y,transform.position.z);
                    }
                }
                if(transform.position.y <= y)
                {
                    //Debug.Log("Len");
                    transform.position = new Vector3(transform.position.x ,transform.position.y + 0.01f,transform.position.z);
                }
            }

            //anim.SetBool("isWalking",false);
            enemy_Move.enabled=false;
            //if(timeBtw<0)
            //{
            //anim.SetTrigger("Throwing");
            //timeBtw = startTimeBtw;
            //Instantiate(SuccubusThrow,shotPoint.position,transform.rotation);
            //}
            //else
            //{
                //timeBtw = timeBtw - Time.deltaTime;
            //}
        }
        else
        {
            enemy_Move.enabled=true;
            Attack = false;
            //Follow=false;
        }
    }
}
