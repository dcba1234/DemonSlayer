using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownRoad : MonoBehaviour
{
    // Start is called before the first frame update
    private float upMax;
    public float downMax;

    private bool UpNotDown=false;
    void Start()
    {
        upMax = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(UpNotDown==false)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y - 0.005f,transform.position.z);
            if(transform.position.y <= downMax)
            {
                UpNotDown=true;
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x,transform.position.y + 0.005f,transform.position.z);
            if(transform.position.y >= upMax)
            {
                UpNotDown=false;
            }
        }
    }
}
