using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update

    public EdgeCollider2D edgeCol;

    public Player player;

    public bool Hit; 
    void Start()
    {
        edgeCol = GetComponent<EdgeCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
    }
    int timeAtt = 1;
    // Update is called once per frame
    void Update()
    {
        if(player.isAtk==true)
        {
            timeAtt= timeAtt+1;
            if(player.horizontalMove>=0)
            {
             
            Vector2[] colliderpoints;
            colliderpoints = edgeCol.points;
            
            colliderpoints[0] = new Vector2(0.77f, 0.147f);
            colliderpoints [1] = new Vector2 (1.1027f, -0.313366f);
            colliderpoints [2] = new Vector2 (1.41438f, -0.759133f);
            edgeCol.points =  colliderpoints;
            
            
            }
            else
            {
            
            Vector2[] colliderpoints;
            colliderpoints = edgeCol.points;
            colliderpoints[0] = new Vector2(-0.73f, 0.1444f);
            colliderpoints [1] = new Vector2 (-1.145873f, -0.38527f);
            colliderpoints [2] = new Vector2 (-1.4212f, -0.722396f);
            edgeCol.points =  colliderpoints;
            
            }
            
            if(timeAtt==20)
            {
                player.isAtk=false;
                timeAtt=1;
            }
        }
        else
        {
            Vector2[] colliderpoints;
            colliderpoints = edgeCol.points;
            colliderpoints[0] = new Vector2(0, 0);
            colliderpoints [1] = new Vector2 (0, 0);
            colliderpoints [2] = new Vector2 (0, 0);
            edgeCol.points =  colliderpoints;
            
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("enemy"))
        {
            Hit=true;
        }
    }
}
