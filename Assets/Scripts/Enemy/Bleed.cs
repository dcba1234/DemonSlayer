using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleed : MonoBehaviour
{
    // Start is called before the first frame update

    //public Attack attack;

    //public bool die;

    public Enemy_move enemy_Move;
    public GameObject player;

    void Start()
    {
        
        

        //Debug.Log(obj.name);
        player = transform.parent.parent.gameObject;
        enemy_Move = player.GetComponent<Enemy_move>();
        
        //Debug.Log(player.transform.root);
       
    }

    // Update is called once per frame
    void Update()
    {
       
       if(enemy_Move.Hit == true)
       {
        
        transform.localScale = new Vector3(enemy_Move.blood,1,1);
        Debug.Log(transform.localScale);
        enemy_Move.Hit = false;
       }
     

       
    }
    
}
