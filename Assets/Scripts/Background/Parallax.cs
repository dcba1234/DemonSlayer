using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Parallax : MonoBehaviour
{
    private float leng, start;
    public GameObject cam;
    public float para;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position.x;
        leng = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float tem = (cam.transform.position.x * (1 - para));
        float dist = (cam.transform.position.x) * para;
        transform.position = new Vector3(start + dist, transform.position.y, transform.position.z);
       /* if (tem > start + leng)
            start = start + leng;
        else if (tem < start - leng)
            start = start - leng;*/
    }
}
