using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private int direction = 0;
    public CharacterController2D controller;
    public float runSpeed = 0.5f;
    public bool isStory1 = true;
    private Animator anim;
    public GameObject fade;
    public GameObject fadeOut;
    private bool playerMoving = false;
    // chỉ story1
    private float currentPosOfPlayer;
    void Start()
    {
        // SoundManager.PlaySound("Walk");
        Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>(), true);
        Physics2D.IgnoreCollision(player.GetComponent<CircleCollider2D>(), GetComponent<BoxCollider2D>());
        anim = GetComponent<Animator>();
        //controller = GetComponent<CharacterController2D>();
        if (isStory1)
        {
            currentPosOfPlayer = player.transform.position.x;
        }
    }
    private void FixedUpdate()
    {
        if (playerMoving)
        {
            player.GetComponent<Player>().btn_leftOnClick();
        }
        controller.Move(direction * runSpeed, false, false);

        if (isStory1)
        {                  
            if (player.transform.position.x < -5.7)
            {
                runLeft();
                if (this.transform.position.x < -5.7)
                {
                    // next scene
                    fadeOut.SetActive(true);
                    //Debug.Log("Nextttttt");

                    //fade.GetComponent<FadeOut>().deActiveAfterFadeIn = false;
                    //fade.transform.gameObject.SetActive(true);
                    //fade.GetComponent<FadeOut>().toFadeOut();
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void runLeft()
    {
        
        anim.SetBool("isRunning", true);
        direction = -1;
    }
    public void runRight()
    {
        anim.SetBool("isRuning", true);
        direction = 1;
    }
    public void stopRun()
    {
        anim.SetBool("isRuning", false);
        direction = 0;
    }
    public void activeRunInStory1()
    {
        playerMoving = true;
    }
}
