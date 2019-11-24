﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController2D controller;
    [SerializeField] public int test;
    float horizontalMove = 0f;
    public float runSpeed ;
    private Animator anim;
    bool Jump = false;
    bool isAtk = false;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (controller.GetGrounded() == true)
        {

            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }
    }
    public void jump()
    {
        Jump = true;
        anim.SetBool("isJumping", true);
        controller.Move(controller.GetVelocity(), false, Jump);
        Jump = false;
    }

    public void btn_leftOnClick()
    {
        anim.SetBool("isWalking", true);
        if (this.anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack")) return;
        horizontalMove = -runSpeed;
        if (Jump != true)
            anim.SetBool("isWalking", true);
        else anim.SetBool("isWalking", false);
        controller.Move(horizontalMove, false, Jump);
        
    }

    public void btn_rightOnClick()
    {
        
        if (this.anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack")) return;
        horizontalMove = runSpeed;
        if (Jump != true)
            anim.SetBool("isWalking", true);
        else anim.SetBool("isWalking", false);
        controller.Move(horizontalMove, false, Jump);
    }
    public void onIddle()
    {

        if (controller.GetVelocity() == 0)
        anim.SetBool("isWalking", false);
    }
    public void Attack()
    {

        anim.SetTrigger("Attack");

    }
}
