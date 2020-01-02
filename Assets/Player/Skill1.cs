using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1 : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float lifeTime;

    public Player player;

    public float distance;

    public float damage;
    public LayerMask whatisSolid;

    public static AudioClip SkillSound,SoundHit;
    static AudioSource audioSource;
    //
    private float TstartSound = -1f;
    private float SoundEnd = 2f;


    //public GameObject destroyEffect;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        Invoke("DestroySkill1",lifeTime);
        SkillSound = Resources.Load<AudioClip>("FireSkill1");
        SoundHit = Resources.Load<AudioClip>("FireSkill1Hit");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
       if(player.DirecCast == true)
       {
       RaycastHit2D hitInfo = Physics2D.Raycast(transform.position,transform.right * -1,distance,whatisSolid);
           transform.localScale = new Vector3(-1,1,1);
          transform.Translate(transform.right * speed * Time.deltaTime *-1);
        
            if(hitInfo.collider != null)
            {
                try
                {
                hitInfo.collider.GetComponent<Enemy_move>().TakeDamage(damage);          
                
                PlaySound("Hit");
                for(int i=0;i<=30;i++)
                {
                    if(i==30)
                    {
                    DestroySkill1();
                    }
                }
                }
                catch
                {
                Debug.Log("trung tuong");
                
                PlaySound("Hit");
                
                for(int i=0;i<=30;i++)
                {
                    if(i==30)
                    {
                    DestroySkill1();
                    }
                }
                
                }

            }
            else
            {
                if(TstartSound<0)
                {
                    TstartSound=SoundEnd;
                    PlaySound("Sound");
                }
            }

        }
        else
        {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position,transform.right,distance);
        transform.Translate(transform.right * speed * Time.deltaTime);
            if(hitInfo.collider != null)
            {
                try
                {
           
                PlaySound("Hit");
                
            hitInfo.collider.GetComponent<Enemy_move>().TakeDamage(damage);
           
            for(int i=0;i<=30;i++)
                {
                    if(i==30)
                    {
                    DestroySkill1();
                    }
                }

            }
            catch
                {
                
                PlaySound("Hit");
                
                Debug.Log("trung tuong");
                
                for(int i=0;i<=30;i++)
                {
                    if(i==30)
                    {
                    DestroySkill1();
                    }
                }

            }
            }
            else
            {
                if(TstartSound<0)
                {
                    TstartSound=SoundEnd;
                    PlaySound("Sound");
                }
            }
       }
    }
    void DestroySkill1()
    {
        //Instantiate(destroyEffect,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
    public void PlaySound(string clip)
    {
        switch(clip){
            case "Sound":
                audioSource.PlayOneShot(SkillSound);
                break;
            case "Hit":
                audioSource.PlayOneShot(SoundHit);
                break;
            
        }
    }
}
