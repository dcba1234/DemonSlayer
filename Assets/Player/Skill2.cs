using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2 : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public float lifeTime;

    public Player player;

    public float distance;

    public float damage;
    public LayerMask whatisSolid;

    public static AudioClip SkillSound;
    static AudioSource audioSource;
    //
    private float TstartSound = -1f;
    private float SoundEnd = 2f;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        Invoke("DestroySkill1",lifeTime);
        SkillSound = Resources.Load<AudioClip>("WindSkill2");
        audioSource = GetComponent<AudioSource>();
        //TstartSound = SoundEnd;
    }

    // Update is called once per frame
    void Update()
    {
        if(TstartSound<0)
        {
            TstartSound = SoundEnd;
            PlaySound();
        }
        TstartSound = TstartSound - Time.deltaTime;
        if(player.DirecCast == true)
        {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position,transform.right * -1,distance,whatisSolid);
           transform.localScale = new Vector3(-2.179416f,1.83f,1.0232f);
           transform.Translate(transform.right * speed * Time.deltaTime *-1);
        if(hitInfo.collider != null)
        {
            try
            {
            Debug.Log("OK");
            hitInfo.collider.GetComponent<Enemy_move>().TakeDamage(damage);
            }
            catch
            {
                 Debug.Log("trung tuong");
                 DestroySkill1();
            }
        }
        }
        else
        {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position,transform.right,distance);
        transform.Translate(transform.right * speed * Time.deltaTime);
        if(hitInfo.collider != null)
        {
            try{
            Debug.Log("OK");
            hitInfo.collider.GetComponent<Enemy_move>().TakeDamage(damage);
            }
            catch
            {
                Debug.Log("trung tuong");
                DestroySkill1();
            }
            //DestroySkill1();
        }
        }
    }
    void DestroySkill1()
    {
        //Instantiate(destroyEffect,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
    public void PlaySound()
    {
        audioSource.PlayOneShot(SkillSound);
    }
}
