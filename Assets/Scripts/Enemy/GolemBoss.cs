using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GolemBoss : MonoBehaviour
{
    private GameObject player;
    private Enemy_move enemy_Move;
    private Animator anim;
    
    private bool Att=false;
    
    //Attack
    private float timeBtwAttack = -1f;
    private float startTimeBtwAttack = 3f;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public float damage;
    public GameObject Rock;
    // Start is called before the first frame update
    void Start()
    {
        player= GameObject.FindGameObjectWithTag("Player");     
        enemy_Move = GetComponent<Enemy_move>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy_Move.blood>0)
        {
        DirecFace();
        if(timeBtwAttack>0)
        {
            timeBtwAttack = timeBtwAttack - Time.deltaTime;
            //transform.rotation =  Quaternion.Euler(0, 0, 0);
        }
        }
        else
        {

            Destroy(gameObject);
        }
    }
    void DirecFace()
    {
        
        if(Math.Abs(player.transform.position.x - transform.position.x) < 10f && (int)player.transform.position.y >= (int)transform.position.y)
        {
            
            if(player.transform.position.x<transform.position.x)
            {
                if((int)player.transform.position.y - (int)transform.position.y <= 0.5f)
                {
                    transform.rotation =  Quaternion.Euler(0, 0, 0);
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
                            transform.position = new Vector3(transform.position.x - 0.05f,transform.position.y,transform.position.z);
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
                    Attack2();
                }
                

            }
            else
            {
                if((int)player.transform.position.y - (int)transform.position.y <= 0.5f)
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
                            transform.position = new Vector3(transform.position.x + 0.05f,transform.position.y,transform.position.z);
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
                    Attack2();
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
    void Attack2()
    {
        if(timeBtwAttack < 0)
        {
            anim.SetTrigger("slashinair");
            transform.rotation = Quaternion.Euler(0, 0, 20);
            timeBtwAttack = startTimeBtwAttack;
            Instantiate(Rock, new Vector3(player.transform.position.x, 14f, 0), Quaternion.identity);
        }
        else
        {
            //transform.rotation =  Quaternion.Euler(0, 0, 0);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position,attackRange);    
    }
}
