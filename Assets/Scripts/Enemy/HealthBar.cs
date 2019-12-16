using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Enemy_move enemy_Move;
    public GameObject player;

    private float x;
    private float y;
    private float z;
    
    void Start()
    {
        string name = gameObject.name;
        string nameEnemy="";
        
        for(int i=9;i<name.Length;i++)
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
    void FixedUpdate()
    {
        try
        {
        transform.position = new Vector3(enemy_Move.locationX(x),enemy_Move.locationY(y),enemy_Move.locationZ(z));
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
