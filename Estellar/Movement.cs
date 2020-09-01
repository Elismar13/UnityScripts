using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Movement : MonoBehaviour
{
    [Range(0, 100f)] public float moveSpeed = 10f;
    [Range(0, 100f)] public float jumpForce = 10f;
    private bool isGrounded;
    private bool isJumping;
    private bool isCrouched;
    
    public Transform feetPos;
    public LayerMask whatIsGround;
    public float checkRadius;
    private Rigidbody2D player;

    void Awake() {
        player = GetComponent<Rigidbody2D>();
        this.isJumping = false;
        this.isCrouched = false;
    }

    void Update() {
        isGrounded = Physics2D.OverlapCircle( feetPos.position, checkRadius, whatIsGround );

        if (isGrounded) {
            isJumping = false;
        }

        if (!isJumping && Input.GetKey(KeyCode.Space)) {
            isJumping = true;
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