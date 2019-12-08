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
    //public GameObject destroyEffect;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        Invoke("DestroySkill1",lifeTime);
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
           //Debug.Log(hitInfo.rigidbody.ToString());
            DestroySkill1();
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
            try
            {
            hitInfo.collider.GetComponent<Enemy_move>().TakeDamage(damage);
            DestroySkill1();
            }
            catch
            {
                Debug.Log("trung tuong");
                DestroySkill1();
            }
        }
        }
    }
    void DestroySkill1()
    {
        //Instantiate(destroyEffect,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
