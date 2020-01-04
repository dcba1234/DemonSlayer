using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScripts : MonoBehaviour
{
    public Animator ani;
    public Image img;
    // Start is called before the first frame update
    private void Awake()
    {
        img = gameObject.GetComponent<Image>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 || Input.GetKeyDown(KeyCode.Mouse0))
        {
            //SceneManager.LoadScene("Main");
            //Touch a = Input.GetTouch(0);
            //Debug.Log(a.deltaPosition);
        }
    }

    public void FadedIn()
    {
        img.enabled = false;
    }
}
