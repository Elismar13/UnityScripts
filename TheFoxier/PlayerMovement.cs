﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class PlayerMovement : MonoBehaviour
{
    [Range(0, 100f)] public float moveSpeed = 10f;
    [Range(0, 100f)] public float jumpForce = 10f;
    private bool leftMovement; 
    private bool isGrounded;
    private bool isJumping;
    private bool isCrouched;
    
    public Animator PlayerAnimation;
    public Transform feetPos;
    public LayerMask whatIsGround;
    public float checkRadius;

    public GameObject Header;
    private Rigidbody2D player;

    void Awake() {
        player = GetComponent<Rigidbody2D>();
        this.leftMovement = true;
        this.isJumping = false;
        this.isCrouched = false;
    }

    void Update() {
        isGrounded = Physics2D.OverlapCircle( feetPos.position, checkRadius, whatIsGround );

        if (isGrounded) {
            isJumping = false;
            PlayerAnimation.SetBool("isJumping", false);
        }

        if (!isJumping && Input.GetKey(KeyCode.Space)) {
            isJumping = true;
            PlayerAnimation.SetBool("isJumping", true);
            player.velocity = Vector2.up * jumpForce;
        }

    }

    void FixedUpdate() {
        float horizontalMovement = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float verticalMovement = Input.GetAxisRaw("Vertical");

        if ((horizontalMovement > 0 && !leftMovement) || (horizontalMovement < 0 && leftMovement))
            flipPlayer();

        if(verticalMovement < 0) {

        }

        PlayerAnimation.SetFloat("Speed", Mathf.Abs(horizontalMovement));
        player.velocity = new Vector2( horizontalMovement, player.velocity.y );

        // Debug.Log(player.position);
    }

    private void flipPlayer( ) {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

        this.leftMovement = !this.leftMovement;
    }
}
