using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashingButton : MonoBehaviour
{
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= 1)
        {
            GetComponent<Image>().enabled = true;
        }
        if (time >= 2)
        {
            GetComponent<Image>().enabled = false;
            time = 0;
        }
    }
}
