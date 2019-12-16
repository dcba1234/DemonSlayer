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

    //TimeHitByBot
    
    
    void Start()
    {
        anim = GetComponent<Animator>();

        Mana= GameObject.FindGameObjectWithTag("Mana").GetComponent<Mana>();     

        Heart = GameObject.FindGameObjectWithTag("Heart").GetComponent<Heart>();

        Damage(50f);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(timeBtwSkill1>=0)
        {
            timeBtwSkill1 -= Time.deltaTime;
            if(timeBtwSkill1<=0)
            {
                //Debug.Log("Skill 1");
            }
        }
      
        if(timeBtwSkill2>=0)
        {
            timeBtwSkill2 -= Time.deltaTime;
            if(timeBtwSkill2<=0)
            {
               
                //Debug.Log("Skill 2");
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
        anim.SetTrigger("Hurt");
        Heart.heart = Heart.heart - damage;
        transform.position = new Vector3(transform.position.x-0.5f,transform.position.y,transform.position.z);
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
