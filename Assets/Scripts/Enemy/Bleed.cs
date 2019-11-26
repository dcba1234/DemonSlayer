using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleed : MonoBehaviour
{
    // Start is called before the first frame update

    public Attack attack;

    public bool die;

    public float dame = 100;

    public float MonsterHealth = 1000;
    void Start()
    {
        attack = GameObject.FindGameObjectWithTag("CheckAttack").GetComponent<Attack>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(attack.Hit==true)
        {
            float health = dame/MonsterHealth;
            Debug.Log(health);
            float x = transform.localScale[0];
            if(x>0)
            {
            transform.localScale = new Vector3(x-health,1,1);
            attack.Hit=false;
            }
            if(x==0)
            {
                die= true;
            }
            
        }
    }
}
