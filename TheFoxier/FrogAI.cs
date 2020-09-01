using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogAI : MonoBehaviour
{
    //This is the 'frog' object
    private Rigidbody2D frog;
    public Animator FrogAnimation;
    public LayerMask WhatIsGround;
    public Transform frogFeet;

    public float checkRadius;

    //This is the player object
    private Transform player;
    
    [Range(1f, 10f)]public float jumpSpeed;
    [Range(1f, 10f)]public float frogMovement;
    [Range(1f, 10f)]public float frogSpeed;

    private bool isJumping  = false;
    private bool isOnLeft   = true;
    private bool isGrounded = true;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        frog = this.gameObject.GetComponent<Rigidbody2D>();

        StartCoroutine(frogController());
    }

    private void Update() {
        this.isGrounded = Physics2D.OverlapCircle( frogFeet.position, checkRadius, WhatIsGround );

        if(this.isGrounded) {
            this.isJumping = false;
            FrogAnimation.SetBool("Jump", false);
        }
    }

    private void LateUpdate() {
        float playerPositionX = player.position.x;
        float frogPositionX = this.frog.position.x;
        float playerEnemyDiference = playerPositionX - frogPositionX;

        //Debug.Log("VElocity" + frog.velocity);


        if(playerEnemyDiference > 0 && isOnLeft || playerEnemyDiference < 0 && !isOnLeft)
            this.flipFrog();

    }

    private void flipFrog() {
        Vector3 Frog = this.transform.localScale;
        Frog.x *= -1;
        this.transform.localScale = Frog;

        this.isOnLeft = !this.isOnLeft;
    }

    private void moveAndAnimateFrog() {
        float playerPositionX = player.position.x;
        float frogPositionX = this.frog.position.x;
        float playerEnemyDiference = playerPositionX - frogPositionX;
        
        if(playerEnemyDiference > 0) 
            frog.velocity = new Vector2( frogMovement * frogSpeed, jumpSpeed );  //Player will go to the right
        else if (playerEnemyDiference < 0)
            frog.velocity = new Vector2( -frogMovement * frogSpeed, jumpSpeed ); //Player will go to the left

    }

    // move frog in a x secounds interval
    IEnumerator frogController() {
        // Jump animation
        this.isJumping = true;
        if(!FrogAnimation.GetBool("Jump"))
            FrogAnimation.SetBool("Jump", true);
        moveAndAnimateFrog();
        // force system to wait x secounds
        yield return new WaitForSeconds(3f);
        // end the animation
        // then get ready for the next loop
        StartCoroutine(frogController());
    }
}


 