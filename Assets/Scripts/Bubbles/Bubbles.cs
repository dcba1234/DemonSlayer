using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubbles : MonoBehaviour
{
    public Enemy_move enemy_Move;
    public GameObject player;
    private float typingSpeed = 0.05f;
    private float x;
    private float y;
    private float z;
    
    void Start()
    {
        string name = gameObject.name;
        string nameEnemy="";
        
        for(int i=12;i<name.Length;i++)
        {
            
            nameEnemy = nameEnemy + name[i];
        }
        try
        {
        enemy_Move = GameObject.Find(nameEnemy).GetComponent<Enemy_move>();
        }
        catch
        {
            Destroy(gameObject);
        }
        
    }
    
    int i = 1;

    // Update is called once per frame
    void Update()
    {
        try
        {
        transform.position = new Vector3(enemy_Move.locationX(x)+1f,enemy_Move.locationY(y)+1f,enemy_Move.locationZ(z));
        if(enemy_Move.blood<=0)
        {
            
            Destroy(gameObject);
            
            
        }
        }
        catch
        {
            Destroy(gameObject);
        }

    }
}
