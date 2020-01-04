﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator ani;
    public string nextScene;
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void toFadeOut()
    {
        ani.SetTrigger("FadeOut");
    }
    public void toScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
