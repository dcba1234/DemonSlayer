using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Enemy_move enemy_Move;
    public GameObject player;
    void Start()
    {
        player = transform.parent.gameObject;
        enemy_Move = player.GetComponent<Enemy_move>();
       
    }
    public bool Direc;
    
    int i = 1;
    // Update is called once per frame
    void FixedUpdate()
    {

        if(i == 1)
        {
           Direc = enemy_Move.MoveLeft;
           i = i +1;
           
        }
        if(Direc != enemy_Move.MoveLeft)
        {
            
            transform.localScale = new Vector3(transform.localScale[0] * -1 ,1,1);
            Direc = enemy_Move.MoveLeft;        
        }
        //Debug.Log(Direc);
        //Debug.Log(enemy_Move.MoveLeft);
    }
    public void FlipHB()
    {
        transform.localScale = new Vector3(transform.localScale[0] * -1 ,1,1);
    }
}
