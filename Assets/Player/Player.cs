using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController2D controller;
    //[SerializeField] public int test;
    public float horizontalMove = 0f;
    public float runSpeed;
    private Animator anim;
    bool Jump = false;
    //public bool isAtk = false;

    //public bool skill1;

    //public bool skill1;
    public PlayerEntity pl;
    public bool LeftNotRight = false;
    public bool DirecCast =false;
    //Attack
    private float timeBtwAttack;
    private float startTimeBtwAttack = 2f;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public float damage;

    public GameObject gameObject;

    public Enemy_move enemy_Move;
    //Skill 1
    public GameObject Skill1;

    public Transform shotPoint;

    private float timeBtwSkill1;

    public float startTimeBtwSkill1;

    public float ManaLostS1;
    //Skill 2
    public GameObject Skill2;

    public Transform shotPoint2;

    private float timeBtwSkill2;

    public float startTimeBtwSkill2;

    public float ManaLostS2;
    

    //Bar
    private Mana Mana;

    private Heart Heart;

    
    
    void Start()
    {
        anim = GetComponent<Animator>();

        Mana= GameObject.FindGameObjectWithTag("Mana").GetComponent<Mana>();     

        Heart = GameObject.FindGameObjectWithTag("Heart").GetComponent<Heart>();

        //Check thu Lay
        //Damage(20f);
        //Damage(20f);
        //Damage(20f);
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBtwAttack>=0)
        {
            timeBtwAttack -= Time.deltaTime;
            //Debug.Log(timeBtwAttack);
            if(timeBtwAttack<0)
            {
                A1=true;
                A2=false;
            }
        }
        if(timeBtwSkill1>=0)
        {
            timeBtwSkill1 -= Time.deltaTime;
            
        }
      
        if(timeBtwSkill2>=0)
        {
            timeBtwSkill2 -= Time.deltaTime;
            
        }
        if(timeToFall>0)
        {
            timeToFall -= Time.deltaTime;
        }
        if(timetoUp>0)
        {
            timetoUp -= Time.deltaTime;
            if(timetoUp<0)
            {
                anim.SetBool("Lay",false);
            }
        }
        pl.setPosition(transform);
    }

    private void FixedUpdate()
    {
        
        if (controller.GetGrounded() == true)
        {

            anim.SetBool("isJumping", false);
        }
        else
        {
            saveAll();
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
        LeftNotRight = true;

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
        if(timeBtwSkill1 <=0 && Mana.mana>=ManaLostS1)
        {
        anim.SetTrigger("CastSkill1");
        DirecCast = LeftNotRight;
        
        Instantiate(Skill1,shotPoint.position,transform.rotation);
        timeBtwSkill1 = startTimeBtwSkill1;
        Mana.mana = Mana.mana - ManaLostS1;
        
        }
        

        //skill1 = true;
    }
    
    public void btn_Skill2()
    {
        if(timeBtwSkill2 <=0 && Mana.mana>=ManaLostS2)
        {
        anim.SetTrigger("Attack");
        DirecCast = LeftNotRight;
       
        Instantiate(Skill2,shotPoint2.position,transform.rotation);
        timeBtwSkill2 = startTimeBtwSkill2;
        Mana.mana = Mana.mana - ManaLostS2;
        
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
    bool A1 = true;
    bool A2 = false;
    public void Attack()
    {
        tenEnemy="";
        if(A2==false && A1==false)
        {
            anim.SetTrigger("Attack3");
            attackRange = 0.8f;
            //A1=true;
        }
        if(A2==true && timeBtwAttack>0)
        {
            anim.SetTrigger("Attack2");
            A2=false;
            timeBtwAttack= startTimeBtwAttack;
        }
        if(A1==true)
        {
            attackRange = 0.6f;
        anim.SetTrigger("Attack");
        A1=false;
        timeBtwAttack= startTimeBtwAttack;
        A2=true;
        }
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
            
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position,attackRange);    
    }
    //Fall + Lay

    float timeToFall ;
    float timetoUp ;
    float stackAtt = 0;
    public void Damage(float damage)
    {
        // sau này mỗi thứ sẽ mất 1 kiểu máu khác nên gọi hàm này để nhân vật tụt máu
        timeToFall = 2f;
        anim.SetTrigger("Hurt");
        Heart.heart = Heart.heart - damage;
        transform.position = new Vector3(transform.position.x-0.5f,transform.position.y,transform.position.z);
        stackAtt++;
        if(stackAtt==3)
        {
            stackAtt=0;
            if(timeToFall>0)
            {
                anim.SetTrigger("Fall");
                anim.SetBool("Lay",true);
                timetoUp = 3f;
            }
        }
    }

    public void saveAll()
    {
        // hàm save tất cả thông tin
     
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/player.now";
            FileStream stream = new FileStream(path, FileMode.Create);         
            formatter.Serialize(stream, pl);
            stream.Close();
    
    }
    
}
