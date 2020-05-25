using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 10f;
    private bool leftMovement; 

    private bool isGrounded;
    private bool isJumping;
    public Animator PlayerAnimation;
    public Transform feetPos;
    public LayerMask whatIsGround;
    public float checkRadius;

    private Rigidbody2D player;

    void Awake() {
        player = GetComponent<Rigidbody2D>();
        this.leftMovement = true;
    }

    void Update() {
        isGrounded = Physics2D.OverlapCircle( feetPos.position, checkRadius, whatIsGround );

        if (isGrounded)
        {
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

        if ((horizontalMovement > 0 && !leftMovement) || (horizontalMovement < 0 && leftMovement))
            flipPlayer();

        PlayerAnimation.SetFloat("Speed", Mathf.Abs(horizontalMovement));
        player.velocity = new Vector2( horizontalMovement, player.velocity.y );
    }

    private void flipPlayer( ) {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

        this.leftMovement = !this.leftMovement;
    }
}
