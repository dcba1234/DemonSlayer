using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFall : MonoBehaviour
{
    public float speed;
    //public float lifeTime;

    private GameObject Player;

    public float distance;

    public float damage;
    public LayerMask whatisSolid;
    public LayerMask whatisSolid2;
    // Start is called before the first frame update
    void Start()
    {
        Player= GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position,transform.right * -1,distance,whatisSolid);
        RaycastHit2D hitInfo2 = Physics2D.Raycast(transform.position,transform.right * -1,distance,whatisSolid2);
        transform.position = new Vector3(transform.position.x,transform.position.y-0.02f,transform.position.z);
            if(hitInfo.collider != null || hitInfo2.collider != null)
            {
                try
                {
                hitInfo.collider.GetComponent<Player>().Damage(damage);                     
                DestroyThrow();                    
                }
                catch
                {
                Debug.Log("trung tuong");
                DestroyThrow();                                                          
                //DestroyThrow();                                          
                }

            }
            else
            {

            }          
    }
    void DestroyThrow()
    {
        Destroy(gameObject);
    }
}
