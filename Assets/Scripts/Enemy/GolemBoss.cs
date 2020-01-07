using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GolemBoss : MonoBehaviour
{
    private GameObject player;
    private Animator anim;
    
    private bool Att=false;
    
    //Attack
    private float timeBtwAttack = -1f;
    private float startTimeBtwAttack = 2f;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        player= GameObject.FindGameObjectWithTag("Player");     
       
       anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        DirecFace();
        if(timeBtwAttack>0)
        {
            timeBtwAttack = timeBtwAttack - Time.deltaTime;
        }
    }
    void DirecFace()
    {
        
        if(Math.Abs(player.transform.position.x - transform.position.x) < 10f && (int)player.transform.position.y >= (int)transform.position.y)
        {
            
            if(player.transform.position.x<transform.position.x)
            {
                if(transform.localScale.x<0)
                {   
                    if(Math.Abs(player.transform.position.x - transform.position.x) < 2f )
                    {
                        Att=true;
                        anim.SetBool("isWalking",false);
                    }
                    else
                    {
                        Att=false;
                    }
                    if(Att==false)
                    {        
                        transform.position = new Vector3(transform.position.x - 0.01f,transform.position.y,transform.position.z);
                        anim.SetBool("isWalking",true);
                    }
                    else
                    {
                        Attack1();
                        
                    }
                }
                else
                {
                    transform.localScale = new Vector3(transform.localScale.x * -1,transform.localScale.y,transform.localScale.z);
                    
                }
                
                

            }
            else
            {
                if(transform.localScale.x>0)
                {
                    if(Math.Abs(player.transform.position.x - transform.position.x) < 2f )
                    {
                        Att=true;
                        anim.SetBool("isWalking",false);
                    }
                    else
                    {
                        Att=false;
                    }
                    if(Att==false)
                    { 
                        transform.position = new Vector3(transform.position.x + 0.01f,transform.position.y,transform.position.z);
                        anim.SetBool("isWalking",true);
                    }
                    else
                    {
                        Attack1();
                        
                    }
                }
                else
                {
                    transform.localScale = new Vector3(transform.localScale.x * -1,transform.localScale.y,transform.localScale.z);
                    
                }
                
                
            }
            
        }
        else
        {
            if((int)transform.position.x != 21)
            {
                if((int)transform.position.x > 21)
                {
                     if(transform.localScale.x<0)
                     {
                         transform.position = new Vector3(transform.position.x - 0.05f,transform.position.y,transform.position.z);
                     } 
                     else
                     {
                          transform.localScale = new Vector3(transform.localScale.x * -1,transform.localScale.y,transform.localScale.z);
                     }
                    
                }
                else
                {
                    if(transform.localScale.x>0)
                    {
                        transform.position = new Vector3(transform.position.x + 0.05f,transform.position.y,transform.position.z);
                    }
                    else
                    {
                        transform.localScale = new Vector3(transform.localScale.x * -1,transform.localScale.y,transform.localScale.z);
                    }
                }
            }
           
            
        }         
    }
    void Attack1()
    {
        //Debug.Log("Danh");
        if(timeBtwAttack < 0)
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position,attackRange,whatIsEnemies);
            if(enemiesToDamage.Length > 0)
            {
                //Debug.Log("trung");
                player.GetComponent<Player>().Damage(damage);
                timeBtwAttack = startTimeBtwAttack;
            }
            else
            {

            }
            anim.SetTrigger("Attack");
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position,attackRange);    
    }
}
