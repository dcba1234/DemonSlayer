using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
   
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FlipHB()
    {
        transform.localScale = new Vector3(transform.localScale[0] * -1 ,1,1);
       
        
    }
}
