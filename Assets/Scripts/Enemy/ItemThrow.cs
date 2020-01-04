using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemThrow : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public float lifeTime;

    private GameObject Player;

    public float distance;

    public float damage;
    public LayerMask whatisSolid;

    private bool Direc=true;
    void Start()
    {
       Player= GameObject.FindGameObjectWithTag("Player");
       //Debug.Log(Player.transform.position.x);
       //Debug.Log(transform.position.x);
       if(transform.position.x > Player.transform.position.x)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1,transform.localScale.y,transform.localScale.z);
            Direc = false;
        }
        else
        {
            Direc = true;
        }
        //Debug.Log(Direc);
        Invoke("DestroyThrow",lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(Direc==false)
        {
            Debug.Log("Trai");
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position,transform.right * -1,distance,whatisSolid);
        transform.localScale = new Vector3(-0.35f,0.55f,1);
        transform.Translate(transform.right * speed * Time.deltaTime *-1);
        
            if(hitInfo.collider != null)
            {
                try
                {
                hitInfo.collider.GetComponent<Player>().Damage(damage);                     
                DestroyThrow();                    
                }
                catch
                {
                Debug.Log("trung tuong");                                                          
                //DestroyThrow();                                          
                }

            }
            else
            {

            }          
        }
        else
        {
            Debug.Log("Phai");
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position,transform.right,distance);
        transform.Translate(transform.right * speed * Time.deltaTime);
            if(hitInfo.collider != null)
            {
                try
                {           
                hitInfo.collider.GetComponent<Player>().Damage(damage);                   
                DestroyThrow();                                  
                }
                catch
                {
                Debug.Log("trung tuong");                             
                //DestroyThrow();
                }
            }
            else
            {

            }
            
        }
    }
    void DestroyThrow()
    {
        Destroy(gameObject);
    }
}
