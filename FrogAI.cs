using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogAI : MonoBehaviour
{
    //This is the 'frog' object
    public Rigidbody2D frog;
    //This is the player object

    public Animator FrogAnimation;
    private Transform player;
    
    [Range(1f, 10f)]public float jumpSpeed;
    [Range(1f, 10f)]public float frogMovement;
    [Range(1f, 10f)]public float frogSpeed;

    private bool isJumping = false;
    
    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        frog = this.gameObject.GetComponent<Rigidbody2D>();

        StartCoroutine(frogController());
    }

    private void FixedUpdate() {
        FrogAnimation.SetBool("Jump", false);  
        //Debug.Log(FrogAnimation.GetBool("Jump") ? "Jumping" : "Not Jumping");  
    }

    void moveFrog() {

        float playerPositionX = player.position.x;
        float frogPositionX = this.frog.velocity.x;
        float playerEnemyDiference = playerPositionX - frogPositionX;
        
        //Debug.Log(playerEnemyDiference);

        
        if(playerEnemyDiference > 0) {
            frog.velocity = new Vector2(frogPositionX + frogMovement * frogSpeed, this.frog.position.y);
        }
        else if (playerEnemyDiference < 0){
            frog.velocity = new Vector2(frogPositionX - frogMovement * frogSpeed, this.frog.position.y);
        }

        // Jump player
        FrogAnimation.SetBool("Jump", true);
        frog.velocity = Vector2.up * jumpSpeed;
    }

    // move frog in a x secounds interval
    IEnumerator frogController() {
        moveFrog();

        // force system to wait x secounds
        yield return new WaitForSeconds(2f);
        StartCoroutine(frogController());
    }
}


 