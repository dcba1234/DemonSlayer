using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController2D controller;
    [SerializeField] public int test;
    public float horizontalMove = 0f;
    public float runSpeed;
    private Animator anim;
    bool Jump = false;
    public bool isAtk = false;

    public bool skill1;
    public PlayerEntity pl;
    public bool LeftNotRight = false;
    //public EdgeCollider2D edgeCol2;
    void Start()
    {
        anim = GetComponent<Animator>();
        pl = new PlayerEntity(this.transform);
        if (pl.checkSaveState())
        {
            pl = pl.getState();
            controller.Blink(new Vector3(pl.CurrentPosition.x, pl.CurrentPosition.y, transform.position.z));
        }
    }

    // Update is called once per frame
    void Update()
    {
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
        anim.SetTrigger("CastSkill1");
        skill1 = true;
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
        isAtk = true;

    }

    public void Damage(float damage)
    {
        // sau này mỗi thứ sẽ mất 1 kiểu máu khác nên gọi hàm này để nhân vật tụt máu
        Heart.heart -= 10f;
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
