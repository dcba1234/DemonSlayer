using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;
    //public Player player1;
    public int range;
    Vector3 vector;
    void Start()
    {
        
        vector = new Vector3(1,-0.7f,0);
        
        
        player=GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    
        
    }

    // Update is called once per frame
    int i = 1;

    void Update()
    {      
        
        
        if(player.skill1==true)
        {
            if(i==1)
            {
            transform.localScale = new Vector3(1,1,1);
              
            i=i+1;
            }
            else
            {
                
                float x = transform.position[0];
                float y = transform.position[1];
                
                //transform.position = new Vector3(x+0.1f,-0.7f,0);
                if(player.LeftNotRight==true)
                {

                    transform.position = new Vector3(x-0.1f,y,0);
                    
                }
                else
                {
                    transform.position = new Vector3(x+0.1f,y,0);
                   
                }
                //transform.position = new Vector3(x+0.1f,y,0);

                if(x>3)
                {
                    i=1;
                    player.skill1=false;

                    
                        transform.position = new Vector3(1,-0.7f,0);
                        Debug.Log(transform.position);
                
                }
            }

        }

    }
}
