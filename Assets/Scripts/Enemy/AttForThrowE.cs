using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AttForThrowE : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject gameObject;
    private Animator anim;

    private Enemy_move enemy_Move;
    //public float rangeShoot;

    //Attack
    public GameObject SuccubusThrow;

    public Transform shotPoint;

    private float timeBtw;

    public float startTimeBtw;
    void Start()
    {
       gameObject= GameObject.FindGameObjectWithTag("Player");     
       
       anim = GetComponent<Animator>();
       enemy_Move = GetComponent<Enemy_move>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
    void Attack()
    {
        if(Math.Abs(gameObject.transform.position.x - transform.position.x) < 4f)
        {
            
            if(gameObject.transform.position.x<transform.position.x)
            {
                if(transform.localScale.x<0)
                {}
                else
                {
                transform.localScale = new Vector3(transform.localScale.x * -1,transform.localScale.y,transform.localScale.z);
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
            }
            Debug.Log("Danh");
            anim.SetBool("isWalking",false);
            enemy_Move.enabled=false;
            if(timeBtw<0)
            {
            anim.SetTrigger("Throwing");
            timeBtw = startTimeBtw;
            Instantiate(SuccubusThrow,shotPoint.position,transform.rotation);
            }
            else
            {
                timeBtw = timeBtw - Time.deltaTime;
            }
        }
        else
        {
            enemy_Move.enabled=true;
            
        }
    }
}
