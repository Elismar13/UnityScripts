using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Movement : MonoBehaviour
{
    [Range(0, 10f)] public float moveSpeed;
    [Range(0, 10f)] public float jumpForce;
    private bool isGrounded;
    private bool isJumping;
    private bool isCrouched;

    private bool firstJump;
    private bool jumpEventFlag;
    private bool nextJump;
    
    public Transform feetPos;
    public LayerMask whatIsGround;
    public float checkRadius;
    private Rigidbody2D player;

    void Awake() {
        player = GetComponent<Rigidbody2D>();
        this.isJumping = false;
        this.isCrouched = false;
        this.firstJump = false;
        this.jumpEventFlag = false;
        this.nextJump = false;
    }

    void Update() {
        isGrounded = Physics2D.OverlapCircle( feetPos.position, checkRadius, whatIsGround );

        if (isGrounded) {
            isJumping = false;
        }

        bool keyPressed = Input.GetKey(KeyCode.Space);
        jumpEventFlag = !keyPressed;

        if(jumpEventFlag && !nextJump) {
            this.nextJump = true;
        }

        if(!isJumping && keyPressed) {
            this.isJumping = this.firstJump = true;
            this.nextJump = false;
            player.velocity = Vector2.up * jumpForce;
        } 
        else if(isJumping && firstJump && nextJump && keyPressed) {
            this.nextJump = this.firstJump = false;
            player.velocity = Vector2.up * jumpForce;
        }
    }

    void FixedUpdate() {
        float horizontalMovement = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float verticalMovement = Input.GetAxisRaw("Vertical");

        player.velocity = new Vector2( horizontalMovement, player.velocity.y );
    }


    //Methods to use in animation
    public bool getIsGrounded() {
        return this.isGrounded;
    }

    public bool getIsJumping () {
        return this.isJumping;
    }

    public bool getIsCrouched () {
        return this.isCrouched;
    }
}