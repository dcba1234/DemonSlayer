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

    public Attack attack;

    

    public float blood;

    public bool Hit;

    public bool MoveLeft;

    //public Bleed bleed;
    void Start()
    {
        anim = GetComponent<Animator>();
        blood = 1;
        Hit = false;
        //Debug.Log(healthBar.transform.position);
        attack = GameObject.FindGameObjectWithTag("CheckAttack").GetComponent<Attack>();;
        //healthBar = GameObject.FindGameObjectWithTag("HB").GetComponent<HealthBar>();
        //Debug.Log(this.ToString());
    
    }

    // Update is called once per frame
    void Update()
    {
       if(blood>0)
       {
        if(distance > runSpeed * movingRange)
        {
            MoveLeft = false;
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
            MoveLeft=true;
            btn_leftOnClick();
            distance += runSpeed;
        }
       }
       else
       {
           anim.SetTrigger("isDie");
           Destroy(gameObject);
       }
       
        
        
        
        //else
       // {
       //     anim.SetBool("isDie",true);

       // }
        
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
    public List<GameObject> myList;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("CheckAttack"))
        {
            Debug.Log("Hit");
            //Debug.Log(other.GetInstanceID());
            Hit=true;
            
            float x = attack.dame/MonsterHealth;
            Debug.Log(attack.dame);
            blood = blood-x;
            if(blood > 0)
            {
                
            }
            else
            {
                blood = 0;
                anim.SetTrigger("isDie");
            }
            
            //bleed.BleedH(blood);
            //myList.AddRange(GameObject.FindGameObjectsWithTag("enemy"));
            //    Debug.Log(myList[1]);
            //    foreach(GameObject item in myList){
            //        Debug.Log(item);

            //    }
        }
    }
}
